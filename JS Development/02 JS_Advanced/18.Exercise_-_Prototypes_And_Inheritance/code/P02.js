(function solve() {
    String.prototype.ensureStart = function (string) {
        if (!this.toString().startsWith(string)) {
            return string + this.toString()
        }
        return this.toString();
    }

    String.prototype.ensureEnd = function (string) {
        if (!this.toString().endsWith(string)) {
            return this.toString() + string
        }
        return this.toString();
    }
    String.prototype.isEmpty = function(){
        return this.toString().length == 0
    }
    String.prototype.truncate = function (n) {
        let result = '';
        if (n < 4) {
            result += '.'.repeat(n)
        }
        if (this.toString().length <= n) {
            return this.toString();
        } else {
            let lastIndex = this.toString().substr(0, n - 2).lastIndexOf(" ");

            if (lastIndex != -1) {
                return this.toString().substr(0, lastIndex) + "...";
            } else {
                return this.toString().substr(0, n - 3) + "...";
            }
        }
    }
    String.format = (string, ...params) => {
        for (let i = 0; i < params.length; i++) {
            string = string.replace(`{${i}}`, params[i])
        }
        return string
    }
})()

var testString = 'quick brown fox jumps over the lazy dog';
var answer = testString.ensureStart('the ');
console.log(answer)

console.log('the quick brown fox jumps over the lazy dog : needs to be')
