;Program of dividing one number by another 
;port 0 - number to divide, port 1 - divisor, port 8 - quotient, port 9 - remainder
;d - number to divide, e - divisor, b - quotient, c - remainder

inp 0
lda
inp 1
lea
cal div
lab
out 8
lac
out 9
hlt

div:
lad
loop:
sue
inb
cpe
jfs loop
lca
ret



