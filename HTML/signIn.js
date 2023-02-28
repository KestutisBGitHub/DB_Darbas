document.querySelector(".submitSignIn").addEventListener("click",async event => {
  event.preventDefault();
  const userInput = document.querySelectorAll(".signInForm").value;
  try{
    const response = await fetch("");
    const data = await response.json();
    
  }
});
