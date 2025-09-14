import numpy as np
import sympy as sp
from sympy import symbols, expand
import os

def divided_differences(x, y):
    n = len(x)
    table = np.zeros((n, n), dtype=object)
    table[:, 0] = y
    
    for j in range(1, n):
        for i in range(n - j):
            table[i][j] = (table[i+1][j-1] - table[i][j-1]) / (x[i+j] - x[i])
    
    return table

def newton_forward(x_data, y_data):
    x = sp.symbols('x')
    n = len(x_data)
    table = divided_differences(x_data, y_data)
    poly = table[0, 0]
    product = 1
    
    for j in range(1, n):
        product *= (x - x_data[j-1])
        poly += table[0, j] * product
    
    return expand(poly)

def newton_backward(x_data, y_data):
    x = sp.symbols('x')
    n = len(x_data)
    table = divided_differences(x_data, y_data)
    poly = table[-1, 0]
    product = 1
    
    for j in range(1, n):
        product *= (x - x_data[-j])
        poly += table[-j-1, j] * product
    
    return expand(poly)

# Пример данных
x_data = [1, 1.2, 1.4, 1.6, 1.8, 2, 2.2, 2.4, 2.6, 2.8, 3]
y_data = [0.485497, 0.386477, 0.233703, 0.200923, 0.263748, 0.447584, 0.436457, 0.257088, 0.20035, 0.238606, 0.398482]
# Первая формула Ньютона
P_forward = newton_forward(x_data, y_data)
print("Первая формула Ньютона:")
sp.pprint(P_forward)

# Вторая формула Ньютона
P_backward = newton_backward(x_data, y_data)
print("\nВторая формула Ньютона:")
sp.pprint(P_backward)


print("Press enter to comtinue")

input()


os.system("pause")