function solve(names){
    return names.sort((a,b)=> a.localeCompare(b)).map((_,index,arr)=>{return `${index+1}.${arr[index]}`}).join('\n')
}
console.log(solve(["John", "Bob", "Christina", "Ema"]))