function solve() {
  let input = document.getElementById('text').value;
  let namingConvention = document.getElementById('naming-convention').value;
  input = input.split(' ')
  input = input.map(x => x.toLowerCase())
  let result = '';
  let error = false;
  for (let i = 0; i < input.length; i++) {
    const word = input[i];
    if (namingConvention == 'Camel Case') {
      if (i == 0) {
        result += word;
      } else {
        result += word[0].toUpperCase() + word.substring(1, word.length)
      }
    } else if (namingConvention == 'Pascal Case') {
      result += word[0].toUpperCase() + word.substring(1, word.length)
    } else { error=true;  }
  }
  if(!error){
    document.getElementById('result').textContent = result;
  }else{
    document.getElementById('result').textContent = 'Error!';
  }
  
}