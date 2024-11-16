const koiImages = [
    '@Url.Content("~/images/background/koi1.png")',
    '@Url.Content("~/images/background/koi2.png")',
    '@Url.Content("~/images/background/koi3.png")'
];

const koiContainer = document.getElementById('koiContainer');

function createKoi() {
    const koi = document.createElement('img');
    const randomIndex = Math.floor(Math.random() * koiImages.length);
    koi.src = koiImages[randomIndex];
    koi.classList.add('koi');

    koi.style.top = Math.random() * 100 + '%';
    koi.style.left = Math.random() * 100 + '%';

    console.log("Created koi:", koi); // Kiểm tra log trong console
    koiContainer.appendChild(koi);

    moveKoi(koi);
}

function moveKoi(koi) {
    const duration = Math.random() * 3000 + 2000; // Thời gian di chuyển ngẫu nhiên
    const targetX = Math.random() * 100;
    const targetY = Math.random() * 100;

    koi.animate([
        { transform: 'translate(0, 0)' },
        { transform: `translate(${targetX}%, ${targetY}%)` }
    ], {
        duration: duration,
        easing: 'ease-in-out',
        fill: 'forwards'
    }).onfinish = () => {
        koi.remove(); // Xóa cá koi sau khi di chuyển xong
        createKoi(); // Tạo cá koi mới
    };
}

