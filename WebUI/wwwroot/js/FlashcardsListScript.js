function ShowCreateNewFlashcardPanel() {
    var shader = document.getElementById("Shader");
    var createNewFlashcard = document.getElementById("CreateNewFlashcardId");

    shader.style.visibility = "visible";
    createNewFlashcard.style.display = "inline";
}

function HideCreateNewFlashcardPanel() {
    var shader = document.getElementById("Shader");
    var createNewFlashcard = document.getElementById("CreateNewFlashcardId");
    var flashcardForeignId = document.getElementById("FlashcardForeignId");
    var flashcardNativeId = document.getElementById("FlashcardNativeId");

    shader.style.visibility = "hidden";
    createNewFlashcard.style.display = "none";

    flashcardForeignId.value = "";
    flashcardNativeId.value = "";
}

function ShowModifyFlashcardPanel(native, foreign, id) {
    var shader = document.getElementById("Shader");
    var modifyFlashcardId = document.getElementById("ModifyFlashcardPanelId");
    var flashcardForeignModifyId = document.getElementById("FlashcardForeignModifyId");
    var flashcardNativeModifyId = document.getElementById("FlashcardNativeModifyId");
    var flashcardIdModify = document.getElementById("FlashcardIdModify");

    shader.style.visibility = "visible";
    modifyFlashcardId.style.display = "inline";

    flashcardForeignModifyId.value = native;
    flashcardNativeModifyId.value = foreign;
    flashcardIdModify.value = id;
}

function HideModifyFlashcardPanel() {
    var shader = document.getElementById("Shader");
    var modifyFlashcardId = document.getElementById("ModifyFlashcardPanelId");
    var flashcardForeignModifyId = document.getElementById("FlashcardForeignModifyId");
    var flashcardNativeModifyId = document.getElementById("FlashcardNativeModifyId");

    shader.style.visibility = "hidden";
    modifyFlashcardId.style.display = "none";

    flashcardForeignModifyId.value = "";
    flashcardNativeModifyId.value = "";
}