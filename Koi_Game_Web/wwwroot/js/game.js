// Hiển thị danh sách cá khi nhấp vào hồ
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
    const speed = 0.6; // Tốc độ di chuyển
    const pondContainer = document.querySelector('.pond-container');
    const pondRadius = pondContainer.offsetWidth / 2;
    const koiRadius = koi.offsetWidth / 2;
    const swimRadius = pondRadius * 0.74; // Phạm vi bơi giới hạn

    let angle = Math.random() * 2 * Math.PI; // Góc ban đầu ngẫu nhiên
    let vector = { x: Math.cos(angle) * speed, y: Math.sin(angle) * speed };

    //koi.style.transition = 'transform 0.1s linear'; // Hiệu ứng xoay mềm mại
    koi.style.position = 'absolute'; // Đảm bảo cá có thể di chuyển
    koi.style.transformOrigin = 'center top'; // Đặt điểm xoay ở đầu cá

    let currentX = parseFloat(koi.style.left) || pondRadius - koiRadius;
    let currentY = parseFloat(koi.style.top) || pondRadius - koiRadius;

    function animate() {
        // Cập nhật vị trí tiếp theo
        currentX += vector.x;
        currentY += vector.y;

        // Kiểm tra giới hạn vùng bơi
        const distanceFromCenter = Math.sqrt(Math.pow(currentX - pondRadius, 2) + Math.pow(currentY - pondRadius, 2));

        if (distanceFromCenter + koiRadius >= swimRadius) {
            // Nếu chạm biên, quay lại hướng về tâm hồ
            const directionToCenterX = pondRadius - currentX;
            const directionToCenterY = pondRadius - currentY;
            const magnitude = Math.sqrt(directionToCenterX ** 2 + directionToCenterY ** 2);

            // Hướng mới về tâm
            vector.x = (directionToCenterX / magnitude) * speed;
            vector.y = (directionToCenterY / magnitude) * speed;

            // Tính góc quay mới
            angle = Math.atan2(vector.y, vector.x);
        }

        // Thêm nhiễu nhỏ vào góc xoay (để tạo chuyển động tự nhiên)
        const maxAngleChange = Math.PI / 36; // Giới hạn thay đổi góc ±5 độ
        angle += Math.random() * maxAngleChange - maxAngleChange / 2;

        // Cập nhật vector di chuyển dựa trên góc mới
        vector.x = Math.cos(angle) * speed;
        vector.y = Math.sin(angle) * speed;

        // Cập nhật góc xoay của cá
        let rotationAngle = angle * (180 / Math.PI); // Chuyển từ radian sang độ
        rotationAngle += 90; // Điều chỉnh để hình ảnh khớp với hướng bơi
        koi.style.transform = `rotate(${rotationAngle}deg)`;

        // Cập nhật vị trí của cá koi
        koi.style.left = `${currentX}px`;
        koi.style.top = `${currentY}px`;

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




































