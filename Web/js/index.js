function showMenu() {
    document.querySelector(".dropItems").classList.toggle("show");
}

function getNewJoke() {
    axios
        .post('https://v2.jokeapi.dev/joke/Programming', {type: 'twopart'}, {timeout: 20000})
        .then(response => {
            let joke = document.querySelector(".joke");
            let punchline = document.querySelector(".punchline");

            joke.innerText = "";
            punchline.innerText = "";

            joke.innerText = response.data.setup;
            setTimeout(function() {
                punchline.innerText = response.data.delivery;
            }, 4000, response)
        })
        .catch(err => {
            console.log(err.toJSON());
            document.querySelector(".joke").innerText = "The Joke API has encountered an error."
            document.querySelector(".punchline").innerText = err;
            setTimeout(function() {
                getNewJoke();
            }, 5000)
        });
}