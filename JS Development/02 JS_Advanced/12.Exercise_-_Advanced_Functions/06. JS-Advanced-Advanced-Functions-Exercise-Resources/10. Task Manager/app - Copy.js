function solve() {
    const sections = document.querySelectorAll('section');

    function addTask(e) {
        e.preventDefault();
        let form = e.target.parentNode.children;
        let name = form[2].value;
        let description = form[6].value;
        let dueDate = form[9].value;

        if (!name || !description || !dueDate) { return }
        form[2].value = ''
        form[6].value = ''
        form[9].value = ''

        let article = createArticle(name, description, dueDate, true, 'OK');
        sections[1].children[1].appendChild(article)
    }
    function startArticle(e) {
        let article = e.target.parentNode.parentNode;
        let articleElements = e.target.parentNode.parentNode.children;
        let newArticle = createArticle(articleElements[0].textContent, articleElements[1].textContent, articleElements[2].textContent, false, 'not ok')
        sections[2].children[1].appendChild(newArticle);
        article.remove()
    }
    function deleteArticle(e) {
        let article = e.target.parentNode.parentNode;
        let articleElements = e.target.parentNode.parentNode.children;
        let newArticle = createArticle(articleElements[0].textContent, articleElements[1].textContent, articleElements[2].textContent)
        sections[4].children[1].appendChild(newArticle);
        article.remove()
    }
    function finishArticle(e) {
        let article = e.target.parentNode.parentNode;
        let articleElements = e.target.parentNode.parentNode.children;
        let newArticle = createArticle(articleElements[0].textContent, articleElements[1].textContent, articleElements[2].textContent, false, 'OK')
        sections[3].children[1].appendChild(newArticle);
        article.remove()
    }

    function createArticle(name, description, dueDate, isDeleteFinish, isToBeFinished) {
        let article = document.createElement('article');

        let heading = document.createElement('h3')
        heading.textContent = name;

        let pDesk = document.createElement('p');
        let pDate = document.createElement('p');

        if (description.includes("Description: ")) {
            pDesk.textContent = description;
            pDate.textContent = dueDate;
        } else {
            pDesk.textContent = "Description: " + description;
            pDate.textContent = "Due Date: " + dueDate;
        }

        let div = document.createElement('div')
        div.setAttribute('class', 'flex');

        article.appendChild(heading)
        article.appendChild(pDesk)
        article.appendChild(pDate)

        let button1;
        let button2;

        if (isDeleteFinish == true) {
            button1 = document.createElement('button');
            button1.setAttribute('class', 'green');
            button1.textContent = 'Start'
            button1.addEventListener('click', startArticle);


            button2 = document.createElement('button');
            button2.setAttribute('class', 'red');
            button2.textContent = 'Delete'
            button2.addEventListener('click', deleteArticle);


            div.appendChild(button1)
            div.appendChild(button2)
            article.appendChild(div)

        } else if (isDeleteFinish == false) {

            if (isToBeFinished === 'OK') {
                button1 = document.createElement('button');
                button1.setAttribute('class', 'red');
                button1.textContent = 'Delete'
                button1.addEventListener('click', deleteArticle);
                div.appendChild(button1)
            } else {
                button1 = document.createElement('button');
                button1.setAttribute('class', 'red');
                button1.textContent = 'Delete'
                button1.addEventListener('click', deleteArticle);
                div.appendChild(button1)

                button2 = document.createElement('button');
                button2.setAttribute('class', 'orange');
                button2.textContent = 'Finish'
                button2.addEventListener('click', finishArticle);
                div.appendChild(button2)
            }

            article.appendChild(div)
        }
        return article;
    }
    document.getElementById('add').addEventListener('click', addTask)
}