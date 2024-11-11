<script>
    // Thông báo ngắn khi chọn hồ cá
    document.querySelectorAll('.select-button').forEach(button => {
        button.addEventListener('click', function(event) {
            event.preventDefault(); // Ngăn điều hướng ngay lập tức
            alert('Hồ cá đã được chọn!');
            setTimeout(() => {
                window.location.href = this.href; // Chuyển hướng sau thông báo
            }, 500); // Đợi 0.5 giây trước khi chuyển trang
        });
    });

    // Hiệu ứng cuộn mượt
    document.querySelector('.back-button').addEventListener('click', function(event) {
        event.preventDefault();
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        });
    });
</script>
