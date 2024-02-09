function navigateToPage(pageId) {
    const currentPage = document.querySelector('.page-fade');
    const newPage = document.getElementById(pageId);

    // Fade out the current page
    currentPage.classList.add('page-fade-out');

    // After a short delay, hide the current page and fade in the new page
    setTimeout(function () {
        currentPage.style.display = 'none';
        newPage.style.display = 'block';
        newPage.classList.remove('page-fade-out');
    }, 500); // Adjust the delay to match the CSS transition duration
}

// Example: Add event listeners to your navigation links
document.getElementById('link-to-about').addEventListener('click', function () {
    navigateToPage('about-page');
});

document.getElementById('link-to-contact').addEventListener('click', function () {
    navigateToPage('contact-page');
});
