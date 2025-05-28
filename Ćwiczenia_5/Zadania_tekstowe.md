
## Rozwiązania zadań

###  Zadanie 2
(i) Jeżeli Wumpus może znaleźć się w polu z dołem, to należy rozważyć 4 × 8 = 32 sytuacji.

Z kolei jeżeli nie, to będzie to 1 × 4 + 3 × 3 + 3 × 2 + 1 × 1 = 20

---

###  Zadanie 3
**Zapytanie:**  Czy ¬(p∨(¬p∧q)) i ¬p∧¬q są logicznie równoważne

**Przekształcenia:**

**¬(p∨(¬p∧q))**

**≡¬p∧¬(¬p∧q)** (z II prawa De Morgana)

**≡¬p∧(p∨¬q)** (z I prawa De Morgana)

**≡(¬p∧p)∨(¬p∧¬q)**

**(¬p∧p)** jest fałszem więc zostaje **(¬p∧¬q)**

Więc tak, ¬(p∨(¬p∧q)) i ¬p∧¬q są logicznie równoważne



---
### Zadanie 4
Czy zdania są spełnialne?
#### (i) (p ⇒ q) ⇒ (¬p ⇒ ¬q)

**Przekształcenia:**

p ⇒ q ≡ ¬p ∨ q  
¬p ⇒ ¬q ≡ p ∨ ¬q  

Całe zdanie:  
(p ⇒ q) ⇒ (¬p ⇒ ¬q) 
≡ ¬(¬p ∨ q) ∨ (p ∨ ¬q)  
≡ (p ∧ ¬q) ∨ (p ∨ ¬q) (z II prawa De Morgana)
≡ p ∨ ¬q

Zdanie jest więc spełnialne, np. dla p = 1, q = 0


#### (ii) (p ⇒ q) ⇒ ((p ∧ r) ⇒ q)

**Przekształcenia:**

p ⇒ q ≡ ¬p ∨ q  
(p ∧ r) ⇒ q ≡ ¬(p ∧ r) ∨ q ≡ ¬p ∨ ¬r ∨ q  

Całe zdanie:  
(¬p ∨ q) ⇒ (¬p ∨ ¬r ∨ q)  
≡ ¬(¬p ∨ q) ∨ (¬p ∨ ¬r ∨ q)  
≡ (p ∧ ¬q) ∨ (¬p ∨ ¬r ∨ q) (z II prawa De Morgana)

Zdanie jest więc spełnialne, np. dla p = 0, q = 1, r = 0

---
###  Zadanie 5

**Zapytanie:**  
Czy (p ⇒ q) |= (p ∧ r) ⇒ q) ?  


####  Tabela prawdziwości


| p | q | r | p ⇒ q | p ∧ r | (p ∧ r) ⇒ q |
|---|---|---|------------|------------|------------------|
| 0 | 0 | 0 |     **1**      |     0      |        1         |
| 0 | 0 | 1 |     **1**      |     0      |        1         |
| 0 | 1 | 0 |     **1**      |     0      |        1         |
| 0 | 1 | 1 |     **1**      |     0      |        1         |
| 1 | 0 | 0 |     0      |     0      |        1         |
| 1 | 0 | 1 |     0      |     1      |        0         |
| 1 | 1 | 0 |     **1**      |     0      |        1         |
| 1 | 1 | 1 |     **1**      |     1      |        1         |


Sprawdzamy tylko te wiersze, w których wartość dla p ⇒ q to 1:  
To wiersze: 1, 2, 3, 4, 7, 8.

We wszystkich tych przypadkach również  (p ∧ r) ⇒ q ma wartość 1, więc implikacja sematyczna zachodzi.

---
###  Zadanie 6

#### (i) (p ⇒ q) ⇒ (¬p ⇒ ¬q)

####  Tabela prawdziwości:

| p | q | p ⇒ q | ¬p | ¬q | ¬p ⇒ ¬q | (p ⇒ q) ⇒ (¬p ⇒ ¬q) |
|---|---|--------|----|----|----------|--------------|
| 0 | 0 |   1    | 1  | 1  |    1     |      1       |
| 0 | 1 |   1    | 1  | 0  |    0     |      0       |
| 1 | 0 |   0    | 0  | 1  |    1     |      1       |
| 1 | 1 |   1    | 0  | 0  |    1     |      1       |

####  Przypisania dla których zdanie ma wartość 1:

- (p=0, q=0)
- (p=1, q=0)
- (p=1, q=1)


####  DNF (forma alternatywna)

(¬p ∧ ¬q) ∨ (p ∧ ¬q) ∨ (p ∧ q)


####  CNF (forma koniunkcyjna)

Zdanie fałszywe tylko dla (p=0, q=1)

Negacja tego przypisania: (p ∨ ¬q)

Czyli:

(p ∨ ¬q)

---

#### (ii) (p ⇒ q) ⇒ ((p ∧ r) ⇒ q)

####  Tabela prawdziwości:

| p | q | r | p ⇒ q | p ∧ r | (p ∧ r) ⇒ q | (p ⇒ q) ⇒ ((p ∧ r) ⇒ q) |
|---|---|---|--------|--------|----------------|--------------|
| 0 | 0 | 0 |   1    |   0    |       1        |      1       |
| 0 | 0 | 1 |   1    |   0    |       1        |      1       |
| 0 | 1 | 0 |   1    |   0    |       1        |      1       |
| 0 | 1 | 1 |   1    |   0    |       1        |      1       |
| 1 | 0 | 0 |   0    |   0    |       1        |      1       |
| 1 | 0 | 1 |   0    |   1    |       0        |      1       |
| 1 | 1 | 0 |   1    |   0    |       1        |      1       |
| 1 | 1 | 1 |   1    |   1    |       1        |      1       |

 Zdanie jest tautologią
 DNF: 1
 CNF: 1

---

### Zadanie 7

  Dane zdania:

1. A ⇔ (B ∨ E)  
2. E ⇒ D  
3. (C ∧ F) ⇒ ¬B  
4. E ⇒ B  
5. B ⇒ F  
6. B ⇒ C

Wniosek do udowodnienia: ¬A ∧ ¬B


#### Przekształcenie do CNF

1. A ⇔ (B ∨ E)
- ¬A ∨ B ∨ E  
- ¬B ∨ A  
- ¬E ∨ A

2. E ⇒ D
- ¬E ∨ D

3. (C ∧ F) ⇒ ¬B
- ¬C ∨ ¬F ∨ ¬B

4. E ⇒ B
- ¬E ∨ B

5. B ⇒ F
- ¬B ∨ F

6. B ⇒ C
- ¬B ∨ C



####  Zbiór klauzul (KB)

1. (¬A ∨ B ∨ E)  
2. (¬B ∨ A)  
3. (¬E ∨ A)  
4. (¬E ∨ D)  
5. (¬C ∨ ¬F ∨ ¬B)  
6. (¬E ∨ B)  
7. (¬B ∨ F)  
8. (¬B ∨ C)

Dodajemy negację wniosku:
¬(¬A ∧ ¬B) ≡ A ∨ B

9. (A ∨ B)


#### Dowodzenie przez rezolucję
(A ∨ B) ∧  (¬B ∨ A) ⇒ (A ∨ A) ≡ A

A ∧  (¬A ∨ B ∨ E) ⇒ (B ∨ E)

(B ∨ E) ∧  (¬E ∨ B)  ⇒ B

B ∧  (¬B ∨ F) ⇒ F

B ∧  (¬B ∨ C) ⇒ C

C ∧  F ∧  (¬C ∨ ¬F ∨ ¬B)  ⇒ ¬B

¬B ∧ B ⇒ ϕ

Znaleziono sprzeczność w zbiorze klauzul z zaprzeczeniem wniosku. Oznacza to, że ¬A∧¬B została wywnioskowana logicznie metodą rezolucji




---
###  Zadanie 8

Znajdź unifikator dla:  
α = Older(Father(y), y)  
β = Older(Father(x), John)


Aby wyrażenia były identyczne:

- Father(y) = Father(x) → y = x  
- y = John → podstawiamy y = John ⇒ x = John

**Unifikator:**

{ x ↦ John, y ↦ John }

Jest to najbardziej ogólny unifikator

---

### Zadanie 9

#### Zdania wstępne:
- Każdy, kto kocha wszystkie zwierzęta, jest przez kogoś kochany.
- Nikt nie kocha tego, kto zabija zwierzę.
- Jack kocha wszystkie zwierzęta.
- Albo Jack, albo Jola zabili kota Tuna.

Wnsiosek do sprawdzenia - Czy Jola zabiła kota?



#### (i) KB

1. ∀x [ (∀y (Zwierze(y) → Kocha(x, y))) → ∃z Kocha(z, x) ]  
2. ∀x ∀y [ (Zwierze(y) ∧ Zabija(x, y)) → ∀z ¬Kocha(z, x) ]  
3. ∀y [ Zwierze(y) → Kocha(Jack, y) ]  
4. Kot(Tuna)  
5. Zwierze(Tuna)  
6. Zabija(Jack, Tuna) ∨ Zabija(Jola, Tuna)

**Wniosek do sprawdzenia:**  
Zabija(Jola, Tuna)  
Dowodzimy przez zaprzeczenie: ¬Zabija(Jola, Tuna)



#### (ii) CNF:

1. ¬Kocha(x, y) ∨ ¬Zwierze(y) ∨ Kocha(f(x), x)  
2. ¬Zwierze(y) ∨ ¬Zabija(x, y) ∨ ¬Kocha(z, x)  
3. ¬Zwierze(y) ∨ Kocha(Jack, y)  
4. Zwierze(Tuna)  
5. Kot(Tuna)  
6. Zabija(Jack, Tuna) ∨ Zabija(Jola, Tuna)  

Dodajemy negację wniosku:

7. ¬Zabija(Jola, Tuna) 


#### (iii) Dowodzenie przez rezolucje:
(Zabija(Jack, Tuna) ∨ Zabija(Jola, Tuna)) ∧  ¬Zabija(Jola, Tuna) ⇒ Zabija(Jack, Tuna)

Z (2), (4) i powyższego:  
Zabija(Jack, Tuna) ∧ Zwierze(Tuna) ∧ (¬Zwierze(Tuna) ∨ ¬Zabija(Jack, Tuna) ∨ ¬Kocha(z, Jack)) ⇒ ¬Kocha(z, Jack)

Z (3), (4):  
Zwierze(Tuna) ∧ (¬Zwierze(Tuna) ∨ Kocha(Jack, Tuna)) ⇒ Kocha(Jack, Tuna)

Z (1) ,(4) i powyższego
(¬Kocha(Jack, Tuna) ∨ ¬Zwierze(Tuna) ∨ Kocha(f(x), Jack)) ∧ Kocha(Jack, Tuna) ∧ Zwierze(Tuna)  ⇒ Kocha(f(x), Jack))

Kocha(f(x), Jack)) ∧ ¬Kocha(z, Jack) ⇒ ϕ

Sprzeczność:  
Jednocześnie ktoś kocha Jacka i nikt go nie kocha.

 **Sprzeczność** → wniosek prawdziwy.

 **Jola zabiła kota Tuna :(**

---
