function cookingNumbers(num, com1, com2, com3, com4, com5) {
    let number = +num; //Number(num)
    const array = [com1, com2, com3, com4, com5];

    for (let i = 0; i < array.length; i++) {
        switch (array[i]) {
            case 'chop': number /= 2; console.log(number); break;
            case 'dice': number = Math.sqrt(number); console.log(number); break;
            case 'spice': number++; console.log(number); break;
            case 'bake': number *= 3; console.log(number); break;
            case 'fillet': number -= number * 0.2; console.log(number); break;
        }
    }
}
cookingNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');