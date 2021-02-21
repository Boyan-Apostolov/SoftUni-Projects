function solve() {
    const formControls = document.querySelectorAll('.form-control input')
    const lecture = formControls[0];
    const date = formControls[1];
    const module = document.querySelector('select');
    const modulesOutput = document.querySelector('.modules')

    let state = {};

    function createElement(type, text, attributes = []) {
        let element = document.createElement(type);
        if (text) {
            element.textContent = text;
        }
        attributes
            .map(attr => attr.split('='))
            .forEach(([name, value]) => {
                element.setAttribute(name, value);
            });

        return element;
    }

    function add(e) {
        e.preventDefault()
        if (lecture.value == ""
            || date.value == ""
            || module.value == "Select module") {
            return;
        }
        let lectureName = lecture.value;
        let dateString = date.value;
        let moduleName = module.value

        let lectureTitle = lectureName + ' -  ' + dateString.split('-').join('/').split('T').join(' - ');

        let delBtn = createElement('button', 'Del', ['class=red']);
        let lectureH4 = createElement('h4', lectureTitle)
        const li = createElement('li', undefined, ['class=flex'])

        li.appendChild(lectureH4);
        li.appendChild(delBtn);

        let module1;
        let ul;
        let lis;

        if (!state[moduleName]) {
            let h3 = createElement('h4', `${moduleName.toUpperCase()}-MODULE`);
            ul = createElement('ul')
            module1 = createElement('div')

            module1.appendChild(h3);
            module1.appendChild(ul);

            state[moduleName] = { module1, ul, lis: [] }
        } else {
            module1 = state[moduleName].module;
            ul = state[moduleName].ul;
            lis = state[moduleName].lis;
        }

        lis.push({ li, date: date.value })
        lis.sort((a, b) => a.date.localeCompare(b.date)).forEach(({ li }) => {
            ul.appendChild(li);
        })

        modulesOutput.appendChild(module)
    }

    document.querySelector('button').addEventListener('click', add)
};