//Min max avg sum..
let myArr = [7, 6, 1, 5, 2, 13];
let moreNumbers = [5, 8, 11, 0, 4];

let sum = myArr.reduce((acc, c) => acc + c, 0);
let avg = myArr.reduce((acc, c, i, a) => acc + c / a.length, 0);
let max = myArr.reduce((acc, c) => Math.max(acc, c))


