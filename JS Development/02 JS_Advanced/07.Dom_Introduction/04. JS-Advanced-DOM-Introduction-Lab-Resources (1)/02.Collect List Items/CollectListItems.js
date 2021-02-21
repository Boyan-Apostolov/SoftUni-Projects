function extractText() {
    let liElements = document.getElementsByTagName('li');
    const elementText = [...liElements].map(e=>e.textContent)
    const textArea = document.getElementById('result');
    textArea.value = elementText.join('\n')
}