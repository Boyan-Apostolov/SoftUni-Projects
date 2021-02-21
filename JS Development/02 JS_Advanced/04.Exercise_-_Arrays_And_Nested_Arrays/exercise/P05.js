function solve(array) {
    let result = [];
    // for (let i = 1; i <= array.length; i++) {
    //     const element = array[i];
    //     if (result[result.length - 1] <= element) {
    //         result[result.length] = element;
    //     }
    // }
    result = array.reduce((result, currentValue) => {
        if(currentValue >= result[result.length - 1] || result.length === 0){
            result.push(currentValue);
        }
        return result
    }, [])
    return result;
}
console.log(solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
))
console.log(solve([20,
    3,
    2,
    15,
    6,
    1]
))
console.log(solve([1,
    2,
    3,
    4]
))