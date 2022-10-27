$(document).ready(function() {
    const burger = document.querySelector('#burger');
    const nav = document.querySelector('#myNav');
    
    burger.addEventListener('click', () => {
        nav.classList.toggle('is-active');
        burger.classList.toggle('is-active');
    });
    
    const modal = document.querySelector('#climb');
    const modalToggle = document.querySelector('#climbToggle');
    const modalClose = document.querySelector('.modal-close');
    
    modalToggle.addEventListener('click', () => {
        modal.classList.toggle('is-active');
    });
    
    modalClose.addEventListener('click', () => {
        modal.classList.toggle('is-active');
    });
});
