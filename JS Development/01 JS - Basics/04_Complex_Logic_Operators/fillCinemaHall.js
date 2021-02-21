function fillCinemaHall([movieType, rows, cols]) {
    let numberOfSeats = rows * cols;
    let currentMovieTypePrice = 0;
    switch (movieType) {
        case 'Premiere': currentMovieTypePrice = 12; break;
        case 'Normal': currentMovieTypePrice = 7.5; break;
        case 'Discount': currentMovieTypePrice = 5; break;
    }
    console.log(`${(currentMovieTypePrice * numberOfSeats).toFixed(2)} leva`);
}
