function checkAge([arg1, arg2]) {
    let age = Number(arg1);
    let gender = arg2;

    if (gender === 'f') {
        if (age < 16) {
            console.log('Mis');
        } else {
            console.log('Mrs.');
        }
    } else {
        if (age < 16) {
            console.log('Master');
        } else {
            console.log('Mr.');
        }
    }
}
