function solve() {
    let sections = Array.from(document.querySelectorAll('section'));
    let inputs = Array.from(sections[0].querySelectorAll('input'));
    let descriptionArea = sections[0].querySelector('textarea');
    let [taskText, dateText] = [...inputs];
    let [addTaskSect, openSect, inProgSect, completeSect] = [...sections];
    
    addTaskSect.querySelector('#add').addEventListener('click', onAdd);
    
    function addFinish(ev){
        let article = ev.target.parentNode.parentNode;
        article.querySelector('div').remove();
        completeSect.appendChild(article);
    }
    
    function inProgress(ev){
        let article = ev.target.parentNode.parentNode.cloneNode(true);
        ev.target.parentNode.parentNode.remove();
        
        let [startBtn, deleteBtn] = [...Array.from(article.querySelectorAll('button'))];
        startBtn.remove();
        let finishBtn = el('button', 'Finish', 'orange');
        finishBtn.addEventListener('click', addFinish);
        deleteBtn.addEventListener('click', onDelete);
        article.querySelector('div').appendChild(finishBtn)
        
        inProgSect.appendChild(article);
    }
    
    function onDelete(ev){
        ev.target.parentNode.parentNode.remove();
    }
    
    function onAdd(ev){
        ev.preventDefault();
        
        if(taskText.value != '' && dateText.value != '' && descriptionArea.value != ''){
            let startButton = el('button', 'Start', 'green');
            let deleteButton = el('button', 'Delete', 'red');
            
            startButton.addEventListener('click', inProgress);
            deleteButton.addEventListener('click', onDelete);
            
            let articleChildren = [el('h3', taskText.value), el('p', `Description: ${descriptionArea.value}`), el('p', `Due Date: ${dateText.value}`), el('div', [startButton, deleteButton], 'flex')]
            let article = el('article', articleChildren)
            openSect.querySelectorAll('div')[1].appendChild(article);
            taskText.value = '';
            dateText.value = '';
            descriptionArea.value = '';
        }
        
    }
    
     // Create element func
    function el(type, content, elClass){
        let element = document.createElement(type);
        if(elClass){
            element.className = elClass;
        }
        if(typeof content == 'string'){
            element.textContent = content;
        } else if(Array.isArray(content)){
            content.forEach((cur) => element.appendChild(cur));
        } else {
            element.appendChild(content);
        }
        
        return element;
    }
}