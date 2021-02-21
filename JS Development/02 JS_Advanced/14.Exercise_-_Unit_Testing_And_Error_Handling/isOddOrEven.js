function isOddOrEven(string) {
    if (typeof (string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

const assert = require('chai').assert;

describe('check isOddOrEven', () => {
    it('Type is string', () => {
        assert.equal(isOddOrEven(1), undefined)
    })
    it('Is even', () => {
        assert.equal(isOddOrEven('aa'), 'even')
    })
    it('Is odd', () => {
        assert.equal(isOddOrEven('a'), 'odd')
    })
})
