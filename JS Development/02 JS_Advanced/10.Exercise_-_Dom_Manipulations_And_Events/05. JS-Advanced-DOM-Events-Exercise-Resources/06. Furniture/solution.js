function solve() {
  let buttons = document.querySelectorAll('button');
  let tbody = document.querySelector('tbody');

  buttons[0].addEventListener('click', (e) => {
    let input = document.querySelector('textArea').value;
    input = JSON.parse(input);
    for (const line of input) {
      let tr = document.createElement('tr');
      let img = createTd('img', '', ['src', line.img])
      let name = createTd('p', line.name, []);
      let price = createTd('p', line.price, [])
      let decFactor = createTd('p', line.decFactor, [])
      let check = createTd('input', '', ['type', 'checkbox'])

      tr.appendChild(img);
      tr.appendChild(name);
      tr.appendChild(price);
      tr.appendChild(decFactor);
      tr.appendChild(check);

      tbody.appendChild(tr)
    }
  })
  buttons[1].addEventListener('click', (e) => {
    let checks = Array.from(document.querySelectorAll('input[type=checkbox]:checked'));

    let totalPrice = 0;
    let totalDecorFactor = 0;
    let furnitures = [];

    for (const check of checks) {
      let row = check.parentNode.parentNode;
      furnitures.push(row.children[1].textContent);
      totalPrice = + Number(row.children[2].textContent);
      totalDecorFactor += Number(row.children[3].textContent);
    }
    document.querySelectorAll('textarea')[1].value =
      `Bought furniture: ${furnitures.join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${(totalDecorFactor / furnitures.length)}`
  })
  function createTd(element, textContent, attributes) {

    let td = document.createElement('td');
    let el = document.createElement(element);
    if (attributes.length > 1) {
      el.setAttribute(attributes[0], attributes[1])
    }
    if (textContent.length > 1) {
      el.textContent = textContent;
    }
    td.appendChild(el);
    return td;
  }
}