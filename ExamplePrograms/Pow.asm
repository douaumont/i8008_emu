; D - x E - y
; Port 8 will be written with value x^y
inp 0 ;read x
lda
inp 1 ;read y
lea
lbi 1


pow:
lha
lae 
cpi 0
lah
jtz exit
lcd
cal mulFunction
dce
lba
jmp pow

exit:
lab
out 8
hlt

mulFunction: ;b - number to be multiplied, c - multiplier, a - result of multiplying
lai 0
mul:
adb
dcc
jfz mul
ret