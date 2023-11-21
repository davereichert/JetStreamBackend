let globaleAuftraege = [];

document.addEventListener('DOMContentLoaded', function () {
    getAuftraege();
    setupEventListeners();
});

function getAuftraege() {
    fetch('/ServiceAuftrag', {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem('jwtToken'),
            'Content-Type': 'application/json; charset=utf-8'
        }
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Fehler beim Abrufen der Aufträge. Status: ' + response.status);
            }
            return response.json();
        })
        .then(auftraege => {
            globaleAuftraege = auftraege;
            zeigeAuftraege();
        })
        .catch(error => {
            console.error('Fehler:', error);
            alert('Fehler beim Abrufen der Aufträge: ' + error.message);
        });
}

function zeigeAuftraege(prioritaet) {
    const tabelle = document.getElementById('auftragsTabelle');
    tabelle.innerHTML = '';

    let gefilterteAuftraege = globaleAuftraege;
    if (prioritaet) {
        gefilterteAuftraege = globaleAuftraege.filter(auftrag => auftrag.priority.toLowerCase() === prioritaet.toLowerCase());
    }

    gefilterteAuftraege.forEach(auftrag => {
        const zeile = document.createElement('tr');
        zeile.innerHTML = `
            <td>${auftrag.id}</td>
            <td>${auftrag.name}</td>
            <td>${auftrag.email}</td>
            <td>${auftrag.phone}</td>
            <td>${auftrag.priority}</td>
            <td>${auftrag.service}</td>
            <td>${auftrag.create_date}</td>
            <td>${auftrag.pickup_date}</td>
            <td>
                <button class="btn btn-danger btn-sm delete-btn" data-id="${auftrag.id}">Loeschen</button>
            </td>
        `;
        tabelle.appendChild(zeile);
    });
}

function filtereAuftraege(prioritaet) {
    zeigeAuftraege(prioritaet);
}

function setupEventListeners() {
    document.getElementById('auftragsTabelle').addEventListener('click', function (event) {
        if (event.target && event.target.classList.contains('delete-btn')) {
            const id = event.target.getAttribute('data-id');
            deleteOrder(id, event.target);
        }
    });
}

function deleteOrder(id, button) {
    fetch(`/ServiceAuftrag/${id}`, {
        method: 'DELETE',
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem('jwtToken'),
            'Content-Type': 'application/json; charset=utf-8'
        }
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Fehler beim Löschen des Auftrags. Status: ' + response.status);
            }
            button.closest('tr').remove();
        })
        .catch(error => {
            console.error('Fehler:', error);
            alert('Fehler beim Löschen des Auftrags: ' + error.message);
        });
}
