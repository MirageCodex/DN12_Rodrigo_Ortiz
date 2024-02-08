document.addEventListener("DOMContentLoaded", function () {
    var memberIdInput = document.getElementById("textfield");
    var registerButton = document.getElementById("registro");

    if (memberIdInput && registerButton) {
        memberIdInput.addEventListener("keypress", handleEnterKeyPress);
        registerButton.addEventListener("click", handleRegisterButtonClick);
    }
});

function showEntryModal() {
    var memberId = document.getElementById("textfield").value;
    var currentTime = new Date().toLocaleTimeString();
    var message = `Entrada registrada para el miembro [${memberId}] [${currentTime}]`;

    showModal(message);
}

function handleEnterKeyPress(event) {
    if (event.key === "Enter") {
        event.preventDefault();
        showEntryModal();
    }
}

function handleRegisterButtonClick() {
    showEntryModal();
}

function showModal(message) {
    var modal = document.createElement("div");
    modal.className = "modal fade";
    modal.tabIndex = "-1";
    modal.setAttribute("aria-hidden", "true");

    modal.innerHTML = `
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Mensaje</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ${message}
                </div>
            </div>
        </div>
    `;

    document.body.appendChild(modal);

    var bootstrapModal = new bootstrap.Modal(modal);
    bootstrapModal.show();

    setTimeout(function () {
        bootstrapModal.hide();
        document.body.removeChild(modal);
    }, 3000);
}
