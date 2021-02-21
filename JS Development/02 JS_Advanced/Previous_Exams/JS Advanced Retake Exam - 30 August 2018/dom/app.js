document.getElementsByTagName('button')[0].addEventListener('click', (e) => { addDestination })
function addDestination() {
    let table = document.getElementById('destinationsList');

    let div = document.getElementById('input').children;
    let city = div[1].value;
    let country = div[3].value
    let season = div[5].value;

    if (city == '' || country == '' || season == '') {
        return;
    }

    let seasons = {
        summer: document.getElementById('summer'),
        autumn: document.getElementById('autumn'),
        winter: document.getElementById('winter'),
        spring: document.getElementById('spring'),
    }

    div[1].value = '';
    div[3].value = '';

    let destination = `${city}, ${country}`
    let capitalisedSeason = season.charAt(0).toUpperCase() + season.slice(1)


    let row = document.createElement('tr');

    let td1 = document.createElement('td');
    td1.textContent = destination;

    let td2 = document.createElement('td');
    td2.textContent = capitalisedSeason;

    row.appendChild(td1)
    row.appendChild(td2)

    table.appendChild(row)

    seasons[season].value = Number(seasons[season].value) + 1;

}