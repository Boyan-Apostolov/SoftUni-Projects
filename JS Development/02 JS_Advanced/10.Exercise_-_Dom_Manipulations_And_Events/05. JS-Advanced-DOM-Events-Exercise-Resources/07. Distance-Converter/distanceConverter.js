function attachEventsListeners() {
    document.getElementById('convert').addEventListener('click', (e => {
        let elements = Array.from(e.target.parentNode.children)

        let inputValue = Number(elements[1].value);
        let from = elements[2].value;

        let meters = generateMeters(from, inputValue);

        function generateMeters(from, value) {
            let meters = 0;
            if (from == 'km') {
                meters = value * 1000;
            } else if (from == 'm') {
                meters = value * 1;
            } else if (from == 'cm') {
                meters = value * 0.01;
            } else if (from == 'mm') {
                meters = value * 0.001;
            } else if (from == 'mi') {
                meters = value * 1609.34;
            } else if (from == 'yrd') {
                meters = value * 0.9144;
            } else if (from == 'ft') {
                meters = value * 0.3048;
            } else if (from == 'in') {
                meters = value * 0.0254
            }
            return meters;
        }

        let to = document.getElementById('outputUnits').value;
        let toNumber = document.getElementById('outputDistance')
        let result = generateOutput(to, meters)

        function generateOutput(to, meters) {
            let result = 0;
            if (to == 'km') {
                result = meters / 1000;
            } else if (to == 'm') {
                result = meters / 1;
            } else if (to == 'cm') {
                result = meters / 0.01;
            } else if (to == 'mm') {
                result = meters / 0.001;
            } else if (to == 'mi') {
                result = meters / 1609.34;
            } else if (to == 'yrd') {
                result = meters / 0.9144;
            } else if (to == 'ft') {
                result = meters / 0.3048;
            } else if (to == 'in') {
                result = meters / 0.0254
            }
            return result;

        }
        toNumber.value = result;
    }))
}