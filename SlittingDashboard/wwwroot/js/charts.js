window.renderOrdersHoursChart = (labels, orders, hours) => {
    const ctx = document.getElementById('ordersHoursChart').getContext('2d');

    if (window.ordersHoursChartInstance) {
        window.ordersHoursChartInstance.destroy();
    }

    window.ordersHoursChartInstance = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [
                {
                    label: 'Orders',
                    data: orders,
                    borderColor: 'rgba(75, 192, 192, 1)',
                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                    tension: 0.3,
                    fill: true
                },
                {
                    label: 'Hours Worked',
                    data: hours,
                    borderColor: 'rgba(255, 99, 132, 1)',
                    backgroundColor: 'rgba(255, 99, 132, 0.2)',
                    tension: 0.3,
                    fill: true
                }
            ]
        },
        options: {
            responsive: true,
            plugins: {
                legend: { position: 'top' },
                title: {
                    display: true,
                    text: 'Orders vs Hours Worked'
                }
            },
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
};