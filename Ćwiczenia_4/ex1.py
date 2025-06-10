import numpy as np
from scipy import stats

years = np.array([2000, 2002, 2005, 2007, 2010])
percentages = np.array([6.5, 7.0, 7.4, 8.2, 9.0])

slope, intercept, r_value, p_value, stderr = stats.linregress(years, percentages)

m = slope
b = intercept

print(f"Linear Regression Model: Percentage = {m:.3f} * Year + {b:.3f}")
print(f"Wspolczynnik kierunkowy: {m:.3f}")
print(f"Wyraz wolny: {b:.3f}")