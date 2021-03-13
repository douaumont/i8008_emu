;Program of multiplying two numbers

lhi number[h]
lli number[l]
lbm
lhi multiplier[h]
lli multiplier[l]
lcm
cal mulFunction
hlt
number:
db 10
multiplier:
db 5


mulFunction: ;b - number to be multiplied, c - multiplier, a - result of multiplying
lai 0
mul:
adb
dcc
jfz mul
ret