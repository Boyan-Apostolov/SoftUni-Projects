function divisor(a,b){
    while(b != 0){
        let temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}
console.log(divisor(15, 5));
console.log(divisor(2154, 458));