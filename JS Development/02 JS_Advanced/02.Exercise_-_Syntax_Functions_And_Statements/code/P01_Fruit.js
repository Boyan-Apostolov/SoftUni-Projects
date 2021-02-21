function fruit(fruit, weight, price) {
    let kilos = weight / 1000;
    let money = price * kilos;
    return `I need $${money.toFixed(2)} to buy ${kilos.toFixed(2)} kilograms ${fruit}.`
}
console.log(fruit('orange', 2500, 1.80))