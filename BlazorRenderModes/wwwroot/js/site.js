async function getMovie(id) {
    try {
        // this calls to our server's minimal API endpoints
        let response = await fetch(`/movie/${id}`);

        let data = await response.json();
        return data;

    } catch (error) {
        console.error(error);
    }
}

async function showMovieDetails(btn) {

    let movieId = btn.getAttribute('data-movieId');

    //call our minimal api to get the movie details
    let movie = await getMovie(movieId);

    document.getElementById('modal-title').textContent = movie.title;
    document.getElementById('modal-imdb').href = `https://www.imdb.com/title/${movie.imdb_id}`;
    document.getElementById('modal-link').href = movie.homepage;
    document.getElementById('modal-img').src = `https://image.tmdb.org/t/p/w500${movie.poster_path}`;
    document.getElementById('modal-movie-title').textContent = movie.title;
    document.getElementById('modal-overview').textContent = movie.overview;
    document.getElementById('modal-tagline').textContent = movie.tagline;
    document.getElementById('modal-rating').textContent = movie.vote_average;
    document.getElementById('modal-released').textContent = (new Date(movie.release_date)).toLocaleDateString();

    let minutes = movie.runtime % 60;
    let hours = (movie.runtime - minutes) / 60;
    document.getElementById('modal-runtime').textContent = `${hours} hours ${minutes} minutes`

    document.getElementById('modal-budget').textContent = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        maximumFractionDigits: 0
    }).format(movie.budget);

    let productionDiv = document.getElementById('modal-production-logos');
    productionDiv.innerHTML = '';

    movie.production_companies.forEach(company => {
        if (!company.logo_path) return;

        let companyImg = document.createElement('img');
        companyImg.src = `https://image.tmdb.org/t/p/w500${company.logo_path}`;
        companyImg.classList.add("productionImage");

        let col = document.createElement('div');
        
        
        //col.classList.add('col');
        col.appendChild(companyImg);

        productionDiv.appendChild(col);
    });


    const genresDiv = document.getElementById('modal-genres');
    genresDiv.innerHTML = '';

    movie.genres.forEach(genre => {
        let badge = document.createElement('span');
        badge.classList.add('badge', 'text-bg-primary');
        badge.textContent = genre.name;
        genresDiv.appendChild(badge);
    });
}