class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName,
        this.phone = phone;
        this.email = email;

        this._online = false;

        this.article = null;
    }
    get online() {
        return this._online;
    }

    set online(value) {
        this._online = value;
        if (value) {
            this.article.children[0].classList.add('online')
        } else {
            this.article.children[0].classList.remove('online')
        }
    }

    render(id) {
        const parentDiv = document.getElementById(id);

        let article = document.createElement('article')

        let nameDiv = document.createElement('div');
        nameDiv.setAttribute('class', 'title')
        nameDiv.textContent = `${this.firstName} ${this.lastName}`

        let infoDiv = document.createElement('div');
        infoDiv.classList.add('info');
        infoDiv.style.display = 'none'

        let phoneSpan = document.createElement('span');
        phoneSpan.innerHTML = `&phone; ${this.phone}`
        let emailSpan = document.createElement('span')
        emailSpan.innerHTML = `&#9993; ${this.email}`

        infoDiv.appendChild(phoneSpan);
        infoDiv.appendChild(emailSpan);

        let button = document.createElement('button');
        button.innerHTML = '&#8505';
        button.addEventListener('click', (e) => {
            let outerDiv = e.target.parentNode.parentNode.children[1];
            outerDiv.style.display == 'block' ? outerDiv.style.display = 'none' : outerDiv.style.display = 'block'
        })
        nameDiv.appendChild(button);

        article.appendChild(nameDiv);
        article.appendChild(infoDiv)
        this.article = article;

        parentDiv.appendChild(article);
    }
}
function js() {
    let contacts = [
        new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
        new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
        new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
    ];
    contacts.forEach(c => c.render('main'));
    console.log(contacts[0].online)
    // After 1 second, change the online status to true
    setTimeout(() => contacts[1].online = true, 2000);
}


