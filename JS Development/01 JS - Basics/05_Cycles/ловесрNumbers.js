function ловесрNumbers(inputParameters) {
    let lowestNumber = Number.POSITIVE_INFINITY;
    for (let i = 1; i < inputParameters.length; i++) {
        let currentNum = Number(inputParameters[i]);
        if (currentNum < lowestNumber) {
            lowestNumber = currentNum;
        }
    }
    console.log(lowestNumber);
}
