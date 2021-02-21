function magicMatrix(arr) {
    let rowSums = [];
    let colSums = []
    for (let i = 0; i < arr.length; i++) {
        let row = arr[i]
        let sum = row.reduce((result, current) => (result + current), 0)
        rowSums.push(sum);
    }
    for (let i = 0; i < arr.length; i++) {
        let newRow = [];
        for (let y = 0; y < arr.length; y++) {
            let index = arr.length - 1 - y;
            newRow.push(arr[index][i])
        }
        let sum = newRow.reduce((result, current) => (result + current), 0)
        colSums.push(sum);
    }
    return rowSums.concat(colSums).every((el, i, arr) => { return el == arr[0] })
}
console.log(magicMatrix([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
))
console.log(magicMatrix([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
))
console.log(magicMatrix([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
))