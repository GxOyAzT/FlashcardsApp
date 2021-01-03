var isHidden = false;

function HideOrShowNavigationBar() {
    var navBar = document.getElementById("NavigationBar");

    if (isHidden) {
        isHidden = false;
        if (window.innerWidth < 500) {
            navBar.style.top = "-200px";
            return;
        }

        navBar.style.top = "-200px";
        return;
    }

    isHidden = true;
    if (window.innerWidth < 500) {
        navBar.style.top = "45px";
        return;
    }
    navBar.style.top = "80px";
}