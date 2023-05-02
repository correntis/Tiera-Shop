const menuBtn = document.querySelector(".menu-btn__burger");
const closeBtn = document.querySelector(".menu-btn__close");
const menu = document.querySelector(".mobile_menu");
const main = document.querySelector("main");

    function openMenu() {
        menu.classList.toggle("active_menu");
        main.style.filter = "blur(2px)";
        main.style.transition = "0.2s";
    }

function closeMenu() {
    menu.classList.remove("active_menu");
    main.style.filter = "blur(0px)";
}

menuBtn.addEventListener("click", () => {
    openMenu();
});

menu.addEventListener("click",()=> {
    closeMenu();
});

main.addEventListener("click", () => {
    if (menu.classList.contains("active_menu")) {
        menu.classList.remove("active_menu");
        main.style.filter = "blur(0px)";
    }
});

main.addEventListener("touchstart", () => {
    if (menu.classList.contains("active_menu")) {
        closeMenu()
    }
});

closeBtn.addEventListener("click", () => {
    closeMenu()
});

