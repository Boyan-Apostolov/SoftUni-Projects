const { sum } = require('./myModule');
const { expect } = require('chai');

describe('Sum function', () => {
    it('it Works with numbers ', () => {
        expect(sum(1, 2)).to.equal(3)
    });

    it('it Works with numbers as strings', () => {
        expect(sum('1', '2')).to.equal(3)
    });

    it('returns Nan With invalid values', ()=>{
        expect(sum('a','a')).to.be.NaN;
    })
});