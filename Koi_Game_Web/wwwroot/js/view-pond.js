// pondActions.js

document.addEventListener('DOMContentLoaded', function () {
    // Sự kiện khi nhấn nút "Bắt cá"
    document.querySelectorAll('.removeKoiForm').forEach(function (form) {
        form.addEventListener('submit', function (event) {
            event.preventDefault(); // Ngừng hành động mặc định
            alert('Bắt cá thành công!');
            // Có thể thêm logic gửi form hoặc thực hiện hành động khác ở đây
            form.submit(); // Gửi form sau khi hiển thị thông báo
        });
    });

    // Sự kiện khi nhấn nút "Thả vào hồ"
    document.querySelectorAll('.addKoiForm').forEach(function (form) {
        form.addEventListener('submit', function (event) {
            event.preventDefault(); // Ngừng hành động mặc định
            alert('Thả cá vào hồ thành công!');
            // Có thể thêm logic gửi form hoặc thực hiện hành động khác ở đây
            form.submit(); // Gửi form sau khi hiển thị thông báo
        });
    });
});
