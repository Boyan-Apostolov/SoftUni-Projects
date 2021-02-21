class ChristmasMovies {
    constructor() {
        this.movieCollection = [];
        this.watched = {};
        this.actors = [];
    }

    buyMovie(movieName, actors) {
        let movie = this.movieCollection.find(m => movieName === m.name);
        let uniqueActors = new Set(actors);

        if (movie === undefined) {
            this.movieCollection.push({ name: movieName, actors: [...uniqueActors] });
            let output = [];
            [...uniqueActors].map(actor => output.push(actor));
            return `You just got ${movieName} to your collection in which ${output.join(', ')} are taking part!`;
        } else {
            throw new Error(`You already own ${movieName} in your collection!`);
        }
    }

    discardMovie(movieName) {
        let filtered = this.movieCollection.filter(x => x.name === movieName)

        if (filtered.length === 0) {
            throw new Error(`${movieName} is not at your collection!`);
        }
        let index = this.movieCollection.findIndex(m => m.name === movieName);
        this.movieCollection.splice(index, 1);
        let { name, _ } = filtered[0];
        if (this.watched.hasOwnProperty(name)) {
            delete this.watched[name];
            return `You just threw away ${name}!`;
        } else {
            throw new Error(`${movieName} is not watched!`);
        }

    }

    watchMovie(movieName) {
        let movie = this.movieCollection.find(m => movieName === m.name);
        if (movie) {
            if (!this.watched.hasOwnProperty(movie.name)) {
                this.watched[movie.name] = 1;
            } else {
                this.watched[movie.name]++;
            }
        } else {
            throw new Error('No such movie in your collection!');
        }
    }

    favouriteMovie() {
        let favourite = Object.entries(this.watched).sort((a, b) => b[1] - a[1]);
        if (favourite.length > 0) {
            return `Your favourite movie is ${favourite[0][0]} and you have watched it ${favourite[0][1]} times!`;
        } else {
            throw new Error('You have not watched a movie yet this year!');
        }
    }

    mostStarredActor() {
        let mostStarred = {};
        if (this.movieCollection.length > 0) {
            this.movieCollection.forEach(el => {
                let { _, actors } = el;
                actors.forEach(actor => {
                    if (mostStarred.hasOwnProperty(actor)) {
                        mostStarred[actor]++;
                    } else {
                        mostStarred[actor] = 1;
                    }
                })
            });
            let theActor = Object.entries(mostStarred).sort((a, b) => b[1] - a[1]);
            return `The most starred actor is ${theActor[0][0]} and starred in ${theActor[0][1]} movies!`;
        } else {
            throw new Error('You have not watched a movie yet this year!')
        }
    }
}

const { assert } = require('chai')

describe("Chistmas exam", function () {
    describe("constructor", function () {
        it("works correct", function () {
            let cristmasMoies = new ChristmasMovies();
            assert.isArray(cristmasMoies.movieCollection);
            assert.isArray(cristmasMoies.actors);
            assert.isObject(cristmasMoies.watched);
        });
    });
    describe("buyMovie", function () {
        it("throws when non second author", function () {
            let cristmasMovies = new ChristmasMovies();
            cristmasMovies.buyMovie('movie1', ['a'])
            assert.throws(() => { cristmasMovies.buyMovie('movie1', ['a']) }, Error)
        });
        it("assert added correct movie", function () {
            let cristmasMovies = new ChristmasMovies();

            let actual = cristmasMovies.buyMovie('movie1', ['a']);
            let result = `You just got movie1 to your collection in which a are taking part!`
            assert.equal(actual,result);
            assert.throw(() => { cristmasMovies.buyMovie('movie1', ['c']) }, 'You already own movie1 in your collection!')

            cristmasMovies.buyMovie('movie2', ['b'])

            let expectedResult = [
                { name: 'movie1', actors: ['a'] },
                { name: 'movie2', actors: ['b'] }
            ];
            let expectedResult2 = [
                { name: 'movie1', actors: ['a'] },
                { name: 'movie2', actors: ['b'] },
                { name: 'movie3', actors: ['b', 'a'] },
                { name: 'movie4', actors: ['b'] },
            ];
            assert.deepEqual(cristmasMovies.movieCollection, expectedResult)

            cristmasMovies.buyMovie('movie3', ['b', 'a'])
            cristmasMovies.buyMovie('movie4', ['b', 'b'])
            assert.deepEqual(cristmasMovies.movieCollection, expectedResult2)


        });
    });
    describe("discardMovie", function () {
        it("works correct", function () {
            let movies = new ChristmasMovies;
            movies.buyMovie('Movie1', ['a']);
            movies.watchMovie('Movie1');

            assert.equal(movies.discardMovie('Movie1'), `You just threw away Movie1!`)
            assert.isUndefined(movies.watched['Movie1']);

            // movies.buyMovie('Movie2',['a'])
            // console.log(movies.movieCollection)
            // movies.discardMovie('Movie2')
            assert.isUndefined(movies.movieCollection['Movie2'])
        });
        it("throws error on non existing movie", function () {
            let movies = new ChristmasMovies;
            assert.throws(() => { movies.discardMovie('Movie1') }, `Movie1 is not at your collection!`)
        })
        it("throws error on non watched movie", function () {
            let movies = new ChristmasMovies;
            movies.buyMovie('Movie1', ['a']);
            assert.throws(() => { movies.discardMovie('Movie1') }, `Movie1 is not watched!`)
        })
    });
    describe("watchMovie", function () {
        it("works correct", function () {
            let cristmasMovies = new ChristmasMovies();
            cristmasMovies.buyMovie('Movie1', ['a', 'b']);
            cristmasMovies.watchMovie('Movie1');
            assert.equal(cristmasMovies.watched['Movie1'], 1)
            cristmasMovies.watchMovie('Movie1');
            cristmasMovies.watchMovie('Movie1');
            cristmasMovies.watchMovie('Movie1');
            cristmasMovies.watchMovie('Movie1');
            assert.equal(cristmasMovies.watched['Movie1'], 5)

        });
        it("not work correct", function () {
            let cristmasMovies = new ChristmasMovies();
            assert.throws(() => { cristmasMovies.watchMovie('a') }, Error)
        });
    });
    describe("favouriteMovie", function () {
        it("works correct", function () {
            let movies = new ChristmasMovies;
            movies.buyMovie('Movie1', ['a']);
            movies.watchMovie('Movie1')
            movies.watchMovie('Movie1')
            movies.watchMovie('Movie1')
            movies.watchMovie('Movie1')
            movies.watchMovie('Movie1')

            let expected = `Your favourite movie is Movie1 and you have watched it 5 times!`

            assert.equal(movies.favouriteMovie(), expected)
        });
        it("throws error on no watched movies", function () {
            let movies = new ChristmasMovies;
            assert.throws(() => { movies.favouriteMovie() }, Error)
        });
    });
    describe("mostStarredActors", function () {
        it("works correct", function () {
            let movies = new ChristmasMovies;
            movies.buyMovie('Movie1', ['a']);
            movies.buyMovie('Movie2', ['a']);

            let expected = `The most starred actor is a and starred in 2 movies!`

            assert.equal(movies.mostStarredActor(), expected)
        });
        it("throws error on no watched movies", function () {
            let movies = new ChristmasMovies;
            assert.throws(() => { movies.mostStarredActor() }, Error)
        });
    });
});


let christmas = new ChristmasMovies();
christmas.buyMovie('a', ['a'])
// christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
// christmas.buyMovie('Home Alone 2', ['Macaulay Culkin']);
// christmas.buyMovie('Last Christmas', ['Emilia Clarke', 'Henry Golding']);
// christmas.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);
// christmas.watchMovie('Home Alone');
// christmas.watchMovie('Home Alone');
// christmas.watchMovie('Home Alone');
// christmas.watchMovie('Home Alone 2');
// christmas.watchMovie('The Grinch');
// christmas.watchMovie('Last Christmas');
// christmas.watchMovie('Home Alone 2');
// christmas.watchMovie('Last Christmas');
// christmas.discardMovie('The Grinch');
// christmas.favouriteMovie();
// christmas.mostStarredActor();

// module.exports = ChristmasMovies;