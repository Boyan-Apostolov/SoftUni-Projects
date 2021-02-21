const { assert } = require("chai");

class Repository {
    constructor(props) {
        this.props = props;
        this.data = new Map();

        let id = 0;
        this.nextId = function () {
            return id++;
        }
    }

    get count() {
        return this.data.size;
    }

    add(entity) {
        this._validate(entity);
        let id = this.nextId();
        this.data.set(id, entity);
        return id;
    }

    getId(id) {
        if (!this.data.has(id)) {
            throw new Error(`Entity with id: ${id} does not exist!`);
        }

        return this.data.get(id);
    }

    update(id, newEntity) {
        if (!this.data.has(id)) {
            throw new Error(`Entity with id: ${id} does not exist!`);
        }

        this._validate(newEntity);
        this.data.set(id, newEntity);
    }

    del(id) {
        if (!this.data.has(id)) {
            throw new Error(`Entity with id: ${id} does not exist!`);
        }

        this.data.delete(id);
    }

    _validate(entity) {
        //Validate existing property
        for (let propName in this.props) {
            if (!entity.hasOwnProperty(propName)) {
                throw new Error(`Property ${propName} is missing from the entity!`);
            }
        }

        //Validate property type
        for (let propName in entity) {
            let val = entity[propName];
            if (typeof val !== this.props[propName]) {
                throw new TypeError(`Property ${propName} is not of correct type!`);
            }
        }
    }
}

module.exports = { Repository };

describe("Tests …", function () {
    describe("Constructor", function () {
        it("Correct", function () {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };

            let repo = new Repository(properties);

            assert.deepEqual(repo.props, properties)
            assert.equal(repo.nextId(), 0)
            assert.equal(repo.count, 0)
        });
    });
    describe('add', () => {
        it('ok', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            assert.equal(repo.add(entity), 0)
            assert.equal(repo.add(entity), 1)
            assert.deepEqual(repo.data.get(0).name, 'Pesho')

        })
        it('throws', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);

            let entityName = {
                test: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            assert.throws(() => { repo.add(entityName) })

            let entityAge = {
                name: "Pesho",
                test: 22,
                birthday: new Date(1998, 0, 7)
            };
            assert.throws(() => { repo.add(entityTest) })

            let entityBirth = {
                name: "Pesho",
                age: 22,
                test: new Date(1998, 0, 7)
            };
            assert.throws(() => { repo.add(entityBirth) })

            let missingEntity = {}
            assert.throws(() => { repo.add(missingEntity) })

            ///Incorrect types:
            let entityNameInc = {
                name: 1,
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            assert.throws(() => { repo.add(entityNameInc) })

            let entityAgeInv = {
                name: "Pesho",
                age: "Pesho",
                birthday: new Date(1998, 0, 7)
            };
            assert.throws(() => { repo.add(entityAgeInv) })

            let entityBirthInv = {
                name: "Pesho",
                age: 22,
                age: "Test"
            };
            assert.throws(() => { repo.add(entityBirthInv) })

        })
    })
    describe('getId', () => {
        it('works', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            assert.equal(repo.add(entity), 0)

            let expectedResult = { name: 'Pesho', age: 22, birthday: new Date(1998, 01, 06, 22, 00, 00) }

            assert.equal(repo.getId(0).name, expectedResult.name)
            assert.equal(repo.getId(0).age, expectedResult.age)
        })
    })
    describe('update', () => {
        it('works', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repo.add(entity)

            let entity2 = {
                name: "Gosho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repo.update(0, entity2);
            assert.equal(repo.getId(0).name, "Gosho")
        })
        it("throws", () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);

            assert.throws(() => { repo.update(1, {}) })
        })
    })
    describe("delete", () => {
        it('works', () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            repo.add(entity)
            repo.del(0)
            assert.equal(repo.count,0)
        })
        it("throws", () => {
            let properties = {
                name: "string",
                age: "number",
                birthday: "object"
            };
            let repo = new Repository(properties);

            assert.throws(() => { repo.del(1) })
        })
    })
    // TODO: …
});


// // Initialize props object
// let properties = {
//     name: "string",
//     age: "number",
//     birthday: "object"
// };
// //Initialize the repository
// let repository = new Repository(properties);
// // Add two entities
// let entity = {
//     name: "Pesho",
//     age: 22,
//     birthday: new Date(1998, 0, 7)
// };
// repository.add(entity); // Returns 0
// repository.add(entity); // Returns 1
// console.log(repository.getId(0));
// // {"name":"Pesho","age":22,"birthday":"1998-01-06T22:00:00.000Z"}
// console.log(repository.getId(1));
// // {"name":"Pesho","age":22,"birthday":"1998-01-06T22:00:00.000Z"}
// //Update an entity
// entity = {
//     name: 'Gosho',
//     age: 22,
//     birthday: new Date(1998, 0, 7)
// };
// repository.update(1, entity);
// console.log(repository.getId(1));
// // {"name":"Gosho","age":22,"birthday":"1998-01-06T22:00:00.000Z"}
// // Delete an entity
// repository.del(0);
// console.log(repository.count); // Returns 1
// let anotherEntity = {
//     name1: 'Stamat',
//     age: 29,
//     birthday: new Date(1991, 0, 21)
// };
// // repository.add(anotherEntity); // should throw an Error
// anotherEntity = {
//     name: 'Stamat',
//     age: 29,
//     birthday: 1991
// };
// // repository.add(anotherEntity); // should throw a TypeError
// // repository.del(-1); // should throw Error for invalid id