function solve() {
  const [input, output] = document.getElementsByTagName('textarea')
  const table = document.getElementsByTagName('table.table tbody');
  const [generateBtn, buyBtn] = [...document.querySelectorAll('button')]

  const furniture = [];

  let furnitureArray = JSON.parse(input.value.trim());

  generateBtn.addEventListener('click', () => {
    table.innerHTML = ''
    furnitureArray.forEach(f => table.appendChild(createRow(f)));
    furnitureArray.forEach(f => furnitureArray.push(createRow(f)));
  })

  buyBtn.addEventListener('click', () => {
    furniture.filter(f =>)
  })

  function createRow(data) {
    const img = e('img')
    const check = e('input')
    check.type = 'checkbox'
    const element = e(
      'tr',
      e('td', img),
      e('td', e('p', data.name)),
      e('td', e('p', data.price)),
      e('td', e('p', data.decFactor)),
      e('td', e('p', data.decFactor))
    )
    return { element, isChecked };
    function isChecked() {
      return check.checked
    }
  }
  function e(type, ...content) {
    const result = document.createElement(type);

    content.forEach(e => {
      if (typeof (e) == 'string') {
        const node = document.createTextNode(e)
        result.appendChild(node);
      } else {
        result.appendChild(e)
      }
    });

    return result;
  }
}