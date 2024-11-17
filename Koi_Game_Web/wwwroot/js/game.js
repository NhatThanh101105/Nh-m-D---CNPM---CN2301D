﻿// Hiển thị danh sách cá khi nhấp vào hồ
function showKoiList() {
    const koiList = document.getElementById("koi-list");
    koiList.classList.toggle("hidden");
}

// Gửi yêu cầu thêm cá vào hồ
function addKoiToPond(koiId) {
    // Gọi API thêm cá vào hồ hoặc gửi yêu cầu qua form nếu dùng MVC truyền thống
    fetch(`/Game/AddKoiToPond?koiId=${koiId}`, {
        method: 'POST'
    }).then(response => {
        if (response.ok) {
            alert("Koi added to pond successfully!");
            // Reload or update UI dynamically
        } else {
            alert("Failed to add koi to pond.");
        }
    });
}

// Tạo chuyển động ngẫu nhiên cho các cá koi
function moveKoiWithVectors(koi) {
    const speed = 0.04123456789; // Tốc độ di chuyển
    const pondContainer = document.querySelector('.pond-container');
    const pondRadius = pondContainer.offsetWidth / 2;
    const koiRadius = koi.offsetWidth / 2;
    const swimRadius = pondRadius * 0.74; // Phạm vi bơi giới hạn

    // Tạo 2 vector ngẫu nhiên ban đầu
    let angle1 = Math.random() * 2 * Math.PI;
    let angle2 = Math.random() * 2 * Math.PI;
    let vector1 = { x: Math.cos(angle1) * speed, y: Math.sin(angle1) * speed };
    let vector2 = { x: Math.cos(angle2) * speed, y: Math.sin(angle2) * speed };

    // Đảm bảo cá bắt đầu hướng lên (0 độ)
  //  koi.style.transform = 'rotate(0deg)';
    koi.style.transformOrigin = 'center top';  // Đảm bảo ảnh xoay từ phần trên của ảnh (đầu cá)

    function animate() {
        // Lấy vị trí hiện tại của cá
        let currentX = parseFloat(koi.style.left) || pondRadius - koiRadius;
        let currentY = parseFloat(koi.style.top) || pondRadius - koiRadius;

        // Tạo hướng di chuyển bằng cách cộng 2 vector
        let directionX = vector1.x + vector2.x;
        let directionY = vector1.y + vector2.y;

        // Tính vị trí tiếp theo của cá
        currentX += directionX;
        currentY += directionY;

        // Tính khoảng cách từ tâm hồ đến vị trí tiếp theo
        const distanceFromCenter = Math.sqrt(Math.pow(currentX - pondRadius, 2) + Math.pow(currentY - pondRadius, 2));

        // Kiểm tra nếu cá chạm đến viền của vùng bơi
       if (distanceFromCenter + koiRadius >= swimRadius) {
    // Tính vector hướng từ vị trí hiện tại về tâm hồ
    const directionToCenterX = pondRadius - currentX;
    const directionToCenterY = pondRadius - currentY;
    const magnitude = Math.sqrt(directionToCenterX ** 2 + directionToCenterY ** 2);

    // Chuẩn hóa vector hướng về tâm
    const normalizedToCenterX = directionToCenterX / magnitude;
    const normalizedToCenterY = directionToCenterY / magnitude;

    // Tính toán lại vector di chuyển (quay hướng về tâm hồ)
    const bounceAngle = Math.PI / 6; // Góc quay lại khi chạm (30 độ)
    const cosBounce = Math.cos(bounceAngle);
    const sinBounce = Math.sin(bounceAngle);

    // Áp dụng ma trận quay cho vector1
    const newVector1X = normalizedToCenterX * cosBounce - normalizedToCenterY * sinBounce;
    const newVector1Y = normalizedToCenterX * sinBounce + normalizedToCenterY * cosBounce;
    vector1 = { x: newVector1X * speed, y: newVector1Y * speed };

    // Áp dụng ma trận quay cho vector2 (với góc đối diện để tạo độ ngẫu nhiên)
    const newVector2X = normalizedToCenterX * cosBounce + normalizedToCenterY * sinBounce;
    const newVector2Y = -normalizedToCenterX * sinBounce + normalizedToCenterY * cosBounce;
    vector2 = { x: newVector2X * speed, y: newVector2Y * speed };
}

        if (Math.random() < 0.0001) { // tỉ lệ thấpppp
            let randomAngle = (Math.random() - 0.5) * Math.PI / 8; // Thay đổi góc ngẫu nhiên trong khoảng ±22.5 độ
            let cosRandom = Math.cos(randomAngle);
            let sinRandom = Math.sin(randomAngle);

            // Cập nhật vector1 với góc ngẫu nhiên
            let newX1 = vector1.x * cosRandom - vector1.y * sinRandom;
            let newY1 = vector1.x * sinRandom + vector1.y * cosRandom;
            vector1 = { x: newX1, y: newY1 };

            // Cập nhật vector2 với góc ngẫu nhiên
            let newX2 = vector2.x * cosRandom - vector2.y * sinRandom;
            let newY2 = vector2.x * sinRandom + vector2.y * cosRandom;
            vector2 = { x: newX2, y: newY2 };
        }
        // Cập nhật vị trí của cá koi
        koi.style.left = `${currentX}px`;
        koi.style.top = `${currentY}px`;

        // Tính góc xoay của cá dựa trên vector di chuyển
        let angle = Math.atan2(directionY, directionX) * (180 / Math.PI); // Convert từ radian sang độ

        angle += 90;
        // Cập nhật trực tiếp góc xoay mà không có hiệu ứng transition
        koi.style.transform = `rotate(${angle}deg)`; 

        // Yêu cầu frame tiếp theo
        requestAnimationFrame(animate);
    }

    animate();
}




function startMovingKoi() {
    const koiItems = document.querySelectorAll('.koi-item');
    const pondContainer = document.querySelector('.pond-container');
    const pondRadius = pondContainer.offsetWidth / 2;

    koiItems.forEach((koi) => {
        const koiRadius = koi.offsetWidth / 2;

        // Tạo vị trí ngẫu nhiên ban đầu cho cá trong phạm vi bơi hợp lệ
        let initialX, initialY, distanceFromCenter;
        do {
            const angle = Math.random() * 2 * Math.PI; // Góc ngẫu nhiên trong vùng tròn
            initialX = pondRadius + (pondRadius * 0.5) * Math.cos(angle) - koiRadius;
            initialY = pondRadius + (pondRadius * 0.5) * Math.sin(angle) - koiRadius;

            // Tính khoảng cách từ tâm hồ đến vị trí ban đầu
            distanceFromCenter = Math.sqrt(Math.pow(initialX - pondRadius, 2) + Math.pow(initialY - pondRadius, 2));
        } while (distanceFromCenter + koiRadius >= pondRadius * 0.6); // Kiểm tra trong phạm vi giới hạn

        koi.style.position = 'absolute';
        koi.style.left = `${initialX}px`;
        koi.style.top = `${initialY}px`;

        // Bắt đầu di chuyển cá với 2 vector ngẫu nhiên
        moveKoiWithVectors(koi);
    });
}

// Khởi động chuyển động khi tải trang
window.addEventListener('DOMContentLoaded', startMovingKoi);
































