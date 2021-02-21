function solve(juices) {
    let resultArr = {};
    let finalArr = {};
    for (let juice of juices) {
        let [name, quantity] = juice.split(' => ')
        quantity = Number(quantity);

        if (!resultArr[name]) {
            resultArr[name] = 0;
        }
        resultArr[name] += quantity;
        if (resultArr[name] >= 1000) {
            finalArr[name] = resultArr[name];
        }
    }
    let result = [];
    for (const juice in finalArr) {
        if (Math.floor(finalArr[juice] / 1000) > 0)
            result.push(`${juice} => ${Math.floor(finalArr[juice] / 1000)}`)
    }
    return result.join('\n')
}
console.log(solve(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']
))
console.log('------')
console.log(solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
))