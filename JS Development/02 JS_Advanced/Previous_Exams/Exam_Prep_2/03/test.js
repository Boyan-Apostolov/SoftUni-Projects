
let dealership = {
    newCarCost: function (oldCarModel, newCarPrice) {

        let discountForOldCar = {
            'Audi A4 B8': 15000,
            'Audi A6 4K': 20000,
            'Audi A8 D5': 25000,
            'Audi TT 8J': 14000,
        }

        if (discountForOldCar.hasOwnProperty(oldCarModel)) {
            let discount = discountForOldCar[oldCarModel];
            let finalPrice = newCarPrice - discount;
            return finalPrice;
        } else {
            return newCarPrice;
        }
    },

    carEquipment: function (extrasArr, indexArr) {
        let selectedExtras = [];
        indexArr.forEach(i => {
            selectedExtras.push(extrasArr[i])
        });

        return selectedExtras;
    },

    euroCategory: function (category) {
        if (category >= 4) {
            let price = this.newCarCost('Audi A4 B8', 30000);
            let total = price - (price * 0.05)
            return `We have added 5% discount to the final price: ${total}.`;
        } else {
            return 'Your euro category is low, so there is no discount from the final price!';
        }
    }
}


const { assert } = require('chai')

describe("Tests …", function () {
    describe("newCarCost", function () {

        it("no discount", function () {
            assert.equal(dealership.newCarCost('a', 30000), 30000)
            assert.equal(dealership.newCarCost('a', 15000), 15000)
        });
        it("dicount", () => {
            assert.equal(dealership.newCarCost('Audi A4 B8', 30000), 15000)
            assert.equal(dealership.newCarCost('Audi A4 B8', 15000), 0)
        })
    });

    describe("carEquipment", () => {
        it("correct", () => {
            let arr = ['a', 'b', 'c'];
            assert.deepEqual(dealership.carEquipment(arr, [0]), ['a'])
            assert.deepEqual(dealership.carEquipment(arr, [0, 1]), ['a', 'b'])
            assert.deepEqual(dealership.carEquipment(arr, [0, 1, 2]), ['a', 'b', 'c'])
        })
    });

    describe("euroCategory", () => {
        it("category above 4", () => {
            assert.equal(dealership.euroCategory(5),'We have added 5% discount to the final price: 14250.')
            assert.equal(dealership.euroCategory(6),'We have added 5% discount to the final price: 14250.')
        })
        it("category bellow 4",()=>{
            assert.equal(dealership.euroCategory(1),'Your euro category is low, so there is no discount from the final price!')
            assert.equal(dealership.euroCategory(2),'Your euro category is low, so there is no discount from the final price!')
        })

        it("category at 4", () => {
            assert.equal(dealership.euroCategory(4),'We have added 5% discount to the final price: 14250.')
        })
    });
});
