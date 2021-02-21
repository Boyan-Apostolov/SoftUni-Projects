function solve(input) {
    function getEngine(power) {
        let engines = [
            { power: 90, volume: 1800 },
            { power: 120, volume: 2400 },
            { power: 200, volume: 3500 },
        ];
        return engines.find(e => power >= e.power)
    }
    function getCarriage(carriage,color){
        return {
            type : carriage,
            color
        }
    }
    function getWheels(inches){
        let wheel = Math.floor(inches) % 2 == 0 ? Math.floor(inches)-1 :Math.floor(inches)

        return [wheel,wheel,wheel,wheel]
    }
    return {
        model: input.model,
        engine: getEngine(input.power),
        carriage: getCarriage(input.carriage,input.color),
        wheels: getWheels(input.wheelsize)
    }
}
console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
))
console.log(solve({ model: 'Opel Vectra',
power: 110,
color: 'grey',
carriage: 'coupe',
wheelsize: 17 }
))