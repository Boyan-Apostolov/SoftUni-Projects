function solve() {
    document.querySelector('#searchBtn').addEventListener('click', onClick);
    let rows = document.querySelectorAll('tbody>tr');
    function onClick() {
        let input = document.getElementById('searchField').value.toLocaleLowerCase();
        for (const row of rows) {
            if (row.textContent.toLocaleLowerCase().includes(input)) {
                row.classList.add('select');
            }else{
                row.removeAttribute('class')
            }
        }
    }
}