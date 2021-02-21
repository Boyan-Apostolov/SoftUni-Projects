function solve() {
   const output = document.querySelector('textarea');
   const cart = []
   document.querySelector('.shopping-cart').addEventListener('click', onClick)

   function onClick(ev) {
      if (ev.target.tagName == 'BUTTON' && ev.target.className == 'add-product') {
         const product = ev.target.parentNode.parentNode;
         const title = product.querySelector('.product-title').textContent
         const price = Number(product.querySelector('.product-line-price').textContent)
         output.value += `Added ${title} for ${price.toFixed(2)} to the cart.\n`
         cart.push({ title, price })
      }

   }
   function checkout() {
      document.querySelector('.checkout').removeEventListener('click', checkout)
      Array.from(document.querySelectorAll('button')).forEach(b => b.disabled = true)
      let result = [];
      let sum = 0;
      for (const item of cart) {
         if (result.indexOf(item.title) == -1) {
            result.push(item.title);
         }
         sum += item.price;
      }
      output.value += `You bought ${result.join(', ')} for ${sum.toFixed(2)}.`
   }
   document.querySelector('.checkout').addEventListener('click', checkout)
}