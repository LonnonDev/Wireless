width = 4
inputs = 4

array = []

for x in range(1, inputs+1):
    if x > width/2:
        array.instert(0, -(inputs - (width/inputs)*x))
    else: 
        array.instert(0, (width/inputs)*x)

