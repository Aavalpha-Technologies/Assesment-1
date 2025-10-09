import React, { useState } from 'react';
import './App.css';

function App() {
  const [formData, setFormData] = useState({
    localSalesCount: '',
    foreignSalesCount: '',
    averageSaleAmount: '',
  });
  const [result, setResult] = useState(null);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const validateInputs = () => {
    const { localSalesCount, foreignSalesCount, averageSaleAmount } = formData;
    if (!localSalesCount || !foreignSalesCount || !averageSaleAmount) {
      setError('All fields are required');
      return false;
    }
    const local = parseInt(localSalesCount);
    const foreign = parseInt(foreignSalesCount);
    const avg = parseFloat(averageSaleAmount);
    if (local < 0 || foreign < 0 || avg < 0) {
      setError('Inputs must be non-negative');
      return false;
    }
    if (local > 1000000 || foreign > 1000000 || avg > 1000000) {
      setError('Inputs exceed sensible upper bounds (max 1,000,000)');
      return false;
    }
    return true;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(null);
    setResult(null);
    setLoading(true);
    if (!validateInputs()) {
      setLoading(false);
      return;
    }

    try {
      const response = await fetch('http://localhost:5111/commision', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          localSalesCount: parseInt(formData.localSalesCount),
          foreignSalesCount: parseInt(formData.foreignSalesCount),
          averageSaleAmount: parseFloat(formData.averageSaleAmount),
        }),
      });
      if (!response.ok) {
        const errData = await response.json();
        throw new Error(JSON.stringify(errData) || 'API error');
      }
      const data = await response.json();
      setResult(data);
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="App">
      <header className="App-header">
        <h1>Commission Calculator</h1>
        <form onSubmit={handleSubmit}>
          <label htmlFor="localSalesCount">Local Sales Count</label>
          <input
            name="localSalesCount"
            type="number"
            value={formData.localSalesCount}
            onChange={handleChange}
            min="0"
            required
          /><br />

          <label htmlFor="foreignSalesCount">Foreign Sales Count</label>
          <input
            name="foreignSalesCount"
            type="number"
            value={formData.foreignSalesCount}
            onChange={handleChange}
            min="0"
            required
          /><br />

          <label htmlFor="averageSaleAmount">Average Sale Amount (£)</label>
          <input
            name="averageSaleAmount"
            type="number"
            value={formData.averageSaleAmount}
            onChange={handleChange}
            min="0"
            step="0.01"
            required
          /><br />

          <button type="submit" disabled={loading}>
            {loading ? 'Calculating...' : 'Calculate'}
          </button>
        </form>
      </header>

      {error && <p style={{ color: 'red' }}>Error: {error}</p>}

      {result && (
        <div>
          <h3>Results</h3>
          <h4>Avalpha Technologies Commission</h4>
          <p>Local: £{result.avalphaLocal.toFixed(2)}</p>
          <p>Foreign: £{result.avalphaForeign.toFixed(2)}</p>
          <p>Total: £{result.avalphaTotal.toFixed(2)}</p>
          <h4>Competitor Commission</h4>
          <p>Local: £{result.competitorLocal.toFixed(2)}</p>
          <p>Foreign: £{result.competitorForeign.toFixed(2)}</p>
          <p>Total: £{result.competitorTotal.toFixed(2)}</p>
          <p><strong>Avalpha Advantage: £{(result.avalphaTotal - result.competitorTotal).toFixed(2)}</strong></p>
        </div>
      )}
    </div>
  );
}

export default App;