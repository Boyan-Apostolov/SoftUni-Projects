class DataRequest{
    public response: string;
    public fulfilled:boolean;

    constructor(public method:string, public uri:string,public version:string,public message:string) {
        this.response = undefined;
        this.fulfilled = false;
    }
}

let myData = new DataRequest('GET', 'http://google.com', 'HTTP/1.1', '');
console.log(myData);