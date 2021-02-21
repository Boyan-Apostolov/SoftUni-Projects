function create(words) {
   const output = document.getElementById('content');
   words.forEach(w => {
      output.appendChild(createArticle(w))
   });

   function createArticle(text) {
      const pEl = e('p', text)
      pEl.style.display = 'none';

      const div = e('div', pEl)
      div.addEventListener('click', (e) => {
         pEl.style.display = ''
      })
      return div
   }

   function e(type, content) {
      const result = document.createElement(type);
      if (typeof (content) == 'string') {
         result.textContent = content;
      } else {
         result.appendChild(content)
      }

      return result
   }
}
