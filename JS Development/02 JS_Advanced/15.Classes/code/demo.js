class MyClass {
    constructor(name) {
        this.name = name;
    }
    sayHi(){
        console.log(`${this.name} says hi!`)
    }
}

const myInstance = new MyClass('Peter');
//myInstance.sayHi()