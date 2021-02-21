class Person {
    constructor(firstName, lastName, age, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.email = email;
    }
    toString() {
        return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`
    }
}
let person = new Person('Anna', 'Simpson', 22, 'anna@yahoo.com');
//console.log(person.toString());
const цонзоле = new class gero {лог(текст) {console.log(текст)}};

//цонзоле.лог('хелло')

class myClass{
    constructor(){
        this.name = 'static name'
    }
    static myMethod(){
        console.log('hi from static method')
    }
} 