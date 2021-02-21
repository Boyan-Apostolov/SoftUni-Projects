function solve(input) {
    let dictionary = {};

    while (input.length) {
        let [name, price] = input.shift().split(' : ');
        const firstLetter = name[0];

        if (!dictionary[firstLetter]) {
            dictionary[firstLetter] = [];
        }
        dictionary[firstLetter].push({ name, price: Number(price)});
        dictionary[firstLetter].sort((a,b)=> (a.name).localeCompare(b.name))
    }
    
    let result = [];
    // for (const letter in dictionary) {
    //     let values = dictionary[letter].map(entry=>`  ${entry.name}: ${entry.price}`)
        
    //     let string = `${letter}\n${values.join('\n')}`
        
    //     result.push(string)
    // }
    Object.entries(dictionary).sort((a,b)=> a[0].localeCompare(b[0])).forEach(entry=>{
        let string = `${entry[0]}\n${entry[1].sort((a,b)=> a.name.localeCompare(b.name)).map(product=>`  ${product.name}: ${product.price}`).join('\n')}`;
        result.push(string)
    })
    return result.join('\n')
}

console.log(solve(
    ['Appricot : 20.4',
        'Fridge : 1500',
        'TV : 1499',
        'Deodorant : 10',
        'Boiler : 300',
        'Apple : 1.25',
        'Anti-Bug Spray : 15',
        'T-Shirt : 10']
))