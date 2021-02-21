function sortNames(names) {
    let result = '';
    let resultingArray = names.sort((a, b) => a.localeCompare(b)).map((el,index)=> {
        return `${index+1}.${names[index]}`
    });
    // for (let i = 1; i <= names.length; i++) {
    //     result += `${i}.${names[i - 1]}` + '\n';
    // }
    // return result
    return resultingArray.join('\n');
}
console.log(sortNames(["John", "Bob", "Christina", "Ema"]));
