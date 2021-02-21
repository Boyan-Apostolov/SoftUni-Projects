function solve(n, k) {
    let arr = [];
    arr[arr.length] = 1;
    for (let i = 1; i < n; i++) {
        arr[arr.length] = getPrevious(arr, i, k)
    }

    function getPrevious(arr, i, k) {
        let currentSum = 0;
        for (let l = i - k; l < i; l++) {
            if (arr[l]) {
                currentSum += arr[l];
            }
        }
        return currentSum;
    }

    return arr;
}
console.log(solve(6, 3))
console.log(solve(8, 2))