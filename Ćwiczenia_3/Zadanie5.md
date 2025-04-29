
## Analiza przybliżeń zbiorów decyzyjnych metodą zbiorów przybliżonych

### Dane

Zbiór atrybutów: `A = {a1, a2, a3}`  
Dodatkowy zbiór: `B = {a1, a2}`

Zbiory decyzyjne:
- `X1 = {o1, o2, o3, o7, o9}` (klasa "tak")
- `X2 = {o5, o6, o8}` (klasa "nie")

Tabela decyzyjna:

| Obiekt | a1                | a2      | a3     | dec       |
|--------|-------------------|---------|--------|-----------|
| o1     | wysoka            | bliski  | średni | tak       |
| o2     | wysoka            | bliski  | średni | tak       |
| o3     | wysoka            | bliski  | średni | tak       |
| o4     | więcej niż średnia| daleki  | silny  | niepewne  |
| o5     | więcej niż średnia| daleki  | silny  | nie       |
| o6     | więcej niż średnia| daleki  | lekki  | nie       |
| o7     | wysoka            | bliski  | średni | tak       |
| o8     | więcej niż średnia| daleki  | lekki  | nie       |
| o9     | więcej niż średnia| daleki  | lekki  | tak       |

---

## Przybliżenia zbioru X2 względem A = {a1, a2, a3}

### Klasy nieodróżnialności względem A:
- [o1, o2, o3, o7] — (wysoka, bliski, średni)
- [o4, o5] — (więcej niż średnia, daleki, silny)
- [o6, o8, o9] — (więcej niż średnia, daleki, lekki)

### Dolne przybliżenie `X2`:
Żadna z klas nie zawiera się w całości w `X2`.

- `∴ Dolne przybliżenie A(X2) = ∅`

### Górne przybliżenie `X2`:
- Klasa [o4, o5] — zawiera o5 ∈ X2
- Klasa [o6, o8, o9] — zawiera o6, o8 ∈ X2

- `∴ Górne przybliżenie A(X2) = {o4, o5, o6, o8, o9}`

---

## Przybliżenia względem B = {a1, a2}

### Klasy nieodróżnialności względem B:
- [o1, o2, o3, o7] — (wysoka, bliski)
- [o4, o5, o6, o8, o9] — (więcej niż średnia, daleki)

### Dla `X1 = {o1, o2, o3, o7, o9}`:

#### Dolne przybliżenie `B(X1)`:
- Klasa [o1, o2, o3, o7] ⊆ X1

- `∴ Dolne przybliżenie B(X1) = {o1, o2, o3, o7}`

#### Górne przybliżenie `B(X1)`:
- Klasa [o1, o2, o3, o7] — zawiera się w X1
- Klasa [o4, o5, o6, o8, o9] — zawiera o9 ∈ X1

- `∴ Górne przybliżenie B(X1) = {o1, o2, o3, o4, o5, o6, o7, o8, o9}`

---

### Dla `X2 = {o5, o6, o8}`:

#### Dolne przybliżenie `B(X2)`:
- Klasa [o4, o5, o6, o8, o9] — zawiera też o4 i o9 ∉ X2

- `∴ Dolne przybliżenie B(X2) = ∅`

#### Górne przybliżenie `B(X2)`:
- Klasa [o4, o5, o6, o8, o9] — zawiera o5, o6, o8 ∈ X2

- `∴ Górne przybliżenie B(X2) = {o4, o5, o6, o8, o9}`

---

## Podsumowanie

| Zbiór | Atrybuty | Dolne przybliżenie        | Górne przybliżenie                |
|-------|----------|---------------------------|-----------------------------------|
| X2    | A        | ∅                         | {o4, o5, o6, o8, o9}              |
| X1    | B        | {o1, o2, o3, o7}           | {o1, o2, o3, o4, o5, o6, o7, o8, o9} |
| X2    | B        | ∅                         | {o4, o5, o6, o8, o9}              |
