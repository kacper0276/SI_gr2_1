variables = ['X1', 'X2', 'X3']
domains = {
    'X1': ['R', 'B', 'G'],

    'X2': ['R'],
    'X3': ['G']
}

def constraints(assignment, var, value):
    for other_var, other_value in assignment.items():
        if value == other_value:
            return False
    return True

def select_unassigned_variable(assignment, domains):
    unassigned = [v for v in variables if v not in assignment]
    return min(unassigned, key=lambda var: len(domains[var]))

def backtrack(assignment):
    if len(assignment) == len(variables):
        return assignment

    var = None
    if 'X2' not in assignment:
        var = 'X2'
    else:
        var = select_unassigned_variable(assignment, domains)

    for value in domains[var]:
        if constraints(assignment, var, value):
            assignment[var] = value
            result = backtrack(assignment)
            if result is not None:
                return result
            del assignment[var]
    return None

solution = backtrack({})

if solution:
    print("Znalezione rozwiązanie CSP:")
    for var, value in solution.items():
        print(f"{var} = {value}")
else:
    print("Brak rozwiązania.")