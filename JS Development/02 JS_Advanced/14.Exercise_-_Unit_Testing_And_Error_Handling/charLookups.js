function lookupChar(string, index) {
    if (typeof (string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

const assert = require('chai').assert;

describe('lookupChar', () => {
    it('tests1', () => {
        assert.isUndefined(lookupChar(1, 1))
        assert.isUndefined(lookupChar('aaaaa', 1.2))
        assert.isUndefined(lookupChar('abc', 'a'))
    })
    it('tests2', () => {
        assert.equal(lookupChar('abc', -1), 'Incorrect index')
        assert.equal(lookupChar('abc', 4), 'Incorrect index')
    })
    it('tests3', () => {
        assert.equal(lookupChar('abc', 0), 'a')
        assert.equal(lookupChar('abc', 1), 'b')
    })
})