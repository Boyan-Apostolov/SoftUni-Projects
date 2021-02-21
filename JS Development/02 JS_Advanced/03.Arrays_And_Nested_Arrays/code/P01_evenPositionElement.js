function evenPositionElement(inputArr) {
    let result = [];
    for (let i = 0; i < inputArr.length; i+=2) {
            result[result.length] = inputArr[i];
    }
    return result.join(' ');
}
console.log(evenPositionElement(['20', '30', '40', '50', '60']))
console.log(evenPositionElement(['5', '10']))