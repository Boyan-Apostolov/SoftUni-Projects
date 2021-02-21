class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }
    get x(){
        return this._x;
    }
    set x(value) {
        if(typeof value != 'number'){
            throw new TypeError('X coordinate must be number')
        }
        this._x = value;
    }

    get y(){
        return this._y;
    }
    set y(value) {
        if(typeof value != 'number'){
            throw new TypeError('Y coordinate must be number')
        }
        this._y = value;
    }

    static distance(a, b) {
        if (a instanceof Point == false || b instanceof Point == false) {
            throw new TypeError('Parameter must be of type point.')
        }
        return Math.sqrt((a.x - b.x) ** 2 + (a.y - b.y) ** 2)
    }
}
const p1 = new Point(0, 0);
const p2 = new Point(4, 3);

p1.x='s'

console.log(Point.distance(p1, p2))