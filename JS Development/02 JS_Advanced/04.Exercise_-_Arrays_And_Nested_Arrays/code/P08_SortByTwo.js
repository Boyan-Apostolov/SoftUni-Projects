function sortByTwo(arr) {
    arr.sort((a, b) => {
        if (a.length === b.length) {
            return a.localeCompare(b);
        }
        return a.length - b.length;
    });
    return arr.join('\n');
}
console.log(sortByTwo(['alpha', 'beta', 'gamma']));
console.log(sortByTwo(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']
));
console.log(sortByTwo(['test',
    'Deny',
    'omen',
    'Default']
));
