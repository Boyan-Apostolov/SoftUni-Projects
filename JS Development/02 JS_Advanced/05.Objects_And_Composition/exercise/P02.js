function solve(arr) {
    let result = [];
    for (const town of arr) {
        let tokens = town.split(' <-> ');
        let townName = tokens[0];
        let population = Number(tokens[1]);

        if (result[townName] == undefined) {
            result[townName] = population;
        } else {
            result[townName] += population;
        }
    }
    for (const town in result) {
        console.log(`${town} : ${result[town]}`)
    }
}
solve(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
)
solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']
)
