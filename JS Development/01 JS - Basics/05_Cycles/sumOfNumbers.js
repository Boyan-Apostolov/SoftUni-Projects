function sumOfNumbers([inputParameters]) {
    let n = Number(inputParameters[0]);
    for (let i = 0; i < n; i++) {
        console.log(inputParameters[i + 1]);
    }
}
