function oddSum(inputParameters) {
    let oddSum = 0;
    let evenSum = 0;
    for (let i = 1; i < inputParameters.length; i++) {
        if (i % 2 == 0) {
            evenSum += inputParameters[i];
        }
        else {
            oddSum += inputParameters[i];
        }
    }
    if (oddSum == evenSum) {
        console.log(`Yes, sum = ${oddSum}`);
    }
    else {
        console.log(`No, diff = ${Math.abs(oddSum - evenSum)}`);
    }
}
