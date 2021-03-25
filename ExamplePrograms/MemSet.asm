;memset procedure
;HL - address of begining
;b - value to write, c - amount of 8-bit cells to be written, other registers must be saved elsewhere, 
;otherwise they shall be corrupted! 
lhi $01
lli $00
lci 16
lbi 1
cal memset
hlt

memset:
ldi 1
lei 0
loop:
lmb
lal
add
lla
ace
adh
lha
dcc
jfz loop