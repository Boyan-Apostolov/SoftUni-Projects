function getArticleGenerator(articles) {
    let articlesToShow = articles;
    let index = 0;
    function showNext() {
        if(index < articlesToShow.length) {
            let currentArticle = articlesToShow[index];
            let article = document.createElement('article');
            article.textContent = currentArticle;
            document.getElementById('content').appendChild(article);
            index++;

        }
    }
    return showNext;
}
