function solve(array){
    let biggestElement = Number.NEGATIVE_INFINITY;
    for(i = 0; i <= array.length - 1; i++){
        for(let k =0; k <= array.length; k++){
            if(array[i][k] > biggestElement){
                biggestElement = array[i][k];
            }
        }
    }
    return biggestElement;
}
console.log(solve([[20, 50, 10],
                   [8, 33, 145]]
   ));

console.log(solve([[3, 5, 7, 12],
                [-1, 4, 33, 2],
                [8, 3, 0, 4]]
            ))
