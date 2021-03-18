;B and C are the firts and second bytes of the first number respectively
;H and L are the firts and second bytes of the second number respectively
;after addition B and C will contain the bytes of the result of addition

lbi $80
lci $10

lhi $45
lli $FF

lac
adl
lca

acb
adh

lba

hlt