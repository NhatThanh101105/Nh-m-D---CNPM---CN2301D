let currentPage = 1;
let totalPages;

document.addEventListener('DOMContentLoaded', function () {
    totalPages = document.querySelectorAll('.page').length;
    console.log("Total pages:", totalPages); // Kiểm tra số trang
    showPage(currentPage);
});

function showPage(pageNumber) {
    // Ẩn tất cả các trang
    document.querySelectorAll('.page').forEach(page => {
        page.classList.remove('active');
    });

    // Hiển thị trang hiện tại
    const currentPageElement = document.getElementById(`page-${pageNumber}`);
    if (currentPageElement) {
        currentPageElement.classList.add('active');
    }
}


function showKoiDetails(name, imgURL, rare, price, color) {
    const modal = document.getElementById("koiDetailsModal");
    modal.classList.add("show");
    modal.style.display = "flex";
    document.getElementById("modalImage").src = imgURL;
    document.getElementById("modalName").textContent = `Tên: ${name}`;
    document.getElementById("modalRare").textContent = `Độ hiếm: ${rare}`;
    document.getElementById("modalPrice").textContent = `Giá: ${price}`;
    document.getElementById("modalColor").textContent = `Màu sắc: ${color }`;
}

function closeModal() {
    document.getElementById("koiDetailsModal").style.display = "none";
}
window.onclick = function (event) {
    const modal = document.getElementById("koiDetailsModal");
    if (event.target === modal) {
        modal.style.display = "none";
    }
}