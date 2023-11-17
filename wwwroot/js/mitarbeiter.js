document.addEventListener("DOMContentLoaded", function () {
    const form = document.querySelector("form");

    form.addEventListener("submit", function (event) {
        event.preventDefault();

        // Daten aus dem Formular sammeln
        const name = document.getElementById("name").value;
        const username = document.getElementById("username").value;
        const password = document.getElementById("password").value;
        const email = document.getElementById("email").value;
        const telephone = document.getElementById("telephone").value;
        const role = document.getElementById("role").value;
        const creationDate = document.getElementById("creationDate").value;

        // Validierung
        if (!isValidEmail(email)) {
            alert("Bitte geben Sie eine gültige E-Mail-Adresse ein.");
            return;
        }

        if (!isValidSwissPhone(telephone)) {
            alert("Bitte geben Sie eine gültige Schweizer Telefonnummer ein.");
            return;
        }

        // Mitarbeiterobjekt erstellen
        const employee = {
            name: name,
            username: username,
            password: password,
            email: email,
            telephone: telephone,
            role: role,
            isActive: true,
            creationDate: creationDate,
            lastLogin: null
        };
        
        // An die API senden
        fetch('/mitarbeiter', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem('jwtToken')
            },
            body: JSON.stringify(employee)
        })
        .then(response => {
            if (!response.ok) {
                alert('Fehler beim Hinzufügen des Mitarbeiters. Status: ' + response.status);
            } else {
                alert('Mitarbeiter wurde erfolgreich hinzugefügt.');
            }
        })
        .catch(error => console.error('Fehler:', error));
    });
});

// Funktion zur Validierung der E-Mail
function isValidEmail(email) {
    let regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
    return regex.test(email);
}

// Funktion zur Validierung der Schweizer Telefonnummer
function isValidSwissPhone(phone) {
    let regex = /^(?:\+41|0041|0)(?:[1-9]{2})\d{7}$/;
    return regex.test(phone);
}
