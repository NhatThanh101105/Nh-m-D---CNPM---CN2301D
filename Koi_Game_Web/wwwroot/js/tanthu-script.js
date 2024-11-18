let selectedKoiIds = [];

function selectKoi(element) {
    const selectedId = element.getAttribute('data-id');

    // Nếu đã chọn con cá, bỏ chọn
    if (selectedKoiIds.includes(selectedId)) {
        selectedKoiIds = selectedKoiIds.filter(id => id !== selectedId);
        element.classList.remove('selected');
    } else {
        // Nếu chưa chọn đủ 2 con cá, cho phép chọn
        if (selectedKoiIds.length < 2) {
            selectedKoiIds.push(selectedId);
            element.classList.add('selected');
        }
    }

    // Cập nhật giá trị trường ẩn để gửi về server
    document.getElementById('selectedKoiIds').value = selectedKoiIds.join(",");
}

// Đóng thông báo help-user
function closeMessage() {
    const message = document.getElementById('helpMessage');
    message.style.opacity = '0'; // Hiệu ứng mờ dần
    setTimeout(() => {
        message.style.display = 'none'; // Ẩn thông báo sau khi hiệu ứng hoàn tất
    }, 300); // Sau 300ms thì ẩn hẳn
}

// Kiểm tra khi người dùng gửi form
document.getElementById('koiSelectionForm').addEventListener('submit', function (event) {
    if (selectedKoiIds.length !== 2) {
        event.preventDefault();
        alert("Bạn phải chọn chính xác 2 con cá.");
    }
});

// Hàm hiển thị Toast khi tải trang
window.onload = function () {
    showHelpMessageToast();
};

// Hàm để hiển thị toast
function showHelpMessageToast() {
    const toast = document.getElementById('helpMessageToast');
    toast.classList.add('active'); // Thêm class active để làm cho toast trượt vào
}

// Hàm để đóng Toast
function closeHelpMessage() {
    const toast = document.getElementById('helpMessageToast');
    toast.classList.remove('active'); // Xóa class active để làm cho toast trượt ra ngoài
}
