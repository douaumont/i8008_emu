;This program counts, how many significant bits are in the number, read from the port 0
;The output shall be written to port 8
inp 0
lbi 0
loop:
cpi 0
jtz exit
inb
rrc
jmp loop

exit:
lab
out 8
hlt