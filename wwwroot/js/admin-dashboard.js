// Function to toggle dropdown menu visibility
function toggleDropdown() {
    var dropdown = document.getElementById("adminDropdown");
    dropdown.style.display = dropdown.style.display === "block" ? "none" : "block";
}

// Close dropdown when clicking outside
document.addEventListener("click", function (event) {
    var dropdown = document.getElementById("adminDropdown");
    if (!event.target.closest(".dropdown-container")) {
        dropdown.style.display = "none";
    }
});
