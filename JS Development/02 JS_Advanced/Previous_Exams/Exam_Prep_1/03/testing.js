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



const { assert } = require('chai')

describe("Pizza Uni tests", function () {
    describe("make an order", function () {
        it("throw error on not pizza", function () {
            let pizza = {
                orderedDrink: 'the name of the drink'
            };

            assert.throws(() => { pizzUni.makeAnOrder(pizza) }, Error)
        });
        it('works', () => {
            let pizza = {
                orderedPizza: 'the name of the pizza',
                orderedDrink: 'the name of the drink'
            };

            assert.doesNotThrow(() => { pizzUni.makeAnOrder(pizza) })
            let result = pizzUni.makeAnOrder(pizza);
            assert.equal(result, 'You just ordered the name of the pizza and the name of the drink.')
        })
    });

    describe('GetRemainingWork', () => {
        it('all complete', () => {
            let arr = [{ pizzaName: 'the name of the pizza', status: 'ready' }]

            assert.equal(pizzUni.getRemainingWork(arr), 'All orders are complete!')
        })
        it('works with preparing', () => {
            let arr = [{ pizzaName: 'the name of the pizza', status: 'preparing' }]

            assert.equal(pizzUni.getRemainingWork(arr), `The following pizzas are still preparing: the name of the pizza.`)
        })
    })

    describe('Order type', () => {
        it('delivery sum', () => {
            let type = 'Delivery';

            assert.equal(pizzUni.orderType(100,type),100)
            assert.equal(pizzUni.orderType(0,type),0)
            assert.equal(pizzUni.orderType(-100,type),-100)
        });
        it('caryy out sum', () => {
            let type = 'Carry Out';

            assert.equal(pizzUni.orderType(100,type),90)
            assert.equal(pizzUni.orderType(0,type),0)
            assert.equal(pizzUni.orderType(-100,type),-90)
            assert.equal(pizzUni.orderType(1.2,type),1.08)
        });
    });
});
