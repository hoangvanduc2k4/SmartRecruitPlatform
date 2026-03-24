
    // Currency Formatting Utilities
    function formatVND(value) {
        if (!value && value !== 0) return '';
        let cleanValue = value.toString().replace(/\D/g, '');
        if (cleanValue === '') return '';
        return cleanValue.replace(/\B(?=(\d{3})+(?!\d))/g, ".");
    }

function unformatVND(value) {
    if (!value) return '';
    return value.toString().replace(/\./g, '');
}

document.addEventListener('DOMContentLoaded', function () {
    // Auto-format initial values
    document.querySelectorAll('.currency-input').forEach(input => {
        input.value = formatVND(input.value);
    });

    // Handle input events for real-time formatting
    document.addEventListener('input', function (e) {
        if (e.target.classList.contains('currency-input')) {
            let cursorPostion = e.target.selectionStart;
            let oldLength = e.target.value.length;

            e.target.value = formatVND(e.target.value);

            // Adjust cursor position
            let newLength = e.target.value.length;
            cursorPostion = cursorPostion + (newLength - oldLength);
            e.target.setSelectionRange(cursorPostion, cursorPostion);
        }
    });

    // Strip dots before form submission
    document.addEventListener('submit', function (e) {
        let forms = e.target.querySelectorAll('.currency-input');
        if (e.target.classList.contains('currency-input')) {
            // If the target itself is an input (unlikely for submit, but safe)
            e.target.value = unformatVND(e.target.value);
        }
        e.target.querySelectorAll('.currency-input').forEach(input => {
            input.value = unformatVND(input.value);
        });
    });
});