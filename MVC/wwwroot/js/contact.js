const emailIcon = document.getElementById('email-icon');
const emailForm = document.getElementById('email-form');
const mapIcon = document.getElementById('map-icon');
const mapContent = document.getElementById('map-content');
const contactContainer = document.getElementById('contact-container');

function toggleVisibility(sectionToShow, sectionToHide) {
    // Toggle visibility of the clicked section
    sectionToShow.style.display = sectionToShow.style.display === 'block' ? 'none' : 'block';
    // Ensure the other section is hidden
    sectionToHide.style.display = 'none';
    // Adjust container size based on current visibility states
    contactContainer.style.maxWidth = sectionToShow.style.display === 'block' || sectionToHide.style.display === 'block' ? "60%" : "400px";
}

emailIcon.addEventListener('click', function () {
    toggleVisibility(emailForm, mapContent);
});

mapIcon.addEventListener('click', function () {
    toggleVisibility(mapContent, emailForm);
});
