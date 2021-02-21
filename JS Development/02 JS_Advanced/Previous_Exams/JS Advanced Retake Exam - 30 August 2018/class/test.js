class Vacationer {
    constructor(name, creditCardDetails) {

        this.fullName = name;
        this.creditCard = {
            cardNumber:0,
            expirationDate: "",
            securityNumber: 0,
        }
        if (creditCardDetails != undefined) {
            this.addCreditCardInfo(creditCardDetails)
        } else {
            this.creditCard = {
                cardNumber: 1111,
                expirationDate: "",
                securityNumber: 111,
            }
        }

        this.wishList = [];
        this.idNumber = this.generateIDNumber();
    }

    get fullName() {
        return this._fullname;
    }

    set fullName(name) {
        let pattern1 = /^([A-Z][a-z]+)$/g
        let pattern2 = /^([A-Z][a-z]+)$/g
        let pattern3 = /^([A-Z][a-z]+)$/g
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

        this._fullname = {
            firstName: name[0],
            middleName: name[1],
            lastName: name[2],
        }
    }

    generateIDNumber() {
        var charValue = this.fullName.firstName.charCodeAt(0)
        let id = 231 * charValue + 139 * this.fullName.middleName.length;
        let idAsString = '';
        //231 * firstName’s first letter’s ASCII code + 139 * middleName length
        //If the last name of the vacationer ends with a vowel ("a", "e", "o", "i", "u"), add 8 to the end of the above calculated id number. Otherwise, add 7. 

        if (this.fullName.lastName.endsWith('a')
            || this.fullName.lastName.endsWith('e')
            || this.fullName.lastName.endsWith('o')
            || this.fullName.lastName.endsWith('i')
            || this.fullName.lastName.endsWith('u')
        ) {
            idAsString = id.toString() + '8';
        } else {
            idAsString = id.toString() + '7';
        }
        return idAsString;
    }

    addCreditCardInfo(input) {
        if (input.length !== 3) {
            throw new Error("Missing credit card information");
        }
        if (typeof (input[0]) !== 'number' || typeof (input[2]) !== 'number') {
            throw new Error("Invalid credit card details");
        }

        this.creditCard.cardNumber = input[0];
        this.creditCard.expirationDate = input[1];
        this.creditCard.securityNumber = input[2];
    }

    addDestinationToWishList(destination) {
        if (this.wishList.includes(destination)) {
            throw new Error("Destination already exists in wishlist")
        }
        this.wishList.push(destination);
        this.wishList.sort(function(a, b){
            return  a.length - b.length;
          });
    }

    getVacationerInfo() {
        let result = [];
        result.push(`Name: ${this.fullName.firstName} ${this.fullName.middleName} ${this.fullName.lastName}`);

        result.push(`ID Number: ${this.idNumber}`)
        result.push(`Wishlist:`)

        if (this.wishList.length > 0) {
            result.push(this.wishList.join(', '))
        } else {
            result.push('empty')
        }

        result.push(`Credit Card:`)
        result.push(`Card Number: ${this.creditCard.cardNumber}`)
        result.push(`Expiration Date: ${this.creditCard.expirationDate.trim()}`)
        result.push(`Security Number: ${this.creditCard.securityNumber}`)

        return result.join('\n')
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

