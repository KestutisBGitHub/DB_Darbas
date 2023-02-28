document.getElementById(".info").required = true;

document.querySelector(".login").addEventListener("click", event => {
  event.preventDefault();
  window.open("./login.html", "_self");
});
document.querySelector(".signIn").addEventListener("click", event => {
  event.preventDefault();
  window.open("./signIn.html", "_self");
});
