function fromJSONToHTMLTable(input) {
    let result = '<table>';
    let string = JSON.parse(input);

    let properties = Object.getOwnPropertyNames(string[0])
    Object.keys(string)
    result += '<tr>';
    for (const property of properties) {
        let line = property.replace(/[|&;$%@"<>()+,]/g, "");
        result += `<th>${line}</th>`
    }
    result += '</tr>';
    for (const entry of string) {
        result += '<tr>'
        for (const property of properties) {
            let line = entry[property].toString().replace(/[|&;$%@"<>()+,]/g, "");
            result += `<td>${line}</td>`
        }//result.replace(/[|&;$%@"<>()+,]/g, "");
        result += '</tr>'
    }
    result += '</table>'
    return result;
}
let json = ['[{"Name":"&St&ama&t","Score":5.5},{"Name":"Rumen","Score":6}]']

fromJSONToHTMLTable(json)
