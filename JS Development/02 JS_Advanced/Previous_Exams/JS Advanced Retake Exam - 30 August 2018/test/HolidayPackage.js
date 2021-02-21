class HolidayPackage {
    constructor(destination, season) {
        this.vacationers = [];
        this.destination = destination;
        this.season = season;
        this.insuranceIncluded = false; // Default value
    }

    showVacationers() {
        if (this.vacationers.length > 0)
            return "Vacationers:\n" + this.vacationers.join("\n");
        else
            return "No vacationers are added yet";
    }

    addVacationer(vacationerName) {
        if (typeof vacationerName !== "string" || vacationerName === ' ') {
            throw new Error("Vacationer name must be a non-empty string");
        }
        if (vacationerName.split(" ").length !== 2) {
            throw new Error("Name must consist of first name and last name");
        }
        this.vacationers.push(vacationerName);
    }

    get insuranceIncluded() {
        return this._insuranceIncluded;
    }

    set insuranceIncluded(insurance) {
        if (typeof insurance !== 'boolean') {
            throw new Error("Insurance status must be a boolean");
        }
        this._insuranceIncluded = insurance;
    }

    generateHolidayPackage() {
        if (this.vacationers.length < 1) {
            throw new Error("There must be at least 1 vacationer added");
        }
        let totalPrice = this.vacationers.length * 400;

        if (this.season === "Summer" || this.season === "Winter") {
            totalPrice += 200;
        }

        totalPrice += this.insuranceIncluded === true ? 100 : 0;

        return "Holiday Package Generated\n" +
            "Destination: " + this.destination + "\n" +
            this.showVacationers() + "\n" +
            "Price: " + totalPrice;
    }
}

let { assert } = require('chai')

describe("Tests", function () {
    it("Correct Constructor", function () {
        let holidayPackage = new HolidayPackage('Tarnovo', 'Autumn');

        assert.isArray(holidayPackage.vacationers);
        assert.equal(holidayPackage.destination, 'Tarnovo');
        assert.equal(holidayPackage.season, 'Autumn');
        assert.isFalse(holidayPackage.insuranceIncluded)
        assert.isFalse(holidayPackage._insuranceIncluded)

    });
    it('showVacationers', () => {
        let holidayPackage = new HolidayPackage('Tarnovo', 'Autumn');

        assert.equal(holidayPackage.showVacationers(), "No vacationers are added yet");

        holidayPackage.addVacationer('Boyan Apostolov')
        holidayPackage.addVacationer('Boyan Apostolov2')
        assert.equal(holidayPackage.showVacationers(), "Vacationers:\n" + 'Boyan Apostolov\n'+'Boyan Apostolov2')
    });

    it('addVacationer', () => {
        let holidayPackage = new HolidayPackage('Tarnovo', 'Autumn');

        assert.throws(() => { holidayPackage.addVacationer(null) }, Error)
        assert.throws(() => { holidayPackage.addVacationer(undefined) }, Error)
        assert.throws(() => { holidayPackage.addVacationer(1) }, Error)
        assert.throws(() => { holidayPackage.addVacationer('') }, Error)
        assert.throws(() => { holidayPackage.addVacationer(' ') }, Error)
        assert.throws(() => { holidayPackage.addVacationer('Bobby The best') }, Error)
        assert.throws(() => { holidayPackage.addVacationer('Bobby') }, Error)

        holidayPackage.addVacationer('Boyan Apostolov')

        assert.equal(holidayPackage.vacationers.length, 1)
    });

    it('getInsurance', () => {
        let holidayPackage = new HolidayPackage('Tarnovo', 'Autumn');

        assert.isFalse(holidayPackage.insuranceIncluded);

        holidayPackage.insuranceIncluded = true;

        assert.isTrue(holidayPackage.insuranceIncluded);
    });

    it('setInsurance', () => {
        let holidayPackage = new HolidayPackage('Tarnovo', 'Autumn');

        assert.throws(() => { holidayPackage.insuranceIncluded = null }, Error)
        assert.throws(() => { holidayPackage.insuranceIncluded = 1 }, Error)
        assert.throws(() => { holidayPackage.insuranceIncluded = undefined }, Error)
        assert.throws(() => { holidayPackage.insuranceIncluded = {} }, Error)
        assert.throws(() => { holidayPackage.insuranceIncluded = [] }, Error)

        holidayPackage._insuranceIncluded = true;
        assert.isTrue(holidayPackage.insuranceIncluded);
    })

    it('generateHolidayPackage', () => {
        let holidayPackage = new HolidayPackage('Tarnovo', 'Autumn');

        assert.throws(() => { holidayPackage.generateHolidayPackage() }, Error)

        holidayPackage.addVacationer('Boyan Apostolov');

        let result1 = "Holiday Package Generated\n" +
            "Destination: " + 'Tarnovo' + "\n" +
            "Vacationers:\n" +
            'Boyan Apostolov\n' +
            "Price: 400";

        assert.equal(result1, holidayPackage.generateHolidayPackage());

        holidayPackage.season = 'Summer';
        let result2 = "Holiday Package Generated\n" +
            "Destination: " + 'Tarnovo' + "\n" +
            "Vacationers:\n" +
            'Boyan Apostolov\n' +
            "Price: 600";
        assert.equal(result2, holidayPackage.generateHolidayPackage());

        holidayPackage.season = 'Winter';
        let result3 = "Holiday Package Generated\n" +
            "Destination: " + 'Tarnovo' + "\n" +
            "Vacationers:\n" +
            'Boyan Apostolov\n' +
            "Price: 600";
        assert.equal(result3, holidayPackage.generateHolidayPackage());

        //Now with insurance;

        holidayPackage.insuranceIncluded = true;
        let result4 = "Holiday Package Generated\n" +
            "Destination: " + 'Tarnovo' + "\n" +
            "Vacationers:\n" +
            'Boyan Apostolov\n' +
            "Price: 700";

        assert.equal(result4, holidayPackage.generateHolidayPackage(),'test');

        holidayPackage.season = 'Summer';
        let result5 = "Holiday Package Generated\n" +
            "Destination: " + 'Tarnovo' + "\n" +
            "Vacationers:\n" +
            'Boyan Apostolov\n' +
            "Price: 700";
        assert.equal(result5, holidayPackage.generateHolidayPackage());

        holidayPackage.addVacationer('Boyan Apostolov2');

        holidayPackage.season = 'Winter';
        let result6 = "Holiday Package Generated\n" +
            "Destination: " + 'Tarnovo' + "\n" +
            "Vacationers:\n" +
            'Boyan Apostolov\n' +
            'Boyan Apostolov2\n' +
            "Price: 1100";
        assert.equal(result6, holidayPackage.generateHolidayPackage());
    })

    it('test',()=>{

    })
});
