function search() {
   let listItems = document.querySelectorAll('#towns>li');
   let input = document.getElementById('searchText').value;
   let result = document.getElementById('result');
   let sum = 0;
   for (const li of listItems) {
      if (li.textContent.toLowerCase().includes(input.toLowerCase())) {
         li.style.fontWeight = 'bold'
         li.style.textDecoration = 'underline'
         sum++;
      }else{
         li.style.fontWeight = ''
         li.style.textDecoration = ''
      }
   }
   result.textContent = `${sum} matches found`;
}
