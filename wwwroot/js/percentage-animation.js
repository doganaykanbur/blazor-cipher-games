window.animatePercentage = function(targetPercentage) {
    setTimeout(() => {
        const textElement = document.getElementById('percentageText');
        if (!textElement) return;
        
        targetPercentage = Number(targetPercentage) || 0;

        let current = 0;
        const increment = targetPercentage / 60;
        function step() {
            current = Math.min(current + increment, targetPercentage);
            textElement.textContent = Math.round(current) + '%';
            if (current < targetPercentage) requestAnimationFrame(step);
        }
        step();
    }, 50); // 50ms bekle
};
