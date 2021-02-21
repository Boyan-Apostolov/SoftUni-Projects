class Textbox {
    constructor(selector,regex){
        this.selector = selector;
        this._invalidSymbols = regex;

        this._elements = document.querySelectorAll(this.selector);
    }

    isValid()
}

let textbox = new Textbox(".textbox",/[^a-zA-Z0-9]/);
let inputs = $('.textbox');

inputs.on('input',function(){console.log(textbox.value);});
