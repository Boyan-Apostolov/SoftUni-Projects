function addAndRemoveElements(arr) {
    let number = 1;
    let result = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] == 'add') {
            result.push(number);
        }
        else if (arr[i] == 'remove') {
            result.pop();
        }
        number++;

    }
    return result.length != 0 ? result.join('\n') : 'Empty';
}
console.log(addAndRemoveElements(['add', 'add', 'add', 'add']));
console.log(addAndRemoveElements(['add', 'add', 'remove', 'add', 'add']));
console.log(addAndRemoveElements(['remove', 'remove', 'remove']));
