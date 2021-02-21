function print() {
    console.log(`${this.name} is printing a page`)
}
function scan() {
    console.log(`${this.name} is scanning a page`)
}
const printer = {
    name: 'Printer',
    print
}
const scanner = {
    name: 'Scanner',
    scan
}
const copier = {
    name: 'Copier',
    print,
    scan
}
function createRect(width, height) {
    const rect = { width, height }
    rect.getArea = () => {
        return rect.height * rect.width
    }
    return rect
}





