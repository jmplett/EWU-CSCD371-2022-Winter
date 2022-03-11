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

            joke.innerText = "";
            punchline.innerText = "";

            joke.innerText = response.data.setup;
            setTimeout(function() {
                punchline.innerText = response.data.delivery;
            }, 4000, response)
        })
        .catch(function (error) {
            console.log(error.toJSON());
            joke.innerText = "The Joke API has encountered an error"
            punchline.innerText = error;
            setTimeout(function() {
                getNewJoke();
            }, 1000)
        });
}