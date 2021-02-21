function generateReport(colNames) {
    let checkBoxes = document.querySelectorAll('input')
    let columns = []
    let result = [];
    for (var i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].checked) {
            columns.push({ name: checkBoxes[i].name, index: i });
        }
    }
    let rows = document.querySelectorAll('tbody>tr')
    for (const row of rows) {
        let obj = {};
        for (let i = 0; i < row.children.length; i++) {
            let child = row.children[i].textContent;
            for (const column of columns) {
                if (column.index == i) {
                    obj[column.name] = child;
                }
            }
        }

        result.push(obj)
    }
    document.getElementById('output').textContent = JSON.stringify(result);
}