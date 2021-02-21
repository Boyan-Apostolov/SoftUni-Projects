const numberOperations = {
    powNumber: function (num) {
        return num * num;
    },
    numberChecker: function (input) {
        input = Number(input);

        if (isNaN(input)) {
            throw new Error('The input is not a number!');
        }

        if (input < 100) {
            return 'The number is lower than 100!';
        } else {
            return 'The number is greater or equal to 100!';
        }
    },
    sumArrays: function (array1, array2) {

        const longerArr = array1.length > array2.length ? array1 : array2;
        const rounds = array1.length < array2.length ? array1.length : array2.length;

        const resultArr = [];

        for (let i = 0; i < rounds; i++) {
            resultArr.push(array1[i] + array2[i]);
        }

        resultArr.push(...longerArr.slice(rounds));

        return resultArr
    }
};

const { assert } = require('chai')

describe("Tests", function () {
    describe("powNumber", function () {
        it("works", function () {
            assert.equal(numberOperations.powNumber(2), 4)
            assert.equal(numberOperations.powNumber(-1), 1)
            assert.equal(numberOperations.powNumber(0), 0)
            assert.equal(numberOperations.powNumber(3.3), 10.889999999999999)
        });
    });
    describe("numberChecker", function () {
        it("works", function () {
            assert.doesNotThrow(() => { numberOperations.numberChecker(1) })
            assert.doesNotThrow(() => { numberOperations.numberChecker(0) })
            assert.doesNotThrow(() => { numberOperations.numberChecker(-5) })
        });
        it('throws', () => {
            assert.throws(() => { numberOperations.numberChecker({}) }, 'The input is not a number!')
            assert.throws(() => { numberOperations.numberChecker(["a"]) }, 'The input is not a number!')
            assert.throws(() => { numberOperations.numberChecker("a") }, 'The input is not a number!')
            assert.throws(() => { numberOperations.numberChecker(undefined) }, 'The input is not a number!')
        })
        it('lower than 100', () => {
            assert.equal(numberOperations.numberChecker(1), 'The number is lower than 100!')
            assert.equal(numberOperations.numberChecker(0), 'The number is lower than 100!')
            assert.equal(numberOperations.numberChecker(-1), 'The number is lower than 100!')
        })
        it('greater than 100', () => {
            assert.equal(numberOperations.numberChecker(100), 'The number is greater or equal to 100!')
            assert.equal(numberOperations.numberChecker(200), 'The number is greater or equal to 100!')
            assert.equal(numberOperations.numberChecker(300), 'The number is greater or equal to 100!')
        })
    });
    describe("Sum arrays", () => {
        it("works", () => {
            let arr1 = [1, 1, 1];
            let arr2 = [1, 1, 1];

            assert.deepEqual(numberOperations.sumArrays(arr1, arr2), [2, 2, 2])

            let arr3 = [1, 1, 1, 3];
            let arr4 = [1, 1, 1];

            assert.deepEqual(numberOperations.sumArrays(arr3, arr4), [2, 2, 2, 3])

            let arr5 = [1, 1, 1];
            let arr6 = [1, 1, 1, 3];

            assert.deepEqual(numberOperations.sumArrays(arr5, arr6), [2, 2, 2, 3])
        })
    })
});
