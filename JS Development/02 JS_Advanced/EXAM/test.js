class Peter{
    constructor(name){
        this.name = name;
    }
    test(){
        console.log(this)
    }
}
let peter = new Peter('a')
peter.test()