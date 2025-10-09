# Avalpha Commission Calculator - Notes

## Project Overview
This project implements a **commission calculator** for Avalpha Technologies. It calculates commissions for **local and foreign sales** for both Avalpha and competitors. The project consists of a **C#/.NET backend API** and a **React frontend**.

- **Backend**: ASP.NET Core Web API  
  - `CommissionService` handles the calculation logic  
  - `CommissionController` exposes `/commission` endpoint  

- **Frontend**: React  
  - Form to input `localSalesCount`, `foreignSalesCount`, and `averageSaleAmount`  
  - Displays Avalpha and Competitor commissions instantly  

---

## Key Decisions
- Created **CommissionService** to separate business logic from controller  
- Controller handles only API request/response  
- Used **in-memory calculations** instead of a database for simplicity  
- React frontend communicates with backend via **fetch API**  

---

## Trade-offs
- No database; calculations are lost on restart  
- Unit tests partially implemented (could be expanded for production)  
- Frontend styling is basic for functionality and clarity  

---

## Folder Structure

Assesment-1/
├─ api/
│ ├─ Controllers/
│ │ CommisionController.cs
│ ├─ Models/
│ │ CommissionRequest.cs
│ │ CommissionResponse.cs
│ ├─ Services/
│ │ CommissionService.cs
│ ├─ Program.cs
│ ├─ Assesment-1.csproj
├─ ui/
│ ├─ src/
│ │ components/
│ │ CommissionForm.js
│ │ services/
│ │ api.js
│ │ App.js
│ │ index.js
├─ README-notes.md


---

## How to Run

### Backend (API)
1. Open `api` project in **Visual Studio**  
2. Build solution → `Ctrl+Shift+B`  
3. Run API → Swagger available at `https://localhost:5001/swagger`  

### Frontend (React)
1. Open `ui` folder in **VS Code**  
2. Install dependencies: `npm install`  
3. Start React app: `npm start`  
4. Open browser: `http://localhost:3000`  
5. Enter sales data → see Avalpha & Competitor commissions

---

## Unfinished / Future Improvements
- Add **unit tests** for `CommissionService`  
- Improve **frontend UI/UX styling**  
- Add **database persistence** for sales and commission records  
- Add **error handling** for invalid inputs  

---

## Author
Mohit Patil


