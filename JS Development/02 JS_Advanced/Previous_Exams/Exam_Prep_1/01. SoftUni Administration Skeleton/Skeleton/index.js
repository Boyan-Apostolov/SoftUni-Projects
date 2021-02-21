function solve() {
    let [lectureName, lectureDate, lectureModule] = document.getElementsByClassName('form-control')
    document.querySelector('form button').addEventListener('click', addLecture);

    let modules = document.getElementsByClassName('modules')[0];

    let lectures = {}

    function addLecture(e) {
        e.preventDefault();
        let name = lectureName.children[1].value;
        let date = lectureDate.children[1].value;
        let module = lectureModule.children[1].value;

        if (name == '' || date == '' || module == 'Select module') {
            return;
        }

        if (lectures[module]) {
            let li = createElement('li', null, 'flex');

            let result = `${name} - ${date.replace('-', '/').replace('-', '/').replace('-', '/').replace('T', ' - ')}`
            let h4 = createElement('h4', result, null)
            let delButton = createElement('button', 'Del', 'red');
            delButton.addEventListener('click', deleteLecture);

            li.appendChild(h4);
            li.appendChild(delButton);

            lectures[module].appendChild(li);

            sortUls(module);
        }
        else {
            let div = createElement('div', null, 'module');

            let h3 = createElement('h3', (module.toUpperCase() + '-MODULE'), null)
            let ul = createElement('ul', null, null);

            let li = createElement('li', null, 'flex');

            let result = `${name} - ${date.replace('-', '/').replace('-', '/').replace('-', '/').replace('T', ' - ')}`
            let h4 = createElement('h4', result, null)
            let delButton = createElement('button', 'Del', 'red');
            delButton.addEventListener('click', deleteLecture);

            li.appendChild(h4);
            li.appendChild(delButton);

            div.appendChild(h3);
            ul.appendChild(li)
            div.appendChild(ul);

            modules.appendChild(div);
            lectures[module] = ul;
        }

        function sortUls(module) {
            Array
                .from(lectures[module].children)
                .sort((a, b) => a.textContent.split(' - ')[1].localeCompare(b.textContent.split(' - ')[1]))
                .forEach(g => lectures[module].appendChild(g))
        }

        function createElement(type, content, className) {
            const result = document.createElement(type);
            if (content) {
                result.textContent = content;
            }
            if (className) {
                result.className = className;
            }
            return result;
        }
    }

    function deleteLecture(e) {
        let ul = e.target.parentNode.parentNode;
        e.target.parentNode.remove();

        if (ul.children.length == 0) {
            let moduleName = ul.parentNode.children[0].textContent.split('-')[0];
            ul.parentNode.remove();
            let lectureNames = Object.keys(lectures);
            let lecture = lectureNames.find(x=>x.toUpperCase() == moduleName)

            lectures[lecture] = null;
        }
    }
};