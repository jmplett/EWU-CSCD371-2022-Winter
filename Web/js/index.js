function showMenu() {
    document.querySelector(".dropItems").classList.toggle("show");
}

function getNewJoke() {
    axios({
            method: 'get',
            url: 'https://v2.jokeapi.dev/joke/Programming?type=twopart'
        })
        .then(function(response) {
            let joke = document.querySelector(".joke");
            let punchline = document.querySelector(".punchline");

            joke.innerText = response.data.setup;
            punchline.innerText = response.data.delivery;
        })
}