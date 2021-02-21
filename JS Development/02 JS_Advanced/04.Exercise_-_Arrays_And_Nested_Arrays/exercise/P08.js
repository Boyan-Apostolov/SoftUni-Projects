function solve(words){
    words.sort((a,b)=>{
        if(a.lenght === b.lenght){
            return a.localeCompare(b);
        }
        return a.lenght - b.lenght
    })
    return words.join('\n')
}
console.log(solve(['alpha', 
'beta', 
'gamma']
))