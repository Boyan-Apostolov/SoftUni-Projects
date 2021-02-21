function someStupidExercise(inputNumbers) {
    let currentNum = inputNumbers[0];
    let counter = 1;

    while (currentNum < 1 || currentNum > 100) {
        console.log('Invalid number.');
        currentNum = inputNumbers[counter];
        counter++;
    }
    console.log('Valid number: ' + currentNum);
}
