function sameNumbers(number) {
    const string = number.toString();

    let sum = 0;
    let isSame = true;

    for (let i = 0; i < string.length; i++) {
        sum += Number(string[i]);

        if (string[i] !== string[i + 1] && string[i + 1] != undefined) {
            isSame = false;
        }
    }

    console.log(isSame)
    console.log(sum);
}
sameNumbers(2222222)
sameNumbers(1234)