//console.log(sum)
//console.log(avg)
//console.log(max)
function printDiagonals(matrix) {
    let mainDiag = 0;
    let secDiag = 0;

    for (let i = 0; i < matrix.length; i++) {
        mainDiag += matrix[i][i];
        secDiag += matrix[i][matrix.length - i - 1];
    }
    return mainDiag + ' ' + secDiag;
}
console.log(printDiagonals([[20, 40],
[10, 60]]));
console.log(printDiagonals([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]));
