flashcardCount = 0;
actualFlashcard = 0;

window.onload = function () {
    document.getElementById("FlashcardPractice-front-1").style.display = "block";
    flashcardCount = parseInt(document.getElementById("TotalFlashcardCountId").value);
};

function ShowAnswer(flaToHide, flaToShow) {
    document.getElementById(flaToHide).style.display = "none";
    document.getElementById(flaToShow).style.display = "block";
    document.getElementById("ButtonsPracticeStatusWrpaerId").style.display = "block";
}

function SetFlashcardAsKnow() {
    actualFlashcard = actualFlashcard + 1;

    document.getElementById("Flashcard-practiceStatus-" + actualFlashcard).value = 3;
    document.getElementById("FlashcardPractice-back-" + actualFlashcard).style.display = "none";
    document.getElementById("ButtonsPracticeStatusWrpaerId").style.display = "none";

    if (actualFlashcard < flashcardCount) {
        document.getElementById("FlashcardPractice-front-" + (actualFlashcard + 1)).style.display = "block";
        return;
    }

    ShowFinalPanel();
}

function SetFlashcardAsAlmostKnow() {
    actualFlashcard = actualFlashcard + 1;

    document.getElementById("Flashcard-practiceStatus-" + actualFlashcard).value = 2;
    document.getElementById("FlashcardPractice-back-" + actualFlashcard).style.display = "none";
    document.getElementById("ButtonsPracticeStatusWrpaerId").style.display = "none";

    if (actualFlashcard < flashcardCount) {
        document.getElementById("FlashcardPractice-front-" + (actualFlashcard + 1)).style.display = "block";
        return;
    }

    ShowFinalPanel();
}

function SetFlashcardAsDontKnow() {
    actualFlashcard = actualFlashcard + 1;

    document.getElementById("Flashcard-practiceStatus-" + actualFlashcard).value = 1;
    document.getElementById("FlashcardPractice-back-" + actualFlashcard).style.display = "none";
    document.getElementById("ButtonsPracticeStatusWrpaerId").style.display = "none";

    if (actualFlashcard < flashcardCount) {
        document.getElementById("FlashcardPractice-front-" + (actualFlashcard + 1)).style.display = "block";
        return;
    }

    ShowFinalPanel();
}

function ShowFinalPanel() {
    document.getElementById("FinalPanelId").style.display = "block";
}