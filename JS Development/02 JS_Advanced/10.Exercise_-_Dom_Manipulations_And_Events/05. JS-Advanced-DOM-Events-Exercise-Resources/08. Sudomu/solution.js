function solve() {
    let buttons = document.querySelectorAll('button');
    buttons[0].addEventListener('click', check);
    buttons[1].addEventListener('click', reset);

    let table = document.getElementsByTagName('table')[0];
    let div = document.getElementById('#check');
    let p = document.querySelector('#check p');

    function check() {
        let tableRows = document.querySelectorAll('tbody>tr');
        let rowsCorrect = [];
        let colsCorrect = [];
        for (const row of tableRows) {
            let childCells = row.children;
            let currRowEls = []
            for (const cell of childCells) {
                let cellValue = Number(cell.children[0].value);
                if (cellValue >= 1 && cellValue <= 9) {
                    currRowEls.push(cellValue);
                } else {
                    currRowEls.push(false);
                }
            }
            let isRowCorrect = currRowEls[0] != currRowEls[1] || currRowEls[0] != currRowEls[2];

            rowsCorrect.push(isRowCorrect);
        }
        let test1 = Number(tableRows[0].children[0].children[0].value)
        let test2 = Number(tableRows[1].children[0].children[0].value)
        let test3 = Number(tableRows[2].children[0].children[0].value)
        colsCorrect.push(test1 != test2 || test1 != test3);

        let test11 = Number(tableRows[0].children[1].children[0].value)
        let test21 = Number(tableRows[1].children[1].children[0].value)
        let test31 = Number(tableRows[2].children[1].children[0].value)
        colsCorrect.push(test11 != test21 || test11 != test31);

        let test111 = Number(tableRows[0].children[2].children[0].value)
        let test211 = Number(tableRows[1].children[2].children[0].value)
        let test311 = Number(tableRows[2].children[2].children[0].value)
        colsCorrect.push(test111 != test211 || test111 != test311);

        let isRowsCorrect = rowsCorrect.every((val, i, arr) => val === arr[0] && val == true);
        let isColsCorrect = colsCorrect.every((val, i, arr) => val === arr[0] && val == true);



        if (isRowsCorrect && isColsCorrect) {
            p.textContent = 'You solve it! Congratulations!'
            table.style.border = 'solid';
            table.style.borderColor = 'green';
            p.style.color = 'green'
            div.style.display = 'block'
        } else {
            p.textContent = 'NOP! You are not done yet…'
            table.style.border = 'solid';
            table.style.borderColor = 'red';
            p.style.color = 'red'
            div.style.display = 'block'
        }
    }
    function reset() {
        p.style.display = 'none';
        table.style.border = 'none';
        div.style.display = 'none'
        let tableRows = document.querySelectorAll('tbody>tr');
        for (const row of tableRows) {
            let childCells = row.children;
            for (const cell of childCells) {
                cell.children[0].value = '';
            }
        }
    }

}