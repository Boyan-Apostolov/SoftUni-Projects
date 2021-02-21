//greeting(['Svetlin Nakov']);
function areaAndPerimeterOfCircle([radiusAsStr]) {
    var radius = Number(radiusAsStr);

    var area = Math.PI * radius * radius;
    console.log(`Area = ${area}`);

    var perimeter = 2 * Math.PI * radius;
    console.log(`Perimeter = ${perimeter}`);
}
