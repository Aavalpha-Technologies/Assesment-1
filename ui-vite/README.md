# **Avalpha Technologies \- Commission Calculator**

This repository contains the implementation of a full-stack commission calculator application, featuring a .NET backend API and a React frontend. The project calculates and compares commission amounts for Avalpha Technologies against a competitor based on user-provided sales data.

## **Tech Stack**

* **Backend:** C\# / .NET 8  
* **Frontend:** React (Vite), JavaScript  
* **API Testing:** Swagger

## **Key Decisions & Trade-offs**

### **Frontend: Migration from Create React App to Vite**

The initial frontend was scaffolded using Create React App (CRA). We made the decision to migrate to **Vite** for the following reasons:

* **Modern Tooling:** Vite offers a significantly faster development experience with its native ES module-based dev server.  
* **Performance:** Hot Module Replacement (HMR) is near-instantaneous, which boosts productivity.  
* **Simplified Configuration:** Vite provides sensible defaults and requires less configuration overhead compared to the complexities of Webpack in CRA.  
* **Deprecation of CRA:** With Create React App being deprecated, moving to a modern, actively maintained tool like Vite ensures long-term stability and access to a wider range of packages and support.

### **Backend: Service-Oriented Architecture**

To ensure the backend is robust, maintainable, and testable, we adopted a **separation of concerns** approach instead of placing all logic in the controller.

* **Controllers:** The CommissionController is lean and its only responsibility is to handle HTTP requests and responses. It knows nothing about the business rules.  
* **Services:** All business logic for calculating commissions resides in a dedicated CommissionService. This service is injected into the controller, making it easy to test the calculation logic in isolation.  
* **DTOs (Data Transfer Objects):** We defined clear CommissionRequest and CommissionResponse records to act as a strict contract for our API. This ensures predictable and strongly-typed data structures between the frontend and backend.

## **Features Implemented**

This project successfully implements the core requirements outlined in the technical assessment.

✔️ **Wire up Frontend ↔ Backend:** The React application makes live API calls to the .NET backend to fetch commission calculations.

✔️ **Implement Calculation Logic:** All commission rates and calculations are implemented on the backend within the CommissionService, ensuring a single source of truth.

✔️ **Validate Inputs:** The backend validates all incoming data using .NET's built-in validation attributes (\[Required\], \[Range\]) on the CommissionRequest DTO. If validation fails, the API returns a clear 400 Bad Request error.

✔️ **Return a Typed, Well-Structured Response:** The API returns a predictable JSON object defined by the CommissionResponse DTO, which includes a clear, nested structure for both Avalpha's and the competitor's commission details.

✔️ **Display Results in the UI:** The frontend displays the calculated local, foreign, and total commissions for both parties in a clear and readable format.

✔️ **Handle Errors Gracefully:**

* **Backend:** A try-catch block in the controller handles any unexpected server errors, returning a generic 500 Internal Server Error response to prevent leaking implementation details.  
* **UI:** The React app's API service catches errors from the fetch call. If the API returns an error, a user-friendly message is displayed below the form.

## **How to Run the Project**

### **Backend (.NET API)**

1. Navigate to the backend project directory: `cd api` 
2. Install dependencies: `dotnet restore` 
3. Run the application: `dotnet run`  
4. The API will be running on the port specified in Properties/launchSettings.json (e.g., `http://localhost:5111`).

### **Frontend (React \+ Vite)**

1. Navigate to the frontend project directory. `cd ui-vite`
2. Install dependencies: `npm install`  
3. Run the application: `npm run dev`  
4. The frontend will be available at `http://localhost:5173`.

**Note:** Ensure the `API\_BASE\_URL` constant in src/services/api.js matches the backend's running port.

## **How to Test**

### **Backend API**

1. Run the backend project.  
2. Navigate to /swagger in your browser (e.g., http://localhost:5111/swagger).  
3. Use the Swagger UI to manually test the POST /api/commission/calculate endpoint with different JSON payloads.

### **Frontend UI**

1. Run both the backend and frontend servers.  
2. Open the application in your browser.  
3. Enter different values into the form fields and click "Calculate" to verify the results.  
4. Test the input validation by leaving fields empty or entering invalid data to see the error handling.

## **Unfinished Work & Future Improvements**

* **Currency Formatting:** The UI currently displays raw numbers with a hardcoded "£" symbol. A future improvement would be to implement robust currency formatting on the frontend using Intl.NumberFormat to handle different locales and decimal places correctly.  
* **Unit & Integration Tests:** While the architecture supports testing, formal unit tests (e.g., xUnit for the service layer, React Testing Library for components) have not yet been written.  
* **Environment Variables:** The API base URL is currently hardcoded. This should be moved to a .env file for better configuration management between development and production environments.
