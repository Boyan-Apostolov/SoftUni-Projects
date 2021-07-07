var Box = /** @class */ (function () {
    function Box() {
        this.box = new Array();
        this.count = 0;
    }
    Box.prototype.add = function (element) {
        this.box.push(element);
        this.count++;
    };
    Box.prototype.remove = function () {
        this.box.shift;
        this.count--;
    };
    return Box;
}());
var box = new Box();
box.add(1);
box.add(2);
box.add(3);
console.log(box.count);
console.log('------');
var box2 = new Box();
box2.add("Pesho");
box2.add("Gosho");
console.log(box2.count);
box2.remove();
console.log(box2.count);
