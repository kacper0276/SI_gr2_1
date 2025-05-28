from itertools import combinations

def negate_literal(literal):
    return literal[1:] if literal.startswith('¬') else '¬' + literal

def pl_resolve(ci, cj):
    resolvents = set()
    for lit in ci:
        if negate_literal(lit) in cj:
            new_clause = (ci - {lit}) | (cj - {negate_literal(lit)})
            resolvents.add(frozenset(new_clause))
    return resolvents

def pl_resolution(kb_clauses, alpha_clause):
    clauses = set(kb_clauses)
    clauses.add(frozenset(alpha_clause))  # Add ¬α
    print("Wstępne klauzule (KB ∧ ¬α):")
    for c in clauses:
        print(f"  {sorted(c)}")
    print("-" * 40)

    iteration = 1
    while True:
        print(f"\nIteracja {iteration}")
        new = set()
        pairs = list(combinations(clauses, 2))
        for ci, cj in pairs:
            resolvents = pl_resolve(ci, cj)
            for res in resolvents:
                print(f"Rozwiązuje {sorted(ci)} ∧ {sorted(cj)} → {sorted(res)}")
                if len(res) == 0:
                    print("Pusta klauzula wykryta, sprzeczność odnaleziona")
                    return True
            new |= resolvents

        if new.issubset(clauses):
            print("\nBrak nowych klauzul. Koniec rozwiązania, brak sprzeczności.")
            return False

        print(f"\nDodano {len(new - clauses)} nowych klauzul:")
        for clause in new - clauses:
            print(f"  {sorted(clause)}")

        clauses |= new
        iteration += 1


clauses = [
    {'¬B11', 'P12', 'P21'},
    {'¬P12', 'B11'},
    {'¬P21', 'B11'},
    {'¬B11'},
]


alpha_negated = {'P12'}

result = pl_resolution([frozenset(c) for c in clauses], alpha_negated)

print("KB ⊨ α ?", result)
