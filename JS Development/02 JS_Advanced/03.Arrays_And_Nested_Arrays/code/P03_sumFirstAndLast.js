function sumFirstAndLast(inputArr) {
    let first = Number(inputArr.shift());
    let last = Number(inputArr.pop());
    return first + last;
}
console.log(sumFirstAndLast(['20', '30', '40']));
console.log(sumFirstAndLast(['5', '10']));
