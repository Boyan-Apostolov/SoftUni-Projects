(function solve() {
    Array.prototype.last = () => {
        return this[this.length - 1]
    }

    Array.prototype.skip = n => {
        let result = []
        for (let i = 0; i < this.length; i++) {
            if (i <= n) {

            } else {
                result.push(this[i]);
            }
        }
        return result;
    }

    Array.prototype.take = n => {
        let result = []
        for (let i = 0; i < this.length; i++) {
            if (i <= n) {
                result.push(this[i]);
            }
        }
        return result;
    }

    Array.prototype.sum = () => {
        let result = 0;
        for (const num of this) {
            result += num;
        }
        return result;
    }

    Array.prototype.average = () => {
        let result = 0;
        let count = 0;
        for (const num of this) {
            result += num;
            count++;
        }
        return result/count;
    }
}());