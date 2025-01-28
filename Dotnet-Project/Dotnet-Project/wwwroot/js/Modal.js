document.addEventListener('DOMContentLoaded', function () {
    const modal = document.querySelector('.modal-backdrop');
    const openModalButton = document.querySelector('.btn-primary'); 

    openModalButton.addEventListener('click', function () {
        modal.style.display = 'flex'; 
    });

    modal.addEventListener('click', function (e) {
        if (e.target === modal) { 
            modal.style.display = 'none'; 
        }
    });
});
