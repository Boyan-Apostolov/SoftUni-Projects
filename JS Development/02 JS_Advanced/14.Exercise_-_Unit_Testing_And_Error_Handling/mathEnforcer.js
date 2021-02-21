let mathEnforcer = {
    addFive: function (num) {
        if (typeof (num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof (num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof (num1) !== 'number' || typeof (num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};
const assert = require('chai').assert;

describe('math enforcer', () => {
    it('addfive with string', () => {
        assert.isUndefined(mathEnforcer.addFive('string'))
        assert.isUndefined(mathEnforcer.addFive(undefined))
    })
    // it('addfive with NaN', () => {
    //     //assert.isNaN(mathEnforcer.addFive(NaN))
    // })
    it('addfive correct', () => {
        assert.equal(mathEnforcer.addFive(1), 6)
        assert.equal(mathEnforcer.addFive(0), 5)
        assert.equal(mathEnforcer.addFive(-5), 0)
        assert.equal(mathEnforcer.addFive(1.2), 6.2)
    })

    it('subtractTen with string', () => {
        assert.isUndefined(mathEnforcer.subtractTen('string'))
        assert.isUndefined(mathEnforcer.subtractTen(undefined))
    })

    it('subtractTen correct', () => {
        assert.equal(mathEnforcer.subtractTen(0), -10)
        assert.equal(mathEnforcer.subtractTen(-5), -15)
        assert.equal(mathEnforcer.subtractTen(10.2), 0.1999999999999993)
        assert.equal(mathEnforcer.subtractTen(1), -9)
        assert.equal(mathEnforcer.subtractTen(10), 0)
        assert.equal(mathEnforcer.subtractTen(20), 10)
    })

    it('sum', () => {
        assert.isUndefined(mathEnforcer.sum('string', 2))
        assert.isUndefined(mathEnforcer.sum(2, 'string'))
    })

    it('sum correct', () => {
        assert.equal(mathEnforcer.sum(1, 1), 2)
        assert.equal(mathEnforcer.sum(1, -1), 0)
        assert.equal(mathEnforcer.sum(1, 0), 1)
        assert.equal(mathEnforcer.sum(-1, -1), -2)
        assert.equal(mathEnforcer.sum(-1.3, -1.2), -2.5)
        assert.equal(mathEnforcer.sum(1.3, -1.2), 0.10000000000000009)
    })
})