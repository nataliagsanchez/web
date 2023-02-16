/* Constantes y variables globales */

//Variable que nos permite llevar un seguimiento del mes en el que nos encontramos.
let mes = 0;

//Día que hemos pinchado dentro del calendario.
let clicked = null;

//Array de objetos "event". Si existe, que lo convierta, si no existe, que cree el array.
let events = localStorage.getItem('events') ? JSON.parse(localStorage.getItem('events')) : [];


const calendario = document.getElementById('calendar');
const newEventModal = document.getElementById('newEventModal');
const deleteModal = document.getElementById('deleteEventModal');
const backDrop = document.getElementById('modalBackDrop');
const eventTitleInput = document.getElementById('eventTitleInput');
const eventBodyInput = document.getElementById('eventBodyInput');
const diasSemana = ['lunes', 'martes', 'miércoles', 'jueves', 'viernes', 'sábado', 'domingo'];

/*Bloque de funciones.*/

function openModal(date) {
    clicked = date;

    const event = events.find(e => e.date === clicked);

    //Si existe un evento en el día pinchado, que muestre el evento y permita eliminarlo si se desea.
    if (event) {
        document.getElementById('eventText').innerText = event.title;
        document.getElementById('eventDescription').innerText = event.description;
        deleteModal.style.display = 'block';
    } else {
        newEventModal.style.display = 'block';
    }

    backDrop.style.display = 'block';
}


function carga() {
    const dt = new Date();

    if (mes !== 0) {
        dt.setMonth(new Date().getMonth() + mes);
    }

    const day = dt.getDate();
    const month = dt.getMonth();
    const year = dt.getFullYear();

    const firstDayOfMonth = new Date(year, month, 1);
    const daysInMonth = new Date(year, month + 1, 0).getDate();

    const dateString = firstDayOfMonth.toLocaleDateString('es-es', {
        weekday: 'long',
        year: 'numeric',
        month: 'numeric',
        day: 'numeric',
    });

    const paddingDays = diasSemana.indexOf(dateString.split(', ')[0]);

    document.getElementById('monthDisplay').innerText =
        `${dt.toLocaleDateString('en-us', { month: 'long' })} ${year}`;

    calendario.innerHTML = ''; //El contenido del calendario (los cuadrados de cada día) se vacía.

    for (let i = 1; i <= paddingDays + daysInMonth; i++) {
        const daySquare = document.createElement('div');
        daySquare.classList.add('day');

        const fechaDia = `${i - paddingDays}/${month + 1}/${year}`;

        if (i > paddingDays) {
            daySquare.innerText = i - paddingDays;

            const event = events.find(e => e.date === fechaDia);

            if (event) {
                eventDiv = document.createElement('div');
                eventDiv.classList.add('event');

                eventDiv.innerText = event.title;
                daySquare.appendChild(eventDiv);
            }

            daySquare.addEventListener('click', () => openModal(fechaDia));
        } else {
            daySquare.classList.add('padding');
        }

        calendario.appendChild(daySquare);
    }
}


function closeModal() {
    eventTitleInput.classList.remove('error');
    newEventModal.style.display = 'none';
    deleteModal.style.display = 'none';
    backDrop.style.display = 'none';
    eventTitleInput.value = '';
    eventBodyInput.value = '';
    clicked = null;
    carga();
}


function saveEvent() {
    if (eventTitleInput.value) {
        eventTitleInput.classList.remove('error');

        events.push({
            date: clicked,
            title: eventTitleInput.value,
            description: eventBodyInput.value
        });

        localStorage.setItem('events', JSON.stringify(events));
        closeModal();

    } else {
        eventTitleInput.classList.add('error');
    }
}


function deleteEvent() {
    events = events.filter(e => e.date !== clicked);
    localStorage.setItem('events', JSON.stringify(events));
    closeModal();
}


function iniciarBotones() {
    document.getElementById('nextButton').addEventListener('click', () => {
        mes++;
        carga();
    });

    document.getElementById('backButton').addEventListener('click', () => {
        mes--;
        carga();
    });

    document.getElementById('saveButton').addEventListener('click', saveEvent);
    document.getElementById('cancelButton').addEventListener('click', closeModal);
    document.getElementById('deleteButton').addEventListener('click', deleteEvent);
    document.getElementById('closeButton').addEventListener('click', closeModal);
}


/*Llamadas a funciones, inicialización del calendario.*/

iniciarBotones();
carga();
