function sumSeconds([arg1, arg2, arg3]) {
    let first = Number(arg1);
    let second = Number(arg2);
    let third = Number(arg3);

    let secondsSum = first + second + third;

    let minutes = Math.floor(secondsSum / 60);
    let seconds = secondsSum % 60;

    if (seconds < 10) {
        console.log(minutes + ":0" + seconds);
    }
    else {
        console.log(`${minutes}:${seconds}`);
    }
}
