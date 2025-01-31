const taskModal = document.getElementById('taskModal');
const addTaskModal = document.getElementById('addTaskModal');
const editTaskModal = document.getElementById('editTaskModal');
const addTaskForm = document.getElementById('addTaskForm');
const editTaskForm = document.getElementById('editTaskForm');

// Show add task modal when clicking Add New
document.querySelector('.add-new').addEventListener('click', () => {
    addTaskModal.style.display = 'flex';
});

// Show task details when clicking a task
document.querySelectorAll('.task-card').forEach(card => {
    card.addEventListener('click', (e) => {
        if (e.target.classList.contains('options') || e.target.closest('.options')) {
            e.stopPropagation();
            return;
        }
        taskModal.style.display = 'flex';
    });
});

// Show edit modal when clicking Edit in task details
document.getElementById('editButton').addEventListener('click', () => {
    taskModal.style.display = 'none';

    // Pre-fill the edit form
    document.getElementById('editTitle').value = document.querySelector('.modal-title').textContent;
    document.getElementById('editDescription').value = document.getElementById('modalDescription').textContent.trim();

    editTaskModal.style.display = 'flex';
});

// Close modals when clicking cancel
document.querySelectorAll('.btn-cancel').forEach(btn => {
    btn.addEventListener('click', () => {
        addTaskModal.style.display = 'none';
        editTaskModal.style.display = 'none';
    });
});

// Close modals when clicking outside
[taskModal, addTaskModal, editTaskModal].forEach(modal => {
    modal.addEventListener('click', (e) => {
        if (e.target === modal) {
            modal.style.display = 'none';
        }
    });
});

// Handle form submissions
addTaskForm.addEventListener('submit', (e) => {
    e.preventDefault();
    // Add your save logic here
    addTaskModal.style.display = 'none';
});

editTaskForm.addEventListener('submit', (e) => {
    e.preventDefault();
    // Add your update logic here
    editTaskModal.style.display = 'none';
});