function toggleSelection(button, inputId, value) {
    const inputs = document.getElementsByName(inputId);
    const buttons = document.querySelectorAll('.yes-no-button');

    for (const input of inputs) {
        input.style.display = 'none';
    }

    for (const btn of buttons) {
        btn.classList.remove('selected');
    }

    if (value === 'Yes') {
        button.classList.toggle('selected');
        const input = document.getElementById(inputId);
        input.style.display = button.classList.contains('selected') ? 'block' : 'none';
    }
    else if(value == "No"){
        button.classList.toggle('selected');
        const input = document.getElementById(inputId);
    }
}