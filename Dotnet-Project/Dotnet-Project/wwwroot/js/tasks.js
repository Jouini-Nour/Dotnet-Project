// Modal handling
/*const modal = document.querySelector('.modal-backdrop');

// Add click event listeners to all task cards
document.querySelectorAll('.task-card').forEach(card => {
    card.addEventListener('click', (e) => {
        // Prevent clicking options button from opening modal
        if (e.target.classList.contains('options') || e.target.closest('.options')) {
            e.stopPropagation();
            return;
        }

        // Show modal
        modal.style.display = 'flex';
    });
});

// Close modal when clicking outside
modal.addEventListener('click', (e) => {
    if (e.target === modal) {
        modal.style.display = 'none';
    }
});

// Handle button clicks
document.querySelector('.btn-complete').addEventListener('click', () => {
    console.log('Mark as completed clicked');
    // Add your completion logic here
});

document.querySelector('.btn-edit').addEventListener('click', () => {
    console.log('Edit clicked');
    // Add your edit logic here
});

document.querySelector('.btn-delete').addEventListener('click', () => {
    console.log('Delete clicked');
    // Add your delete logic here
});*/
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