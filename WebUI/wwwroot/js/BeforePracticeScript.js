function SetModeAsLearnNew() {
    document.getElementById("ModePracticeLearnId").value = 1;
    document.getElementById("PracticeOrLearnWrapperId").style.display = "none";
    document.getElementById("HowManyFlashcardsLearnWrapperId").style.display = "block";
}

function SetModeAsPractice() {
    document.getElementById("ModePracticeLearnId").value = 2;
    document.getElementById("PracticeOrLearnWrapperId").style.display = "none";
    document.getElementById("HowManyFlashcardsPracticeWrapperId").style.display = "block";
}

function SetQuantity(n, por) {
    document.getElementById("HowManyFlashcardsId").value = n;
    document.getElementById("StartWrapperId").style.display = "block";

    if (por == 'p') {
        document.getElementById("HowManyFlashcardsPracticeWrapperId").style.display = "none";
    }
    else {
        document.getElementById("HowManyFlashcardsLearnWrapperId").style.display = "none";
    }
}