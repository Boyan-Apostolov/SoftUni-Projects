function solve([n]){
    let isPrime = true;
    for (let index = 2; index < n; index++) {
    if(n % index === 0){
        isPrime = false;
break;
    }
    }
    console.log(isPrime)

}
solve([1324])