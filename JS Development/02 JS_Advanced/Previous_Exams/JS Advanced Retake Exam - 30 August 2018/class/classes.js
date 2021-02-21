class Vacationer {
    constructor(name, creditCardDetails) {
        
        this.fullName = name;

        let creditCard;
        if (creditCardDetails != undefined) {
            creditCard = {
                cardNumber: creditCardDetails[0],
                expirationDate: creditCardDetails[1],
                securityNumber: creditCard[2],
            }
        } else {
            creditCard = {
                cardNumber: 1111,
                expirationDate: "",
                securityNumber: 111,
            }
        }
        let wishList = [];
        let idNumber = this.generateIDNumber();
    }

    get fullName() {
        return this._fullname;
    }
    set fullName(name) {
        let pattern1 = /[A-Z][a-z]+/g
        let pattern2 = /[A-Z][a-z]+/g
        let pattern3 = /[A-Z][a-z]+/g
        if (name.length !== 3) {
            throw new Error("Name must include first name, middle name and last name")
        }
        if (!pattern1.test(name[0])) {
            throw new Error("Invalid full name")
        }
        else if (!pattern2.test(name[1])) {
            throw new Error("Invalid full name")
        }
        else if (!pattern3.test(name[2])) {
            throw new Error("Invalid full name")
        }

        return {
            firstName: name[0],
            middleName: name[1],
            lastName: name[2],
        }
    }
    generateIDNumber() {
    }
}
// Initialize vacationers with 2 and 3 parameters
let vacationer1 = new Vacationer(["Vania", "Ivanova", "Zhivkova"]);
let vacationer2 = new Vacationer(["Tania", "Ivanova", "Zhivkova"], [123456789, "10/01/2018", 777]);

// Should throw an error (Invalid full name)
try {
    let vacationer3 = new Vacationer(["Vania", "Ivanova", "ZhiVkova"]);
} catch (err) {
    console.log("Error: " + err.message);
}

// Should throw an error (Missing credit card information)
try {
    let vacationer3 = new Vacationer(["Zdravko", "Georgiev", "Petrov"]);
    vacationer3.addCreditCardInfo([123456789, "20/10/2018"]);
} catch (err) {
    console.log("Error: " + err.message);
}

vacationer1.addDestinationToWishList('Spain');
vacationer1.addDestinationToWishList('Germany');
vacationer1.addDestinationToWishList('Bali');

// Return information about the vacationers
console.log(vacationer1.getVacationerInfo());
console.log(vacationer2.getVacationerInfo());

