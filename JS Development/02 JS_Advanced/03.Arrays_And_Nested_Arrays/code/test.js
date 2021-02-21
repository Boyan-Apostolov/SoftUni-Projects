let jagged = [[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]];
for (const row of jagged) {
    console.log(row.join('\t'))
}
let result = jagged.reduce(matrixReducer);
console.log(result)
function matrixReducer(acc,c){
    return acc.concat(c);
}