function Person(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
}
Person.prototype.write = function (message) {
    console.log(message)
}
function newOperator(constructor, ...params) {
    let result = {};

    constructor.apply(result, params);

    return result;
}
const myPerson = newOperator(Person, 'John', 'Abbot')
myPerson.hasOwnProperty('write') //false