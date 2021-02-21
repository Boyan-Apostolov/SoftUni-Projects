// function deleteByEmail() {
//     let emailInput = document.querySelector('input[name="email"]').value;
//     let rows = Array.from(document.querySelectorAll('tbody>tr'))
//     let deleted = false;
//     for (const row of rows) {
//         if(row.children[1].textContent == emailInput){
//             row.parentNode.removeChild(row);
//             deleted = true;
//             document.getElementById('result').textContent = 'Deleted.'
//         }
//     }
//     if(!deleted){
//         document.getElementById('result').textContent = 'Not found.'
//     }
// }
function deleteByEmail() {
    let deleted = false;
    for (const row of Array.from(document.querySelectorAll('tbody>tr'))) {
        if (row.children[1].textContent == document.querySelector('input[name="email"]').value) { row.parentNode.removeChild(row);
            deleted = true;
        }
    }
    deleted ? document.getElementById('result').textContent = 'Deleted.' : document.getElementById('result').textContent = 'Not found.'
}