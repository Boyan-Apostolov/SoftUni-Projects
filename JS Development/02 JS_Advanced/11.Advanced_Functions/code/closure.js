function createCounter() {
    let count = 0;
    return function() {
        count++;
        console.log(count);
    }
}

let myCounter = createCounter();
myCounter()
myCounter()
myCounter()
myCounter()
myCounter()
myCounter()
myCounter()
myCounter()
myCounter()