// Đợi đến khi trang tải hoàn tất
document.addEventListener("DOMContentLoaded", () => {
    const breedButton = document.getElementById("breedButton");
    const koiContainer = document.querySelector(".koi-container");

    // Xử lý sự kiện khi người dùng nhấn nút "Thêm Cá Koi Mới"
    breedButton.addEventListener("click", () => {
        let newKoi = createKoi();
        koiContainer.appendChild(newKoi);

        // Tự động xóa cá sau một khoảng thời gian để giữ khu vực sạch sẽ
        setTimeout(() => {
            newKoi.remove();
        }, 10000); // Cá sẽ biến mất sau 10 giây
    });
});

// Hàm tạo ra một cá koi với chuyển động bơi ngẫu nhiên
function createKoi() {
    let koi = document.createElement("div");
    koi.classList.add("koi-fish");

    // Đặt vị trí ngẫu nhiên cho cá koi
    koi.style.left = `${Math.random() * 80}vw`;
    koi.style.top = `${Math.random() * 80}vh`;

    // Áp dụng một hướng ngẫu nhiên để cá bơi (trái -> phải hoặc ngược lại)
    if (Math.random() > 0.5) {
        koi.style.animationDirection = "normal";
    } else {
        koi.style.animationDirection = "reverse";
    }

    // Thêm hiệu ứng di chuyển nhẹ để giống bơi lội
    koi.addEventListener("mouseover", () => {
        koi.style.transform = `scale(${Math.random() * 0.3 + 1.1})`;
    });
    koi.addEventListener("mouseleave", () => {
        koi.style.transform = `scale(1)`;
    });

    return koi;
}
