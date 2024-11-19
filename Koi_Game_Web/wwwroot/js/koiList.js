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

function nextPage() {
    if (currentPage < totalPages) {
        currentPage++;
        showPage(currentPage);
        updatePageDisplay();
    }
}

function prevPage() {
    if (currentPage > 1) {
        currentPage--;
        showPage(currentPage);
        updatePageDisplay();
    }
}

// Cập nhật hiển thị trang hiện tại
function updatePageDisplay() {
    document.getElementById("currentPageDisplay").textContent = `Trang ${currentPage} / ${totalPages}`;
}

// Thêm hiển thị trang hiện tại vào HTML để người dùng dễ theo dõi
document.addEventListener('DOMContentLoaded', function () {
    updatePageDisplay();
});

function showKoiDetails(name, imageURL, rare, price, playerKoiId) {
    document.getElementById("modalName").textContent = name;
    document.getElementById("modalImage").src = imageURL;
    document.getElementById("modalRare").textContent = `Độ hiếm: ${rare}`;
    document.getElementById("modalPrice").textContent = `Giá: ${price}`;

    // Thiết lập giá trị cho các input ẩn trong form
    document.getElementById("playerKoiId").value = playerKoiId;
    document.getElementById("price").value = price;

    document.getElementById("koiDetailsModal").style.display = "flex";
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
