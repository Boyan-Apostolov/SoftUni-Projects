function solve() {
    document.getElementById('add').addEventListener('click', addTask);
    let open = document.querySelectorAll('section')[1].children[1];
    let inProgress = document.querySelectorAll('section')[2].children[1];
    let complete = document.querySelectorAll('section')[3].children[1];

    function startTask(article, name, description, date) {

        let articleToAdd = createElement('article', null, null);
        let h3 = createElement('h3', name, null)
        let pDesk = createElement('p', `Description: ${description}`, null)
        let pDate = createElement('p', `Due Date: ${date}`, null)
        let div = createElement('div', null, 'flex');
        let deleteButton = createElement('button', 'Delete', 'red')
        deleteButton.addEventListener('click', () => deleteTask(articleToAdd))
        let finishButton = createElement('button', 'Finish', 'orange');
        finishButton.addEventListener('click', () => finishTask(articleToAdd, name, description, date))
        div.appendChild(deleteButton)
        div.appendChild(finishButton)

        articleToAdd.appendChild(h3)
        articleToAdd.appendChild(pDesk)
        articleToAdd.appendChild(pDate)
        articleToAdd.appendChild(div)

        inProgress.appendChild(articleToAdd);
        article.remove();

    }
    function finishTask(article, name, description, date){

        let articleToAdd = createElement('article');
        let h3 = createElement('h3', name)
        let pDesk = createElement('p', `Description: ${description}`)
        let pDate = createElement('p', `Due Date: ${date}`);

        articleToAdd.appendChild(h3)
        articleToAdd.appendChild(pDesk)
        articleToAdd.appendChild(pDate)

        complete.appendChild(articleToAdd);
        article.remove();

    }
    function deleteTask(article) {
        article.remove();
    }
    function addTask(e) {
        e.preventDefault();

        let taskTitle = document.getElementById('task')
        let taskDescription = document.getElementById('description')
        let taskDueDate = document.getElementById('date')
        if (taskTitle.value == '' ||
            taskDescription.value == '' ||
            taskDueDate == '') {
            return;
        }
        

        let article = createElement('article');
        let h3 = createElement('h3', taskTitle.value)
        let pDesk = createElement('p', `Description: ${taskDescription.value}`)
        let pDate = createElement('p', `Due Date: ${taskDueDate.value}`)
        let div = createElement('div', null, 'flex');
        let startButton = createElement('button', 'Start', 'green');
        startButton.addEventListener('click', () => startTask(article, taskTitle.value, taskDescription.value, taskDueDate.value))
        let deleteButton = createElement('button', 'Delete', 'red')
        deleteButton.addEventListener('click', () => deleteTask(article))
        div.appendChild(startButton)
        div.appendChild(deleteButton)

        article.appendChild(h3)
        article.appendChild(pDesk)
        article.appendChild(pDate)
        article.appendChild(div)

        open.appendChild(article);
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