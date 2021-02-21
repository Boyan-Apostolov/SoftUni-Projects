let sum = require('./demo');
let { expect } = require('chai')

describe('Sum Tests', () => {
    it('Works correct', () => {
        expect(sum(1, 1)).to.equal(2)
    })

    it('Works correct with one string', () => {
        expect(sum('1', 1)).to.equal(2)
    })

    it('Works correct with two strings', () => {
        expect(sum('1', '1')).to.equal(2)
    })

    it('doesnt work with one string', () => {
        expect(sum('a', 1)).to.false
    })

    it('doesnt work with two strings', () => {
        expect(sum('a', 'a')).to.false
    })

    it('doesnt work with two strings', () => {
        expect(sum('a', 'a')).to.false
    })
})