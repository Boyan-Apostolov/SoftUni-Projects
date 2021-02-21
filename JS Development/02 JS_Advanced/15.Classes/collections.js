const myMap = new Map();

myMap.set('peter','+1-555-4981')
myMap.set('john','+1-555-6246')

console.log(myMap.get('peter'))
myMap.set('peter','+359-887-39853')

Array.from(myMap)

for (const entry of myMap) {
    console.log(entry)
}

console.log(myMap.entries())

