function showMenu() {
    document.querySelector(".dropItems").classList.toggle("show");
}

function getNewJoke() {
    axios({
            method: 'get',
            url: 'https://v2.jokeapi.dev/joke/Programming'
        })
        .then(function(response) {
            let joke = document.querySelector(".joke");
            let punchline = document.querySelector(".punchline");

            var jokeString = response.data.setup;
            var deliveryString = response.data.delivery;

            joke.innerText = jokeString;
            punchline.innerText = deliveryString;
        })
}