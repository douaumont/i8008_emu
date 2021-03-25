;This program demonstrates how the bit operations work
;All the result are stored in register A
lai $AA
ori $55 ;the result will be $FF

lai $AA
lbi $02
xrb ;the result will be $A8

lai $BC
lci $0F
ndc ;the result will be $0C

;NOT operation
lai $AA
xri $FF ;the result will be $55

hlt