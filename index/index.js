let sections = document.getElementsByTagName('section');
let isScrolling = false;
let current = 0;

function scrollToSection(sectionIndex) {
    isScrolling = true;
    sections[sectionIndex].scrollIntoView({ behavior: "smooth" });
    setTimeout(() => { isScrolling = false;}, 500);
}
if(window.innerWidth > 768 && !navigator.userAgent.includes('Firefox')){
    window.addEventListener("wheel", (event) => {
    event.preventDefault();  
    let direction = event.deltaY > 0 ? "down" : "up";
    if (!isScrolling) {
        if (direction === "down" && current < sections.length - 1) {
            current++;
            scrollToSection(current);
        } else if (direction === "up" && current > 0) {
            current--;
            scrollToSection(current);
        }
    }}, {passive : false});
}
