;Program of multiplying two numbers
;port 0 -number to be multiplied, port 1 - multiplier, port 8 - result of multiplying
inp 0
lba
inp 1
lca
cal mulFunction
out 8
hlt



mulFunction: ;b - number to be multiplied, c - multiplier, a - result of multiplying
lai 0
mul:
adb
dcc
jfz mul
ret