function sum(a, b) {
    if (!Number(a)) { return false }
    if (!Number(b)) { return false }
    return +a + +b;
}
module.exports = sum;