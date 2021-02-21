function search() {
    let input = document.getElementById('searchText').value;
    let towns = document.querySelectorAll('#towns>li');
    let matches = 0;
    for (const town of towns) {
        if (town.textContent.toLowerCase().includes(input.toLowerCase())) {
            town.style.fontWeight = 'bold'
            town.style.textDecoration = 'underline'
            matches++;
        }
    }
    document.getElementById('result').textContent = `${matches} matches found`
}
