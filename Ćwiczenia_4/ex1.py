import numpy as np
from scipy import stats
import math

years = np.array([2000, 2002, 2005, 2007, 2010])
percentages = np.array([6.5, 7.0, 7.4, 8.2, 9.0])

nachylenie, punkt_przeciecia, r_value, p_value, stderr = stats.linregress(years, percentages)

m = nachylenie
b = punkt_przeciecia

print(f"Linear Regression Model: Percentage = {m:.3f} * Year + {b:.3f}")
print(f"Wspolczynnik kierunkowy: {m:.3f}")
print(f"Wyraz wolny: {b:.3f}")

docelowy_procent = 12.0
rok_przekroczenia = (docelowy_procent - punkt_przeciecia) / nachylenie

finalny_rok = math.ceil(rok_przekroczenia)

print(f"Na podstawie modelu, procent bezrobocia przekroczy 12% w roku: {finalny_rok}")

przewidywany_procent_2023 = nachylenie * finalny_rok + punkt_przeciecia
print(f"{przewidywany_procent_2023:.3f}%")
