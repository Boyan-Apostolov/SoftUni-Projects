const { expect } = require('chai')

const rgbToHexColor = require('./RGBtoHEX.js')

describe('RGBtoHEX', () => {
    it('converts black to hex', () => {
        expect(rgbToHexColor(0, 0, 0)).to.equal('#000000')
    });

    it('converts white to hex', () => {
        expect(rgbToHexColor(255, 255, 255)).to.equal('#FFFFFF')
    });

    it('converts red to hex', () => {
        expect(rgbToHexColor(255, 0, 0)).to.equal('#FF0000')
    });

    it('converts green to hex', () => {
        expect(rgbToHexColor(0, 255, 0)).to.equal('#00FF00')
    });

    it('converts blue to hex', () => {
        expect(rgbToHexColor(0, 0, 255)).to.equal('#0000FF')
    });

    it('returns undefined to string params', () => {
        expect(rgbToHexColor('a', 'a', 'a')).to.be.undefined
    });

    it('returns undefined for negative', () => {
        expect(rgbToHexColor(0, 0, -1)).to.be.undefined
    });

    it('returns undefined for greater than 255', () => {
        expect(rgbToHexColor(0, 0, 256)).to.be.undefined
    });

    it('converts (151, 104, 172) to hex', () => {
        expect(rgbToHexColor(151, 104, 172)).to.equal('#9768AC')
    });
});