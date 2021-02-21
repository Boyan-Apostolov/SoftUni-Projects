function pointInRectangle([x1, y1, x2, y2, x, y]) {
    let leftSide = Math.min(x1, x2);
    let rightSide = Math.max(x1, x2);
    let topSide = Math.min(y1, y2);
    let bottomSide = Math.max(y1, y2);

    let isInside = x > leftSide && x < rightSide && y < bottomSide && y > topSide;
    let isOutside = x < leftSide || x> rightSide || y > bottomSide || y < top;

    let isInsideOutside = isInside || isOutside;

    if (!isInsideOutside) {
        console.log('Border');
    }else{
        console.log('Inside/Outside');
    }
}
