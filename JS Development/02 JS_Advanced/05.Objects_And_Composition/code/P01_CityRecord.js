function cityRecord(name, population, treasury) {
    let city = {
        name: name,
        population: population,
        treasury: treasury
    };
    return city;
}
console.log(cityRecord('Tortuga',
    7000,
    15000
));
console.log(cityRecord('Santo Domingo',
    12000,
    23500
));
