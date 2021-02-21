function sortNumbers(arr) {
    arr.sort((a, b) => { return a - b; });
    let result = [];
    while (arr.length) {
        let fist = arr.shift();
        result.push(fist);
        let last = arr.pop();
        result.push(last);
    }
    return result;;
}
console.log(sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
