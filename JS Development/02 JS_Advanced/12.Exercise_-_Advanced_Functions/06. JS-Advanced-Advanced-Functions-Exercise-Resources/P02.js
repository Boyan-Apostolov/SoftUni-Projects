function solve(arg1, arg2, arg3) {
    let inputs = [];
    inputs.push(arg1)
    inputs.push(arg2)
    inputs.push(arg3)
    let obj = [];
    for (const input of inputs) {
        let type = typeof (input)
        console.log(`${type}: ${input}`)
        if (!obj[type]) {
            obj[type] = 0;
        }
        obj[type]++;

    }
    obj.sort((a, b) => b[1] - a[1]);

    for (const key in obj) {
        console.log(`${key} = ${obj[key]}`)
    }
}

//solve('cat', 42, function () { console.log('Hello world!'); })
solve({ name: 'bob' }, 3.333, 9.999)

/*
function argumentInfo() {
    let map = new Map();
 
    for (let arg of arguments) {
        let type = typeof(arg);
        if (!map.has(type)) {
            map.set(type, 0);
        }
        map.set(type, map.get(type)+1);
        console.log(`${type}: ${arg}`)
    }
 
    // console.log([...map.entries()]);
 
    [...map.entries()].sort((a,b) => b[1] - a[1])
        .forEach((elem) => console.log(`${elem[0]} = ${elem[1]}`))
}
*/