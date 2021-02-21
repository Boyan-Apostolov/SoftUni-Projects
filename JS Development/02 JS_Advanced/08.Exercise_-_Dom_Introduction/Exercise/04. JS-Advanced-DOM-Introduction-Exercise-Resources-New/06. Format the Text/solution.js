function solve() {
  let input = document.getElementById('input').value;
  input = input.split('.');
  let sentences = input.length;

  let result = '<p>';
  let counter = 0;
  for (const sentence of input) {
   console.log(sentence+'.')
    if (sentence.length < 1) {
      continue;
    }
    if (counter < 3) {
      result += sentence+'.';
    }
    else {
      result += '</p><p>' + sentence+'.';
      counter = 0;
    }
    counter++;
  }
  result+='</p>'
  document.getElementById('output').innerHTML += result
}