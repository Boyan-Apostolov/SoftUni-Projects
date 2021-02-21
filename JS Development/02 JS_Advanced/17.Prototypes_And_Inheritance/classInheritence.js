class Person {
    constructor(name) {
        this.name = name;
    }
    sayHi = function () {
        console.log(`${this.name} says hi.`)
    }
}

class Employee extends Person {
    constructor(name, salary) {
        super(name); //like .base
        this.salary = salary;
    }
    
    collectSalary() {
        console.log(`${this.name} collected ${this.salary}`);
    }
}
Employee.prototype = Object.create(Person.prototype);

function printName(person) {
    console.log(person.name)
}

let employee = new Employee('Peter', 3000)
employee.collectSalary()
let person = new Person('John');
let literal = {
    name: 'Mary'
}
printName(employee)
printName(person)
printName(literal)