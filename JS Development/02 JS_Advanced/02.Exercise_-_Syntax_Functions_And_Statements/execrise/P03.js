function sameNumbers(num) {
    let numAsStr = num.toString();
    let sum = 0;
    let isSame = true;
    let i = 0;
        for (let i = 0; i < numAsStr.length; i++) {
            sum += Number(numAsStr[i])
            if(i == numAsStr.length - 1){
               continue; 
            }
            if(numAsStr[i] != numAsStr[i+1]){
                isSame = false;
            }            
        }

    return `${isSame}\n${sum}`
}
console.log(sameNumbers(2222222))
console.log(sameNumbers(1234))