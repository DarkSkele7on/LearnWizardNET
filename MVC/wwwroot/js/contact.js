// JavaScript to toggle the visibility of the email form when clicking the envelope icon
const emailIcon = document.getElementById('email-icon');
const emailForm = document.getElementById('email-form');

emailIcon.addEventListener('click', function () {
    emailForm.style.display = emailForm.style.display === 'block' ? 'none' : 'block';
});


const mapIcon = document.getElementById('map-icon');
const mapContent = document.getElementById('map-content');

mapIcon.addEventListener('click', function () {
    mapContent.style.display = mapContent.style.display === 'block' ? 'none' : 'block';
    document.getElementById("contact-container").style.maxWidth = document.getElementById("contact-container").style.maxWidth === "60%"  ? "400px" : "60%";
}); 
