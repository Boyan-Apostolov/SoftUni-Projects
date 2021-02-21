function histogram(arguments) {
    let firstRange = 0;
    let secondRange = 0;
    let thirdRange = 0;
    let forthRange = 0;
    let fifthRange = 0;
    for (let i = 1; i < arguments.length; i++) {
        let currentNum = Number(arguments[i]);
        if (currentNum < 200) {
            firstRange++;
        } else if (currentNum < 400) {
            secondRange++;
        } else if (currentNum < 600) {
            thirdRange++;
        } else if (currentNum < 700) {
            forthRange++;
        } else {
            forthRange++;
        }
    }
    console.log(`${(firstRange / (arguments - 1) * 100).toFixed(2)}`);
    console.log(`${(secondRange / (arguments - 1) * 100).toFixed(2)}`);
    console.log(`${(thirdRange / (arguments - 1) * 100).toFixed(2)}`);
    console.log(`${(forthRange / (arguments - 1) * 100).toFixed(2)}`);
    console.log(`${(fifthRange / (arguments - 1) * 100).toFixed(2)}`);
}
