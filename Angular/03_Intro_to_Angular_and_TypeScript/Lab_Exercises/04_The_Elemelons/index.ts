abstract class Melon{
    public weight:number;
    public melonSort:string;
    public element:string;
    
    constructor(weight:number, melonSort:string){
        this.weight = weight;
        this.melonSort = melonSort;
    }

    public get elementIndex(){
        return this.weight*this. melonSort.length;
    }
        
    toString(){
     let resultAr = new Array();
     resultAr.push(`Element: ${this.element}`);   
     resultAr.push(`Sort: ${this.melonSort}`);   
     resultAr.push(`Element Index: ${this.elementIndex}`);   

     return resultAr.join('\n');
    }
}

class Watermelon extends Melon{
    constructor(weight:number, melonSort:string) {
        super(weight, melonSort);
        this.element = 'Water';
    }
}
class Firemelon extends Melon{
    constructor(weight:number, melonSort:string) {
        super(weight, melonSort);
        this.element = 'Fire';
    }
}
class Earthmelon extends Melon{
    constructor(weight:number, melonSort:string) {
        super(weight, melonSort);
        this.element = 'Earth';
    }
}
class Airmelon extends Melon{
    constructor(weight:number, melonSort:string) {
        super(weight, melonSort);
        this.element = 'Air';
    }
}

class Melolemonmelon extends Watermelon{
    constructor(weight:number, melonSort:string) {
        super(weight, melonSort);
        this.elIndex = 0;
    }
    private elIndex:number;
    private possibleMorphs: ['Water','Fire','Earth','Air']
    morph(){
        if(this.elIndex == 3){
            this.elIndex = 0;
        }
        this.element = this.possibleMorphs[this.elIndex];
        this.elIndex++;
    }
}

let watermelon : Watermelon = new Watermelon(12.5, "Kingsize");
console.log(watermelon.toString());
