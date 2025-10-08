const API_BASE_URL = 'http://localhost:5111'; // Adjust if your backend runs on a different port

/**
 * Calls the backend to calculate commissions.
 * @param {object} requestData - The data to send to the API.
 * @param {number} requestData.localSalesCount
 * @param {number} requestData.foreignSalesCount
 * @param {number} requestData.averageSaleAmount
 * @returns {Promise<object>} The commission calculation results.
 */
export async function calculateCommission(requestData) {
    const response = await fetch(`${API_BASE_URL}/api/commission/calculate`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(requestData),
    });

    if (!response.ok) {
        // Try to get a meaningful error message from the backend
        const errorData = await response.json().catch(() => null);
        throw new Error(errorData?.message || `API Error: ${response.statusText}`);
    }

    return response.json();
}
