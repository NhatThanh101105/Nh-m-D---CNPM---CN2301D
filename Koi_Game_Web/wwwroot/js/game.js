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
