function solve() {
  let answers = Array.from(document.getElementsByClassName('answer-text'));
  let sections = Array.from(document.querySelectorAll("section"));
  let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents']
  let rightAnswers = 0;
  let index = 0;

  for (const answer of answers) {
    answer.addEventListener('click', (e) => {
      if (correctAnswers.includes(answer.textContent)) {
        rightAnswers++;
      }
      sections[index].style.display = 'none'
      if (sections[index + 1] != undefined) {
        sections[index + 1].style.display = 'block'
      }
      index++;
      if (index == 3) {
        let result = document.querySelector('#results');
        result.style.display = 'block'
        if (rightAnswers == 3) {
          result.children[0].textContent = 'You are recognized as top JavaScript fan!'
        } else {
          result.children[0].textContent = `You have ${rightAnswers} right answers`
        }
      } else {
        let result = document.querySelector('#results');
        result.style.display = 'none'
      }
    })
  }
}
