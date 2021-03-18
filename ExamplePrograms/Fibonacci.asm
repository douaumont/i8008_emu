fibonacci:
lhi first[h]
lli first[l]
lbm

lam

lhi second[h]
lli second[l]
lcm

adm

lhi first[h]
lli first[l]
lmc

lhi second[h]
lli second[l]
lma

ctc update
lam
out 9
dcl
lam
out 8
jmp fibonacci

first:
db 1
second:
db 1

update:
lai 0
lhi first[h]
lli first[l]
lmi 1
lhi second[h]
lli second[l]
lmi 1
ret

