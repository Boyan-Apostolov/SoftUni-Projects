function stringLength(a,b,c){
    let total = a.length + b.length + c.length;
    console.log(total);

    let average = Math.floor(total / 3);    
    console.log(average);
}
stringLength('chocolate', 'ice cream', 'cake')