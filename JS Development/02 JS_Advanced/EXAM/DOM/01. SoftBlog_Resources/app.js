function solve() {
   document.getElementsByClassName('btn create')[0].addEventListener('click', addPost);
   let inputs = document.querySelectorAll('input');
   let textarea = document.querySelector('textarea');
 
   function addPost(e) {
      e.preventDefault();
      let author = inputs[0].value;
      let title = inputs[1].value;
      let category = inputs[2].value;
      let content = textarea.value;
 
      let article = createElement('article')
 
      let h1 = createElement('article', title)
      article.appendChild(h1)
 
      let categoryP = createElement('p', "Category:")
      let stringCategory = createElement('strong', category)
      categoryP.appendChild(stringCategory);
      article.appendChild(categoryP)
 
 
      let creatorP = createElement('p', 'Creator:');
      let stringCreator = createElement('strong', author)
      creatorP.appendChild(stringCreator);
      article.appendChild(creatorP)
 
 
      let descriptionP = createElement('p', content)
      article.appendChild(descriptionP)
 
      let buttonsDiv = createElement('div', undefined, 'buttons')
 
      let deleteButton = createElement('button', 'Delete', 'btn delete')
      deleteButton.addEventListener('click', deletePost);
 
      let archiveButton = createElement('button', 'Archive', 'btn archive')
      archiveButton.addEventListener('click', archivePost)
 
      buttonsDiv.appendChild(deleteButton);
      buttonsDiv.appendChild(archiveButton);
 
      article.appendChild(buttonsDiv);
 
      document.querySelectorAll('section')[1].appendChild(article)
   }
 
   function deletePost(e) {
      e.target.parentNode.parentNode.remove();
   }
 
   function archivePost(e) {
      e.target.parentNode.parentNode.remove();
 
      let li = createElement('li', e.target.parentNode.parentNode.children[0].textContent)
      let ol = document.querySelector('ol')
      ol.appendChild(li)
 
      sortOl(ol)
   }
 
   function sortOl(ol) {
      Array.from(ol.children).sort((a, b) => a.textContent.localeCompare(b.textContent)).forEach(g => ol.appendChild(g))
   }
 
   function createElement(type, content, className) {
      const result = document.createElement(type);
      result.textContent = content;
      if (className) {
         result.className = className;
      }
      return result;
   }
}