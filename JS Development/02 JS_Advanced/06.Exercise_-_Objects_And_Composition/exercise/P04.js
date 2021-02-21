function solve(input) {
let result = []
    while (input.length) {
        let hero = input.shift();
        let [name, level, itemsString] = hero.split(' / ');
        let hero2 = {
            name: name,
            level: Number(level),
            items: itemsString ? itemsString.split(', ') : []
        }
        result.push(hero2)
    }
    return JSON.stringify(result);
}
console.log(solve(['Jake / 1000 / Gauss, HolidayGrenade']))