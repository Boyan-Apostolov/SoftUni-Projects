function RGBtoHEX(...rgb) {
    if (rgb.some(c => typeof (c) != 'number' || c < 0 || c > 255)) { return undefined }

    return '#' + rgb.map(decToHex).join('').toUpperCase()

    function decToHex(n) {
        return ('00' + n.toString(16)).slice(-2);
    }
}
module.exports = RGBtoHEX;