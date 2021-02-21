function leftAndRightSum(inputParameters) {
    let leftSum = 0;
    let rightSum = 0;
    let leftEndIndexs = (inputParameters.length - 1) / 2;

    for (let i = 1; i <= leftEndIndexs; i++) {
        let currentNum = inputParameters[i];
        leftSum += currentNum;
    }

    for (let i = leftEndIndexs + 1; i < inputParameters.length; i++) {
        let currentNum = inputParameters[i];
        rightSum += currentNum;
    }

    if (leftSum == rightSum) {
        console.log(`Yes, sum = ${leftSum}`);
    }
    else {
        console.log(`No, diff = ${math.abs(leftSum, rightSum)}`);
    }
}
