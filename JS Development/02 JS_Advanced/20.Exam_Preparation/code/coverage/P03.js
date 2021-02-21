let pizzUni = {
    makeAnOrder: function (obj) {

        if (!obj.orderedPizza) {
            throw new Error('You must order at least 1 Pizza to finish the order.');
        } else {
            let result = `You just ordered ${obj.orderedPizza}`
            if (obj.orderedDrink) {
                result += ` and ${obj.orderedDrink}.`
            }
            return result;
        }
    },

    getRemainingWork: function (statusArr) {

        const remainingArr = statusArr.filter(s => s.status != 'ready');

        if (remainingArr.length > 0) {

            let pizzaNames = remainingArr.map(p => p.pizzaName).join(', ')
            let pizzasLeft = `The following pizzas are still preparing: ${pizzaNames}.`

            return pizzasLeft;
        } else {
            return 'All orders are complete!'
        }

    },

    orderType: function (totalSum, typeOfOrder) {
        if (typeOfOrder === 'Carry Out') {
            totalSum -= totalSum * 0.1;

            return totalSum;
        } else if (typeOfOrder === 'Delivery') {

            return totalSum;
        }
    }
}

const { assert } = require('chai');


describe("Unit testing", function () {

    it("Make order", function () {
        let pizza = { orderPizza: 'pizza', orderedDrink: 'drink' };
        let pizza1 = { orderedDrink: 'drink' };
        let pizza2 = { orderPizza: 'pizza' };
        let pizza3 = {};

        assert.throw(() => pizzUni.makeAnOrder(pizza1), 'You must order at least 1 Pizza to finish the order.')
        assert.throw(() => pizzUni.makeAnOrder(pizza3), 'You must order at least 1 Pizza to finish the order.')

        assert.equal(pizzUni.makeAnOrder(pizza2), `You just ordered ${pizza2.orderedPizza}`)
        assert.equal(pizzUni.makeAnOrder(pizza), `You just ordered ${pizza.orderedPizza} and ${pizza.orderedDrink}.`)
    });

    it('Get remaining work', () => {
        let statusArr = [
            { pizzaName: 'pizza', status: 'ready' },
            { pizzaName: 'pizza2', status: 'preparing' },
            { pizzaName: 'pizza3', status: 'preparing' }]

        let statusArr2 = [
            { pizzaName: 'pizza', status: 'ready' },
            { pizzaName: 'pizza3', status: 'preparing' }]

        let statusArr3 = [
            { pizzaName: 'pizza', status: 'preparing' },
            { pizzaName: 'pizza3', status: 'preparing' }]

        assert.equal(pizzUni.getRemainingWork(statusArr2), 'All orders are complete!')
        assert.equal(pizzUni.getRemainingWork(statusArr), `The following pizzas are still preparing: pizza3, pizza4.`)
        assert.equal(pizzUni.getRemainingWork(statusArr3), `The following pizzas are still preparing: pizza, pizza4.`)
    });

    it('Order type', () => {
        let orderTypeDelivery = 'Delivery';
        let orderTypeCarryOut = 'Carry Out';

        let totalSum = 100;
        let totalSum1 = -100;
        let totalSum2 = 0;

        assert.equal(pizzUni.orderType(totalSum, orderTypeDelivery), 100)
        assert.equal(pizzUni.orderType(totalSum, orderTypeCarryOut), 90)

        assert.equal(pizzUni.orderType(totalSum1, orderTypeDelivery), -100)
        assert.equal(pizzUni.orderType(totalSum1, orderTypeCarryOut), -90)

        assert.equal(pizzUni.orderType(totalSum2, orderTypeDelivery), 0)
        assert.equal(pizzUni.orderType(totalSum2, orderTypeCarryOut), 0)
    })
});

