import numpy as np
import itertools


def load_data(filename):
    data = []
    with open(filename) as f:
        for line in f:
            row = list(map(float, line.strip().split()))
            data.append(row)
    return np.array(data)


def rule_matches(rule, example):
    for attr_idx, op, val in rule['conditions']:
        if op == '<=' and not example[attr_idx] <= val:
            return False
        if op == '>' and not example[attr_idx] > val:
            return False
    return True


def is_consistent(rule, examples, target_index):
    for e in examples:
        if rule_matches(rule, e) and e[target_index] != rule['class']:
            return False
    return True


def generate_conditions(example, attr_indices):
    conditions = []
    for idx in attr_indices:
        val = example[idx]
        conditions.append([(idx, '<=', val), (idx, '>', val)])
    return list(itertools.product(*conditions))


def layered_consistent_rules(examples, target_index, class_label):
    rules = []
    already_covered = set()
    attr_indices = list(range(examples.shape[1] - 1))
    max_len = len(attr_indices)

    class_objects = [i for i, e in enumerate(examples) if e[target_index] == class_label]

    for cond_len in range(1, max_len + 1):
        for i in class_objects:
            if i in already_covered:
                continue

            ex = examples[i]
            found = False

            for attrs in itertools.combinations(attr_indices, cond_len):
                all_conds = generate_conditions(ex, attrs)
                for conds in all_conds:
                    rule = {'conditions': list(conds), 'class': class_label}

                    if is_consistent(rule, examples, target_index):
                        covered_now = {j for j, ex2 in enumerate(examples)
                                       if rule_matches(rule, ex2) and ex2[target_index] == class_label}

                        new_covered = covered_now - already_covered

                        if new_covered:
                            rule['covered_count'] = len(new_covered)
                            rules.append(rule)
                            already_covered.update(new_covered)
                            found = True
                            break
                if found:
                    break

        if len(already_covered) == len(class_objects):
            break

    return rules


def count_covered_objects(rule, examples, target_index):
    return sum(1 for e in examples if rule_matches(rule, e) and e[target_index] == rule['class'])


def save_rules_to_file(rules, filename, examples, target_index):
    with open(filename, "w") as f:
        for r in rules:
            cond = " AND ".join([f"a{c[0] + 1} {c[1]} {c[2]}" for c in r['conditions']])
            covered = r.get('covered_count', count_covered_objects(r, examples, target_index))
            f.write(f"IF {cond} THEN d = {r['class']} [covers: {covered} objects]\n")



data = load_data("diabetes.txt")
target_index = data.shape[1] - 1

rules_class_1 = layered_consistent_rules(data, target_index, class_label=1)
rules_class_0 = layered_consistent_rules(data, target_index, class_label=0)

print("Reguły dla klasy decyzyjnej 1:")
for r in rules_class_1:
    cond = " AND ".join([f"a{c[0] + 1} {c[1]} {c[2]}" for c in r['conditions']])
    covered = r.get('covered_count', count_covered_objects(r, data, target_index))
    print(f"IF {cond} THEN d = {r['class']} [covers: {covered} objects]")

print("\nReguły dla klasy decyzyjnej 0:")
for r in rules_class_0:
    cond = " AND ".join([f"a{c[0] + 1} {c[1]} {c[2]}" for c in r['conditions']])
    covered = r.get('covered_count', count_covered_objects(r, data, target_index))
    print(f"IF {cond} THEN d = {r['class']} [covers: {covered} objects]")

# Zapis do pliku
save_rules_to_file(rules_class_1 + rules_class_0, "reguly.txt", data, target_index)
