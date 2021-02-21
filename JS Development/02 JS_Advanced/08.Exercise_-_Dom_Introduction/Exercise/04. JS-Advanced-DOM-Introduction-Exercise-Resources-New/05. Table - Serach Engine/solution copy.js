// function solve() {
//    document.querySelector('#searchBtn').addEventListener('click', onClick);

//    const rows = document.querySelectorAll('tbody tr')

//    function onClick() {
//    const input = document.querySelector('#searchField').value;
//       for (const row of rows) {
//          if(row.textContent.toLowerCase().includes(input.toLowerCase())){
//             row.classList.add('select')
//          }else{
//             row.removeAttribute('class')
//          }

//       }
//    }
// }
function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   const body = document.querySelector('tbody')

   function onClick() {
      const input = document.querySelector('#searchField').value;
      body.innerHtml = Array.from(body.children).map(function selectRow(row) {
         if (row.textContent.toLowerCase().includes(input.toLowerCase())) {
            row.classList.add('select')
         } else {
            row.removeAttribute('class')
         }
         return row
      });
   }
}