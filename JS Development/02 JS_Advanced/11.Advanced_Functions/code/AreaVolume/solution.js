function solve(area, vol, dataAsJSON) {
    const figures = JSON.parse(dataAsJSON);
    return figures.map(figure => ({
        area: Math.abs(area.call(figure)),
        volume: Math.abs(vol.call(figure))
    }));
}
function area() {
    return this.x * this.y;
};

function vol() {
    return this.x * this.y * this.z;
};

const example1 = `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`

console.log(solve(area, vol, example1))