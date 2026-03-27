document.addEventListener("DOMContentLoaded", function () {
    if (!window.appConfig || !window.appConfig.accessToken) return;

    const notifBadge = document.getElementById("notif-badge");
    const notifList = document.getElementById("notification-list");
    const emptyNotif = document.getElementById("empty-notif");
    
    let unreadCount = 0;

    // 1. Setup SignalR Connection
    const connection = new signalR.HubConnectionBuilder()
        .withUrl(window.appConfig.notificationHubUrl, {
            accessTokenFactory: () => window.appConfig.accessToken
        })
        .withAutomaticReconnect()
        .build();

    window.notificationHubConnection = connection;

    // 2. Listen for new notifications
    connection.on("ReceiveNotification", function (notification) {
        unreadCount++;
        updateBadge();
        addNotificationToUI(notification, true);
    });

    // Start connection and fetch initial data
    connection.start().then(function () {
        console.log("SignalR Connected for Notifications.");
        fetchExistingNotifications();
    }).catch(function (err) {
        console.error("SignalR Connection Error: ", err.toString());
        // Fallback: Still fetch if SignalR fails
        fetchExistingNotifications();
    });

    // 3. API Calls to fetch history
    async function fetchExistingNotifications() {
        console.log("Fetching existing notifications...");
        try {
            const apiUrl = `${window.appConfig.apiBaseUrl}Notifications?pageSize=10`;
            console.log("Calling API:", apiUrl);
            
            const response = await fetch(apiUrl, {
                headers: {
                    'Authorization': `Bearer ${window.appConfig.accessToken}`
                }
            });

            if (response.ok) {
                const result = await response.json();
                // The API wraps PagedList in a PagedResponse where "data" directly holds the array
                if (result.success && result.data && Array.isArray(result.data)) {
                    const items = result.data;
                    items.forEach(item => {
                        if (!item.isRead) unreadCount++;
                        addNotificationToUI(item, false);
                    });
                    updateBadge();
                }
            }
        } catch (error) {
            console.error("Failed to fetch notifications", error);
        }
    }

    // 4. UI Rendering
    function addNotificationToUI(notification, isPrepend) {
        if (emptyNotif) emptyNotif.style.display = 'none';

        const div = document.createElement("div");
        div.className = `p-4 flex-col text-left rounded-2xl border transition-all cursor-pointer group ${notification.isRead ? 'bg-white border-slate-100 opacity-60' : 'bg-slate-50 border-indigo-100 hover:border-indigo-300 shadow-sm mb-2'}`;
        div.id = `notif-${notification.id}`;
        
        let titleColor = notification.isRead ? 'text-slate-600' : 'text-slate-900 group-hover:text-indigo-600';
        let timeColor = notification.isRead ? 'text-slate-300' : 'text-indigo-400';

        div.innerHTML = `
            <div class="flex justify-between items-start mb-1">
                <p class="text-[11px] font-black ${titleColor} transition-colors capitalize">${notification.title || notification.type}</p>
                <span class="text-[9px] font-bold ${timeColor}">${timeAgo(notification.createdAt)}</span>
            </div>
            <p class="text-[10px] text-slate-500 leading-relaxed">${notification.message}</p>
        `;

        div.onclick = () => {
            if (!notification.isRead) markAsRead(notification.id, div, notification);
            
            let targetUrl = notification.redirectUrl;
            
            // Fallback Logic for Application Notifications
            if (!targetUrl || targetUrl.includes('JobDetail')) {
                const appMatch = (notification.title + " " + notification.message).match(/#APP-(\d+)/i);
                if (appMatch && appMatch[1]) {
                    targetUrl = `/CandidatePreview/${appMatch[1]}`;
                }
            }
            
            if (targetUrl) window.location.href = targetUrl;
        };

        if (isPrepend && notifList.firstChild) {
            notifList.insertBefore(div, notifList.firstChild);
        } else {
            notifList.appendChild(div);
        }
    }

    function updateBadge() {
        if (unreadCount > 0) {
            notifBadge.innerText = unreadCount > 99 ? '99+' : unreadCount;
            notifBadge.classList.remove('hidden');
        } else {
            notifBadge.classList.add('hidden');
        }
    }

    async function markAsRead(id, element, notificationObj) {
        // Guard: If already processed as read in this session, skip
        if (element.classList.contains('opacity-60')) return;

        try {
            const apiUrl = `${window.appConfig.apiBaseUrl}Notifications/${id}/read`;
            const response = await fetch(apiUrl, {
                method: 'PATCH',
                headers: {
                    'Authorization': `Bearer ${window.appConfig.accessToken}`
                }
            });

            if (response.ok) {
                // Decrement counter only once
                unreadCount = Math.max(0, unreadCount - 1);
                updateBadge();
                
                // Update local state to prevent multiple triggers
                if (notificationObj) notificationObj.isRead = true;

                // Update UI classes to "Read" state
                element.classList.remove('bg-slate-50', 'border-indigo-100', 'shadow-sm', 'mb-2');
                element.classList.add('bg-white', 'border-slate-100', 'opacity-60');
                const titleEl = element.querySelector('p');
                if (titleEl) titleEl.classList.replace('text-slate-900', 'text-slate-600');
            }
        } catch (error) {
            console.error("Mark as read failed", error);
        }
    }



    // Utility
    function timeAgo(dateString) {
        if (!dateString) return 'Just now';
        
        // Ensure the date string is parsed as UTC
        // The API returns DateTime.UtcNow, which might be "2023-10-27T10:00:00" (no Z).
        // Let's force it to UTC if it doesn't end with Z
        const isUtcStr = dateString.endsWith('Z') || dateString.includes('+') ? dateString : dateString + 'Z';
        const date = new Date(isUtcStr);
        const seconds = Math.floor((new Date() - date) / 1000);
        
        let interval = seconds / 31536000;
        if (interval > 1) return Math.floor(interval) + "y ago";
        interval = seconds / 2592000;
        if (interval > 1) return Math.floor(interval) + "mo ago";
        interval = seconds / 86400;
        if (interval > 1) return Math.floor(interval) + "d ago";
        interval = seconds / 3600;
        if (interval > 1) return Math.floor(interval) + "h ago";
        interval = seconds / 60;
        if (interval > 1) return Math.floor(interval) + "m ago";
        return "Just now";
    }
});
