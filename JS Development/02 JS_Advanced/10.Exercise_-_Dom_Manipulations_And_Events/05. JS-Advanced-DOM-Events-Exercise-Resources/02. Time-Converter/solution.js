function attachEventsListeners() {
    const buttons = document.querySelectorAll('input[type=button]');
    let textAreas = document.querySelectorAll('input[type="text"]');

    for (const el of buttons) {
        console.log(el)
        let type = el.getAttribute('id');
        el.addEventListener('click', (e) => {
            if (type.toLocaleLowerCase().includes('days')) {
                daysToOther();
            } else if (type.toLocaleLowerCase().includes('hours')) {
                hoursToOther();
            } else if (type.toLocaleLowerCase().includes('minutes')) {
                minutesToOther();
            } else if (type.toLocaleLowerCase().includes('seconds')) {
                secondsToOther();
            }
        })
    }
    
    function daysToOther() {
        let days = Number(textAreas[0].value)
        let hours = days * 24;
        let minutes = hours * 60;
        let seconds = minutes * 60;
        textAreas[1].value = hours;
        textAreas[2].value = minutes;
        textAreas[3].value = seconds;
    }
    function hoursToOther() {
        let hours = Number(textAreas[1].value);
        let days = hours / 24;
        let minutes = hours * 60;
        let seconds = minutes * 60;
        textAreas[0].value = days;
        textAreas[2].value = minutes;
        textAreas[3].value = seconds;
    }
    function minutesToOther() {
        let minutes = Number(textAreas[2].value);
        let hours = minutes / 60;
        let days = hours / 24;
        let seconds = minutes * 60;
        textAreas[0].value = days;
        textAreas[1].value = hours;
        textAreas[2].value = minutes;
        textAreas[3].value = seconds;
    }
    function secondsToOther() {
        let seconds = Number(textAreas[3].value);
        let minutes = seconds / 60;
        let hours = minutes / 60;
        let days = hours / 24;
        textAreas[0].value = days;
        textAreas[1].value = hours;
        textAreas[2].value = minutes;
        textAreas[3].value = seconds;
    }
}