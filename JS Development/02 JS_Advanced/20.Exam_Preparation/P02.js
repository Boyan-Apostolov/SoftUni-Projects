class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {
        if (this.capacity == 0) {
            throw new Error("Not enough parking space.")
        }

        this.vehicles.push({
            carModel,
            carNumber,
            payed: false,
        })

        this.capacity--;

        return `The ${carModel}, with a registration number ${carNumber}, parked.`
    }

    removeCar(carNumber) {
        const carIndex = this.vehicles.findIndex(x => x.carNumber == carNumber)
        if (carIndex < 0) {
            throw new Error("The car, you're looking for, is not found.")
        }

        if (!this.vehicles[carIndex].payed) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`)
        }

        this.vehicles.splice(carIndex, 1);
        this.capacity++;

        return `${carNumber} left the parking lot.`
    }

    pay(carNumber) {
        let car = this.vehicles.find(x => x.carNumber == carNumber)

        if (!car) {
            throw new Error(`${carNumber} is not in the parking lot.`)
        }
        if (car.payed) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`)
        }
        car.payed = true;

        return `${carNumber}'s driver successfully payed for his stay.`
    }

    getStatistics(carNumber) {
        let result = [];

        if (!carNumber) {
            result.push(`The Parking Lot has ${this.capacity} empty spots left.`)
            result.push(this.vehicles
                .sort((a, b) => a.carModel.localeCompare(b.carModel))
                .map(car => `${car.carModel} == ${car.carNumber} - ${car.payed ? 'Has payed' : 'Not payed'}`)
                .join('\n'));
        } else {
            let car = this.vehicles.find(x => x.carNumber == carNumber);
            result.push(`${car.carModel} == ${car.carNumber} - ${car.payed ? 'Has payed' : 'Not payed'}`)
        }

        return result.join('\n')
    }
}

const parking = new Parking(12);

console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.getStatistics());

console.log(parking.pay("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));
