function solve() {
    let str = '';

    function append(string) {
        str += string;
    }
    function removeStart(n) {
        str = str.substring(n)
    }
    function removeEnd(n) {
        str = str.slice(0, -n)
    }
    function print() {
        console.log(str)
    }
    return {
        append,
        removeStart,
        removeEnd,
        print
    }
}
let firstZeroTest = solve();
firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print()