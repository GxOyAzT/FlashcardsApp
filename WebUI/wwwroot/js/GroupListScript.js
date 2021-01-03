function ShowCreateNewGroupPanel() {
    var shader = document.getElementById("Shader");
    var createNewGroupPanel = document.getElementById("CreateNewGroupPanel");

    shader.style.visibility = "visible";
    createNewGroupPanel.style.display = "inline";
}

function HideCreateNewGroupPanel() {
    var shader = document.getElementById("Shader");
    var createNewGroupPanel = document.getElementById("CreateNewGroupPanel");
    var cNGPName = document.getElementById("CNGPName");
    var cNGPDescription = document.getElementById("CNGPDescription");

    shader.style.visibility = "hidden";
    createNewGroupPanel.style.display = "none";

    cNGPName.value = "";
    cNGPDescription.value = "";
}

function DeleteGroupWarningMessageShow(groupdId) {
    var shader = document.getElementById("Shader");
    var createNewGroupPanel = document.getElementById("GroupDeleteConfirmationPanel");
    document.getElementById("DeleteGroupId").value = groupdId;

    shader.style.visibility = "visible";
    createNewGroupPanel.style.display = "inline";
}

function DeleteGroupWarningMessageHide() {
    var shader = document.getElementById("Shader");
    var createNewGroupPanel = document.getElementById("GroupDeleteConfirmationPanel");

    shader.style.visibility = "hidden";
    createNewGroupPanel.style.display = "none";
}