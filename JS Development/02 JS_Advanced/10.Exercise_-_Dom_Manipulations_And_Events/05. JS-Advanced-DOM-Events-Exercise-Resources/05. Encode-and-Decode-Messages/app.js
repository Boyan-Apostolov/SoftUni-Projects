function encodeAndDecodeMessages() {
    let buttons = document.querySelectorAll('button');
    let textAreas = document.querySelectorAll('textarea');

    buttons[0].addEventListener('click', encode);
    buttons[1].addEventListener('click', decode);

    function encodeSymbols(char) {
        return String.fromCharCode(char.charCodeAt(0) + 1)
    }
    function decodeSymbols(char) {
        return String.fromCharCode(char.charCodeAt(0) - 1)
    }

    function encode() {
        let message = textAreas[0].value;
        message = message.split('').map(x => encodeSymbols(x)).join('')
        console.log(message);
        textAreas[1].value = message;
        textAreas[0].value = '';
    }
    function decode() {
        let message = textAreas[1].value;
        message = message.split('').map(x => decodeSymbols(x)).join('')
        console.log(message);
        textAreas[1].value = message;
    }
}
