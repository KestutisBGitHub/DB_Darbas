document
  .querySelector(".submitLogin")
  .addEventListener("click", async event => {
    event.preventDefault();
    //const userInput = document.querySelectorAll(".loginForm").value;
    try {
      const response = await fetch("");
      const data = await response.json();
      const paste = document.querySelector(".getData");
      paste.innerHTML = data;
    } catch (error) {
      console.error(error);
    }
  });
