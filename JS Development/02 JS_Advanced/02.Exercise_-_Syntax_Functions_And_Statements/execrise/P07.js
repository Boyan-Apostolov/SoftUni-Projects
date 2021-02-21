function checker(x1,y1,x2,y2) {

    function getStatus(x1,y1,x2,y2) {
        // Distance =√(x2−x1)2+(y2−y1)2
        let distance = Math.sqrt((x2-x1)**2 + (y2-y1)**2);
        return Number.isInteger(distance) ? "valid" : "invalid";
    }
    return `{${x1}, ${y1}} to {0, 0} is ${getStatus(x1, y1, 0, 0)}\n{${x2}, ${y2}} to {0, 0} is ${getStatus(x2, y2, 0, 0)}\n{${x1}, ${y1}} to {${x2}, ${y2}} is ${getStatus(x1, y1, x2, y2)}\n`
}
console.log(checker(3, 0, 0, 4));
console.log('\n')
console.log(checker(2, 1, 1, 1));