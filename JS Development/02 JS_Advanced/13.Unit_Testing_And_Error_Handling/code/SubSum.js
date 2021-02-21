function solve(array, start, end) {
    /*
    •	If the start index is less than zero, consider its value to be a zero
    •	If the first element is not an array, return NaN
    •	If the end index is outside the bounds of the array, assume it points to the last index of the array
    */
    if (start < 0) {
        start = 0
    }
    if (Array.isArray(array) == false) {
        return NaN
    }
    if (end > array.length - 1) {
        end = array.length - 1
    }
    return array.slice(start, end + 1).reduce((a, c) => a + Number(c), 0);
}
console.log(solve([10, 20, 30, 40, 50, 60], 3, 300))
console.log(solve([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1))
console.log(solve([10, 'twenty', 30, 40], 0, 2))
console.log(solve([], 1, 2))
console.log(solve('text', 0, 2))