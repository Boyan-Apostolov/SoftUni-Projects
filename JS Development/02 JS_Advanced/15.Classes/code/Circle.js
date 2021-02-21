class Circle {
    constructor(radius) {
        this.r = radius;
    }

    get diameter() {
        return this.r * 2;
    }

    set diameter(value) {
        if(typeof value != 'number'){return new TypeError('Diameter must be a number')}
        return this.r = value / 2;
    }

    get area(){
        return this.r **2 * Math.PI
    }
}
const myCircle = new Circle(4);
console.log(myCircle.diameter)
myCircle.diameter = 6;
console.log(myCircle.diameter)