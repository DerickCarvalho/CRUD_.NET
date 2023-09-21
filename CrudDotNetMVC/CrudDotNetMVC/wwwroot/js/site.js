// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var passBool = 0;
var confPassBool = 0;

document.getElementById('pass-button').addEventListener('click', () => {
    var passInput = document.getElementById('pass-input');

    if (passBool == 0) {
        passInput.type = "text";
        passBool = 1;
    }
    else {
        passInput.type = "password";
        passBool = 0;
    }
});

document.getElementById('conf-pass-button').addEventListener('click', () => {
    var confPassInput = document.getElementById('conf-pass-input');

    if (confPassBool == 0) {
        confPassInput.type = "text";
        confPassBool = 1;
    }
    else {
        confPassInput.type = "password";
        confPassBool = 0;
    }
});