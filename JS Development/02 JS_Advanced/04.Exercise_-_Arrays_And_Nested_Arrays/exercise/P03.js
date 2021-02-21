function solve(commands){
    let number = 1;
    let result = [];
    for (const command of commands) {
        if(command === 'add'){
            result.push(number);
        }
        else if(command === 'remove'){
            result.pop();
        }
        number++;
    }
    return result.length != 0 ? result.join('\n') : 'Empty'
}
console.log(solve(['add', 
'add', 
'add', 
'add']
))