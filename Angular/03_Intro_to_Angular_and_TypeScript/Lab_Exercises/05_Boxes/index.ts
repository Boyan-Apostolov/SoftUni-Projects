class Box<T>{
    private box: T[];
    constructor(){
        this.box = new Array<T>();
        this.count = 0;
    }
    public count:number;
    add(element:T){
        this.box.push(element);
        this.count++;
    }
    remove(){
        this.box.shift;
        this.count--;
    }
}
let box = new Box<Number>();
box.add(1);
box.add(2);
box.add(3);
console.log(box.count);
console.log('------');
let box2 = new Box<String>();
box2.add("Pesho");
box2.add("Gosho");
console.log(box2.count);
box2.remove();
console.log(box2.count);

