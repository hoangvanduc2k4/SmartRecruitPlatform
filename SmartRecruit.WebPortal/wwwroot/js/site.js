
    // Currency Formatting Utilities
    function formatVND(value) {
        if (!value && value !== 0) return '';
        
        // Handle decimal values - remove decimal part
        let cleanValue = value.toString().replace(/\.\d+$/, '').replace(/\D/g, '');
        if (cleanValue === '') return '';
        
        return cleanValue.replace(/\B(?=(\d{3})+(?!\d))/g, ".");
    }

function unformatVND(value) {
    if (!value) return '';
    return value.toString().replace(/\./g, '');
}

// Parse user input with support for "tr" (triệu) and "k" (nghìn)
function parseVNDInput(value) {
    if (!value) return '';
    
    let input = value.toString().toLowerCase().trim();
    
    // Handle "tr" (triệu - million)
    if (input.includes('tr')) {
        let number = parseFloat(input.replace(/[^\d.]/g, ''));
        if (!isNaN(number)) {
            return (number * 1000000).toString();
        }
    }
    
    // Handle "k" (nghìn - thousand)  
    if (input.includes('k')) {
        let number = parseFloat(input.replace(/[^\d.]/g, ''));
        if (!isNaN(number)) {
            return (number * 1000).toString();
        }
    }
    
    // Handle regular numbers (remove dots and non-digits)
    return input.replace(/\D/g, '');
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

            // Parse input first (handle tr, k)
            let parsedValue = parseVNDInput(e.target.value);
            // Then format for display
            e.target.value = formatVND(parsedValue);

            // Adjust cursor position
            let newLength = e.target.value.length;
            cursorPostion = cursorPostion + (newLength - oldLength);
            e.target.setSelectionRange(cursorPostion, cursorPostion);
        }
    });

    // Strip dots before form submission
    document.addEventListener('submit', function (e) {
        e.target.querySelectorAll('.currency-input').forEach(input => {
            input.value = unformatVND(input.value);
        });
    });
});
