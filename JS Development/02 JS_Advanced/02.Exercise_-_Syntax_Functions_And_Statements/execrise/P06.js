function cookingNumbers(number,operation1,operation2,operation3,operation4,operation5){
    let num = Number(number);
    let arrayOfCommands = [operation1,operation2,operation3,operation4,operation5];
    for (let i = 0; i < arrayOfCommands.length; i++) {
        switch(arrayOfCommands[i]){
            case 'chop':
                num /= 2;
                console.log(num); 
            break;
            case 'dice':
                num = Math.sqrt(num);
                console.log(num); 
            break;
            case 'spice':
                num++;
                console.log(num); 
            break;
            case 'bake':
                num*=3;
                console.log(num); 
            break;
            case 'fillet':
                num-=num*0.2;
                console.log(num); 
            break;
        }
    }
}
cookingNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');
console.log("\n")
cookingNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');