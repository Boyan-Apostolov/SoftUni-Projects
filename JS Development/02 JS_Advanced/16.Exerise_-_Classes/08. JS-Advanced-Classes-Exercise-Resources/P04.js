class List {
    constructor() {
        this.numbers = [];
        this.size = 0;
    }
    add(number) {
        this.numbers.push(Number(number))
        this.size++;
        this.numbers.sort((a, b) => a - b);
    }
    remove(index) {
        if (index < 0 || index > this.size || this.size == 0) {
            ///
        } else {
            this.numbers.splice(index, 1);
            this.size--;
            this.numbers.sort((a, b) => a - b);
        }
    }
    get(index) {
        return this.numbers[index];
    }
}

let list = new List();
list.add(5);
console.log(list.get(0)); //5
list.add(3);
console.log(list.get(0)); //3
list.remove(0);
console.log(list.size); // 1

/*

myList.remove(0);
expect(myList.get(0)).to.equal(5, "Element wasn't removed");
expect(myList.size).to.equal(1, "Element wasn't removed"); */