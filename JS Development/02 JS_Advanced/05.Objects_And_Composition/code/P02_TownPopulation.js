function townPopulation(townsArray) {
    const towns = {};
    for (let townAsString of townsArray) {
        let tokens = townAsString.split(' <-> ');
        let townName = tokens[0];
        let population = Number(tokens[1]);
        //towns[townName] == undefined ? towns[townName] = population : towns[townName] += population
        if (towns[townName] != undefined) {
            population += towns[townName];
        }
        towns[townName] = population;
    }
    for (let name in towns) {
        console.log(`${name} : ${towns[name]}`);
    }
}
townPopulation(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']
);
townPopulation(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']
);
