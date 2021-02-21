function extractSubSequence(array) {
    // let result = [];
    // for (let i = 0; i < array.length; i++) {
    //     let element = array[i];
    //     if (element >= result[result.length - 1] || result.length === 0) {
    //         result.push(element)
    //     }
    // }
    // return result;
    return array.reduce(function (result, currentValue, index, initialArr) {
        if (currentValue >= result[result.length - 1] || result.length === 0) {
            result.push(currentValue);
        }
        return result;
    }, []);
}
console.log(extractSubSequence([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(extractSubSequence([1, 3, 8, 10, 12, 24]));
console.log(extractSubSequence([20, 3, 2, 15, 6, 1]));
