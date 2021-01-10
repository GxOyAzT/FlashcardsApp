isNavBarShow = false;

function HideNavigationBar() {
    var navBar = document.getElementById("NavigationBar");

    if (isNavBarShow) {
        navBar.style.width = "50px";
        document.getElementById("Shader").style.display = "none";
        isNavBarShow = false;
    } else {
        navBar.style.width = "250px";
        document.getElementById("Shader").style.display = "block";
        isNavBarShow = true;
    }
}

function HideErrorMessagesPanel() {
    document.getElementById("ErrorMessagesPanelId").style.display = "none";
    document.getElementById("Shader").style.display = "none";
}