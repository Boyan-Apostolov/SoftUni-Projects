class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        let likes = this._likes.length;
        if (likes == 0) {
            return `${this.title} has 0 likes`
        } else if (likes == 1) {
            return `${this._likes[0]} likes this story!`
        } else {
            return `${this._likes[0]} and ${likes - 1} others like this story!`
        }
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw new Error("You can't like the same story twice!")
        }
        if (this.creator.toUpperCase() == username.toUpperCase()) {
            throw new Error("You can't like your own story!")
        }
        this._likes.push(username)
        return `${username} liked ${this.title}!`
    }

    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error("You can't dislike this story!")
        }
        let index = this._likes.indexOf(username);
        this._likes.splice(index, 1);

        return `${username} disliked ${this.title}`
    }

    comment(username, content, id) {
        let comment = {};
        if (!this._comments.some(x => x.Id == id) || id == undefined) {

            id = (this._comments.length + 1)
            comment = {
                Id: id,
                Username: username,
                Content: content,
                Replies: []
            };
            this._comments.push(comment);

            return `${username} commented on ${this.title}`
        } else {
            comment = this._comments.find(x => x.Id == id);

            let Id = `${comment.Id}.${comment.Replies.length + 1}`
            let reply = {
                Id: Id,
                Username: username,
                Content: content,
            };

            comment.Replies.push(reply);
            return `You replied successfully`
        }
    }

    toString(sortingType) {
        let result = [];
        result.push(`Title: ${this.title}`)
        result.push(`Creator: ${this.creator}`)
        result.push(`Likes: ${this._likes.length}`)
        result.push(`Comments:`)

        if (sortingType == 'asc') {
            for (const comment of this._comments.sort((a, b) => a.Id - b.Id)) {
                result.push(`-- ${comment.Id}. ${comment.Username}: ${comment.Content}`);
                for (const reply of comment.Replies.sort((a, b) => a.Id - b.Id)) {
                    result.push(`--- ${reply.Id}. ${reply.Username}: ${reply.Content}`)
                }
            }
        } else if (sortingType == 'desc') {
            for (const comment of this._comments.sort((a, b) => b.Id - a.Id)) {
                result.push(`-- ${comment.Id}. ${comment.Username}: ${comment.Content}`);
                for (const reply of comment.Replies.sort((a, b) => b.Id - a.Id)) {
                    result.push(`--- ${reply.Id}. ${reply.Username}: ${reply.Content}`)
                }
            }
        } else if (sortingType == 'username') {
            for (const comment of this._comments.sort((a, b) => a.Username.localeCompare(b.Username))) {
                result.push(`-- ${comment.Id}. ${comment.Username}: ${comment.Content}`);
                for (const reply of comment.Replies.sort((a, b) => a.Username.localeCompare(b.Username))) {
                    result.push(`--- ${reply.Id}. ${reply.Username}: ${reply.Content}`)
                }
            }
        }

        return result.join('\n')
    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("1Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log(art.comment("1SAmmy2", "Reply@2", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('username'));


