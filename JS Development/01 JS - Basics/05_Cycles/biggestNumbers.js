function biggestNumbers(inputParameters) {
    let biggestNumber = Number.NEGATIVE_INFINITY;
    for (let i = 1; i < inputParameters.length; i++) {
        let currentNum = Number(inputParameters[i]);
        if (currentNum > biggestNumber) {
            biggestNumber = currentNum;
        }
    }
    console.log(biggestNumber);
}
