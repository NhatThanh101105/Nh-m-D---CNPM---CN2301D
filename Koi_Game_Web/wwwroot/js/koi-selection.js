function selectKoi(element) {
    // Xóa lớp chọn từ tất cả cá
    const koiImages = document.querySelectorAll('.koi-image');
    koiImages.forEach(koi => koi.classList.remove('selected'));

    // Thêm lớp chọn cho cá đã nhấp
    element.classList.add('selected');

    // Lưu màu cá vào input hidden
    const color = element.getAttribute('data-color');
    document.getElementById('selectedKoiColor').value = color;
}
