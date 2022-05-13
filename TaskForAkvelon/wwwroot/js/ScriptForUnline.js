//This script make underline for the text
document.querySelectorAll(".underlined-text__wrapper").forEach(elem => {
    elem.addEventListener("mousemove", function () {
        this.querySelector(".unline").style.width = 100 + "%";
    });
    elem.addEventListener("mouseout", function () {
        this.querySelector(".unline").style.width = 0 + "%";
    });
});