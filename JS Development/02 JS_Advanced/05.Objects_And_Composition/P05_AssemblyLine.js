function createAssemblyLine() {
    let bigObj = {
        hasClima: function (car) {
            Object.assign(car, { temp: 21 })
            Object.assign(car, { tempSettings: 21 })
            Object.assign(car, {
                adjustTemp: function () {
                    if (car.temp < car.tempSettings) { car.temp++ }
                    else if (car.temp > car.tempSettings) { car.temp-- }
                }
            })
        },
        hasAudio: function (car) {
            Object.assign(car, { currentTrack: { name: null, artist: null } })
            Object.assign(car, {
                nowPlaying: function () {
                    if (car.currentTrack.name != null && car.currentTrack.artist != null) { console.log(`Now playing '${car.currentTrack.name}' by ${car.currentTrack.artist}`) }
                },
            })
        },
        hasParktronic : function (car) {
            Object.assign(car, {
                checkDistance : function (distance) {
                    if(distance < 0.1){console.log("Beep! Beep! Beep!")}
                    else if(0.1 <= distance && distance < 0.25){console.log("Beep! Beep!")}
                    else if(0.25 <= distance && distance < 0.5 ){console.log("Beep!")}
                    else{console.log('')}
                }
            })
        }
    }
    return bigObj;
}
const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};
const assemblyLine = createAssemblyLine();
assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);
assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();
assemblyLine.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);
console.log(myCar);