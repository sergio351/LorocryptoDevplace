
////////////////modaljs///////////////////
// Get DOM Elements
const modal = document.querySelector('#my-modal');
const modalcambiar = document.querySelector('#modalcambiar');

const modalBtn = document.querySelector('#modal-btn');
const modalBtncambiar = document.querySelector('#modal-btn-cambiar');

const closeBtn = document.querySelector('.close');
const closeBtncambiar = document.querySelector('.closecambiar');


// Events
modalBtn.addEventListener('click', openModal);
modalBtncambiar.addEventListener('click', openModal);
closeBtn.addEventListener('click', closeModal);
closeBtncambiar.addEventListener('click', closeModal);
window.addEventListener('click', outsideClick);
window.addEventListener('click', outsideClick2);

// Open
function openModal() {
    modal.style.display = 'block';
    modalcambiar.style.display = 'block';
}

// Close
function closeModal() {
    modal.style.display = 'none';
    modalcambiar.style.display = 'none';
}

// Close If Outside Click
function outsideClick(e) {
    if (e.target == modal) {
        modal.style.display = 'none';
        
    }
}

function outsideClick2(e) {
    if (e.target == modalcambiar) {
        modalcambiar.style.display = 'none';

    }
}