const { expect } = require('chai')
const isSymmetric = require('./checkForSymmetry.js')

describe('isSymetric', () => {
    it('returns true for valid symmetric input', () => {
        expect(isSymmetric([1, 1])).to.be.true;
    });

    it('returns false for valid non-symmetric input', () => {
        expect(isSymmetric([1, 2])).to.be.false;
    });

    it('returns false for invalid input', () => {
        expect(isSymmetric('a')).to.be.false;
    });

    //Test overloading
    it('returns true for valid symmetric odd element array', () => {
        expect(isSymmetric([1,1,1])).to.be.true;
    });

    it('returns true for valid symmetric string element array', () => {
        expect(isSymmetric(['a','a'])).to.be.true;
    });

    it('returns false for valid non-symmetric string element array', () => {
        expect(isSymmetric(['a','b'])).to.be.false;
    });

    it('returns false for type coerced elements', () => {
        expect(isSymmetric([1,'b'])).to.be.false;
    });
})