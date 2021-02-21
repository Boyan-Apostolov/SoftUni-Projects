function solve(input){
    let result = {};
    for(let i = 0; i < input.length; i+=2){
        result[input[i]] = input[i+1];
    }
    return result
}
console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']))