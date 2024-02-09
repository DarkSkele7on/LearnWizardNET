// Text to be typed
const title = "Your Personalized Learning Journey Starts Here";
const paragraph = "Welcome to Learn Wizard, where you take the lead in your learning adventure.";

// Get the element where the text will be typed
const typedTitle = document.getElementById("title-text");
const typedParagraph = document.getElementById("paragraph-text");

// Initialize variables
let charIndex = 0;
let underscoreVisible = true;

// Function to simulate typing the title
function typeTitle() {
    if (charIndex <= title.length) {
        // Add the next character to the typed text
        typedTitle.textContent = title.substring(0, charIndex);
        charIndex++;
        // Delay before typing the next character (adjust the delay duration)
        setTimeout(typeTitle, 0); 
    } else {
        // After typing the title, fade in the second paragraph
        typedParagraph.style.opacity = 0; // Start with opacity 0
        typedParagraph.textContent = paragraph; // Set the paragraph text
        fadeInParagraph();
    }
}

// Function to fade in the paragraph
function fadeInParagraph() {
    let opacity = 0;
    const fadeInInterval = setInterval(function () {
        if (opacity < 1) {
            opacity += 0.05; // Adjust the increment for fade-in speed
            typedParagraph.style.opacity = opacity;
        } else {
            clearInterval(fadeInInterval); // Stop the interval when fully faded in
        }
    }, 50); // Adjust the interval duration for smoother fading
}

// Start the typing animation when the page loads
window.addEventListener("load", () => {
    typeTitle();
    setInterval(() => {
        underscoreVisible = !underscoreVisible;
        typedTitle.textContent = title + (underscoreVisible ? "|" : " ");
    }, 1000);
});
