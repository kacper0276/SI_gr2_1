def PL_TRUE(S, m):
    # Jeśli S jest symbolem atomowym
    if isinstance(S, str):
        return bool(m.get(S, 0))  # domyślnie 0

    op = S[0]

    if op == 'NOT':
        return not PL_TRUE(S[1], m)
    elif op == 'AND':
        return PL_TRUE(S[1], m) and PL_TRUE(S[2], m)
    elif op == 'OR':
        return PL_TRUE(S[1], m) or PL_TRUE(S[2], m)
    elif op == 'IMPLIES':
        return (not PL_TRUE(S[1], m)) or PL_TRUE(S[2], m)
    elif op == 'IFF':
        return PL_TRUE(S[1], m) == PL_TRUE(S[2], m)

    raise ValueError(f"Nieznany operator logiczny: {op}")

S = ('IMPLIES', ('AND', 'p', 'q'), 'r')
m = {'p': 1, 'q': 1,'r':0}
print(PL_TRUE(S, m))