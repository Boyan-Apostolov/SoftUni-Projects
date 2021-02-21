const sum = require('./sumNumbers.js')
const { expect } = require('chai')

describe('Sum tests', () => {
    it('sums single number', () => {
        expect(sum([1])).to.equal(1)
    })

    it('sums 2 numbers', () => {
        expect(sum([1, 1])).to.equal(2)
    })

    it('sums 3 numbers', () => {
        expect(sum([1, 1, 1])).to.equal(3)
    })
})