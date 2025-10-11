# Implementation Notes for Commission Calculator Assessment

## Decisions and Trade-offs
- *Backend (C#/.NET):* Used DTOs (CommissionInput/Result) for structured requests/responses. Validation via DataAnnotations ([Required], [Range] 0-1e6) for non-negative/sensible bounds. Decimal for currency precision. Simple MVC controller with [HttpPost] and ModelState for errors—trade-off: No custom exceptions for timebox; relied on BadRequest. Logic mirrors business rules (20%/35% Avalpha, 2%/7.55% Competitor).
- *Frontend (React):* Async fetch with loading state, client-side validation mirroring backend (non-negative, bounds). Parsed inputs to numbers; displayed breakdowns with toFixed(2) for £ formatting. Added Avalpha advantage for better UX. Trade-off: No TypeScript; used plain JS for speed. Error handling shows API messages.
- *Security/Errors:* CORS in Program.cs for dev (localhost:3000). Graceful UI errors (red text). No auth needed per scope.
- *Unfinished:* No tests (xUnit/Jest recommended but not required; focused on core). Localhost runtime issue (not found)—likely port/config; logic verified via code (e.g., 12/12/12: Avalpha £79.20, Competitor £13.75, Advantage £65.45).
- *Reflection:* New to C#—leveraged React strengths for quick wiring. Debugged spelling/route mismatches causing 404s.

## How to Run
- Backend: dotnet restore; dotnet build AvalphaTechnologies.CommissionCalculator.csproj; dotnet run --project AvalphaTechnologies.CommissionCalculator.csproj[](http://localhost:5111)
- Frontend: cd ui/my-app; npm install; npm start[](http://localhost:3000)

## How to Test
- Curl: curl -X POST http://localhost:5111/commission -H "Content-Type: application/json" -d '{"localSalesCount":12,"foreignSalesCount":12,"averageSaleAmount":12}' (expect JSON with avalphaTotal:79.2)
- UI: localhost:3000, enter values, verify display/formatting.
