function solve(numbers){
    numbers.sort((a,b)=>{return a-b})
    let result = []
    while(numbers.length){
        let currSmallest = numbers.shift()
        let currBiggest = numbers.pop()
        result.push(currSmallest);
        result.push(currBiggest)
    }
    return result;
}
console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]))