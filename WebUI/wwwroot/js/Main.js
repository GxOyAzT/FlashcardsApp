isNavBarShow = false;

function HideNavigationBar() {
    var navBar = document.getElementById("NavigationBar");

    if (isNavBarShow) {
        navBar.style.height = "50px";
        document.getElementById("Shader").style.display = "none";
        isNavBarShow = false;
    } else {
        navBar.style.height = "210px";
        document.getElementById("Shader").style.display = "block";
        isNavBarShow = true;
    }
}

function HideErrorMessagesPanel() {
    document.getElementById("ErrorMessagesPanelId").style.display = "none";
    document.getElementById("Shader").style.display = "none";
}