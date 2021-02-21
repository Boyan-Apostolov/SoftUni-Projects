class PaymentPackage {
    constructor(name, value) {
        this.name = name;
        this.value = value;
        this.VAT = 20;      // Default value    
        this.active = true; // Default value
    }

    get name() {
        return this._name;
    }

    set name(newValue) {
        if (typeof newValue !== 'string') {
            throw new Error('Name must be a non-empty string');
        }
        if (newValue.length === 0) {
            throw new Error('Name must be a non-empty string');
        }
        this._name = newValue;
    }

    get value() {
        return this._value;
    }

    set value(newValue) {
        if (typeof newValue !== 'number') {
            throw new Error('Value must be a non-negative number');
        }
        if (newValue < 0) {
            throw new Error('Value must be a non-negative number');
        }
        this._value = newValue;
    }

    get VAT() {
        return this._VAT;
    }

    set VAT(newValue) {
        if (typeof newValue !== 'number') {
            throw new Error('VAT must be a non-negative number');
        }
        if (newValue < 0) {
            throw new Error('VAT must be a non-negative number');
        }
        this._VAT = newValue;
    }

    get active() {
        return this._active;
    }

    set active(newValue) {
        if (typeof newValue !== 'boolean') {
            throw new Error('Active status must be a boolean');
        }
        this._active = newValue;
    }

    toString() {
        const output = [
            `Package: ${this.name}` + (this.active === false ? ' (inactive)' : ''),
            `- Value (excl. VAT): ${this.value}`,
            `- Value (VAT ${this.VAT}%): ${this.value * (1 + this.VAT / 100)}`
        ];
        return output.join('\n');
    }
}

const { assert } = require('chai')


describe('PaymentPackage tests', () => {
    // let instance = undefined;
    // beforeEach(() => { instance = new PaymentPackage('Name', 100) })

    it('constructor', () => {
        let instance = new PaymentPackage('Name', 100);

        assert.equal(instance._name, 'Name', '1');
        assert.equal(instance._value, 100, '3');
        assert.equal(instance._VAT, 20, '4');
        assert.equal(instance._active, true, '5');
    })
    it('name', () => {
        let instance = new PaymentPackage('Name', 100);
        assert.equal(instance.name, 'Name');

        instance.name = 'Pesho';
        assert.equal(instance.name, 'Pesho')

        assert.throws(() => { instance.name = '' }, Error)
        assert.throws(() => { instance.name = 1 }, Error)
    })
    it('VAT', () => {
        let instance = new PaymentPackage('Name', 100);
        assert.equal(instance.VAT, 20);

        instance.VAT = 40;
        assert.equal(instance.VAT, 40);

        assert.throws(() => { instance.VAT = '' }, Error)
        assert.throws(() => { instance.VAT = -1 }, Error)
    })
    it('value', () => {
        let instance = new PaymentPackage('Name', 100);
        assert.equal(instance.value, 100);

        instance.value = 40;
        assert.equal(instance.value, 40);

        assert.throws(() => { instance.value = '' }, Error)
        assert.throws(() => { instance.value = -1 }, Error)
        assert.doesNotThrow(() => { instance.value = 0 })
    })
    it('active', () => {
        let instance = new PaymentPackage('Name', 100);
        assert.equal(instance.active, true);

        instance.active = false;
        assert.equal(instance.active, false);

        assert.throws(() => { instance.active = '' }, Error)
        assert.throws(() => { instance.active = -1 }, Error)
        assert.throws(() => { instance.active = 0 }, Error)
    })
    it('toString', () => {
        let instance = new PaymentPackage('Name', 100);

        function getString(name, value, VAT = 20, active = true) {
            return [
                `Package: ${name}` + (active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${value}`,
                `- Value (VAT ${VAT}%): ${value * (1 + VAT / 100)}`
            ].join('\n')
        }

        assert.equal(instance.toString(), getString('Name', 100), '1')

        instance.active = false;
        assert.equal(instance.toString(), getString('Name', 100, 20, false), '2')

        instance.VAT = 200;
        assert.equal(instance.toString(), getString('Name', 100, 200, false), '3teeeeeeeeee')

        instance.name = 'Gosho';
        assert.equal(instance.toString(), getString('Gosho', 100, 200, false), '4')

        instance.value = 2;
        assert.equal(instance.toString(), getString('Gosho', 2, 200, false), '5')
    })
})