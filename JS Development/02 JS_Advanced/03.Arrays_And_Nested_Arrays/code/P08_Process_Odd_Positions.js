function solve(arr){
    let result = arr.filter((num,index)=> {return index % 2 !== 0});
    let doubled = result.map(x=> x*2);
    return doubled.reverse().join(' ');
}
console.log(solve([10, 15, 20, 25]))
console.log(solve([3, 0, 10, 4, 7, 3]))