# Loan Module Structure

## Controller Layer

### Interface: LoanController

#### Methods:

- `initiateLoan(LoanDTO loanDTO)`: Initiates a new loan.
- `getLoanById(String loanId)`: Retrieves a specific loan by its ID.
- `updateLoan(LoanDTO loanDTO)`: Updates loan details.
- `getLoanRepaymentSchedule(String loanId)`: Retrieves the repayment schedule of a loan.
- `updateRepaymentSchedule(String loanId, RepaymentScheduleDTO scheduleDTO)`: Updates the repayment schedule of a loan.
- `updateRemainingBalance(String loanId, BigDecimal remainingBalance)`: Updates the remaining balance of a loan.
- `updateInterest(String loanId, BigDecimal interestRate)`: Updates the interest rate of a loan.
- `updateRepaymentTerm(String loanId, String repaymentTerm)`: Updates the repayment term of a loan.
- `getAllLoans()`: Retrieves all loans.
- `requestLoanStatement(String loanId)`: Provides a detailed statement of a loan.
- `getLoanHistoryForCustomer(String customerId)`: Retrieves loan history for a customer.
- `notifyLatePayment(String loanId)`: Notifies the borrower of a late payment.
- `getAllActiveLoans()`: Retrieves all active loans.
- `calculateRemainingBalance(String loanId)`: Calculates the remaining balance of a loan.
- `makeRepayment(String loanId, BigDecimal repaymentAmount)`: Registers a repayment.
- `applyInterestAccrual(String loanId)`: Applies interest accrual to a loan.
- `notifyUpcomingPayments(String loanId)`: Notifies the borrower of upcoming payments.
- `closeLoan(String loanId)`: Closes a loan.
- `approveLoanModificationRequest(String loanId, ModificationDetailsDTO modificationDetails)`: Approves a loan modification request.
- `rejectLoanModificationRequest(String loanId, String reason)`: Rejects a loan modification request.
- `reviewLoanDefaultRisk(String loanId)`: Reviews the default risk of a loan.

## Service Layer

### Interface: LoanService

#### Methods:

- `initiateLoan(LoanDTO loanDTO)`: Initiates a new loan.
- `findLoanById(String loanId)`: Retrieves a specific loan by its ID.
- `updateLoan(LoanDTO loanDTO)`: Updates loan details.
- `generateRepaymentSchedule(String loanId)`: Generates and retrieves the repayment schedule of a loan.
- `updateRepaymentSchedule(String loanId, RepaymentScheduleDTO scheduleDTO)`: Updates the repayment schedule of a loan.
- `updateRemainingBalance(String loanId, BigDecimal remainingBalance)`: Updates the remaining balance of a loan.
- `updateInterest(String loanId, BigDecimal interestRate)`: Updates the interest rate of a loan.
- `updateRepaymentTerm(String loanId, String repaymentTerm)`: Updates the repayment term of a loan.
- `listAllLoans()`: Retrieves all loans.
- `calculateRemainingBalance(String loanId)`: Calculates the remaining balance of a loan.
- `makeRepayment(String loanId, BigDecimal repaymentAmount)`: Registers a repayment.
- `applyInterestAccrual(String loanId)`: Applies interest accrual to a loan.
- `notifyUpcomingPayments(String loanId)`: Notifies the borrower of upcoming payments.
- `closeLoan(String loanId)`: Closes a loan.
- `getLoanHistoryForCustomer(String customerId)`: Retrieves loan history for a customer.
- `notifyLatePayment(String loanId)`: Notifies the borrower of a late payment.
- `requestLoanStatement(String loanId)`: Provides a detailed statement of a loan.
- `approveLoanModificationRequest(String loanId, ModificationDetailsDTO modificationDetails)`: Approves a loan modification request.
- `rejectLoanModificationRequest(String loanId, String reason)`: Rejects a loan modification request.
- `reviewLoanDefaultRisk(String loanId)`: Reviews the default risk of a loan.

## Repository Layer

### Interface: LoanRepository

#### Methods:

- `Add(Loan loan)`: Saves a new loan record.
- `GetById(String loanId)`: Finds a loan by its ID.
- `Update(Loan loan)`: Updates a loan record.
- `GetAll()`: Retrieves all loans.

## Endpoints and DTO





#### Methods:
- **POST /loans**
  - Description: Initiates a new loan.
  - Request Body: LoanDTO

- **GET /loans/{loanId}**
  - Description: Retrieves a specific loan by its ID.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}**
  - Description: Updates loan details.
  - Path Parameter: loanId (String)
  - Request Body: LoanDTO

- **GET /loans/{loanId}/repayment-schedule**
  - Description: Retrieves the repayment schedule of a loan.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}/repayment-schedule**
  - Description: Updates the repayment schedule of a loan.
  - Path Parameter: loanId (String)
  - Request Body: RepaymentScheduleDTO

- **PUT /loans/{loanId}/remaining-balance**
  - Description: Updates the remaining balance of a loan.
  - Path Parameter: loanId (String)
  - Request Body: BigDecimal

- **PUT /loans/{loanId}/interest-rate**
  - Description: Updates the interest rate of a loan.
  - Path Parameter: loanId (String)
  - Request Body: BigDecimal

- **PUT /loans/{loanId}/repayment-term**
  - Description: Updates the repayment term of a loan.
  - Path Parameter: loanId (String)
  - Request Body: String

- **GET /loans**
  - Description: Retrieves all loans.

- **GET /loans/{loanId}/loan-history**
  - Description: Retrieves loan history for a customer.
  - Path Parameter: customerId (String)

- **GET /loans/{loanId}/notify-late-payment**
  - Description: Notifies the borrower of a late payment.
  - Path Parameter: loanId (String)

- **GET /loans/{loanId}/request-loan-statement**
  - Description: Provides a detailed statement of a loan.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}/make-repayment**
  - Description: Registers a repayment.
  - Path Parameter: loanId (String)
  - Request Body: BigDecimal

- **PUT /loans/{loanId}/apply-interest-accrual**
  - Description: Applies interest accrual to a loan.
  - Path Parameter: loanId (String)

- **GET /loans/{loanId}/notify-upcoming-payments**
  - Description: Notifies the borrower of upcoming payments.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}/close-loan**
  - Description: Closes a loan.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}/approve-modification**
  - Description: Approves a loan modification request.
  - Path Parameter: loanId (String)
  - Request Body: ModificationDetailsDTO

- **PUT /loans/{loanId}/reject-modification**
  - Description: Rejects a loan modification request.
  - Path Parameter: loanId (String)
  - Request Body: String

- **GET /loans/{loanId}/review-default-risk**
  - Description: Reviews the default risk of a loan.
  - Path Parameter: loanId (String)


### DTOs

#### LoanDTO

Attributes:
- `loan_id: String`
- `acc_id: String`
- `loan_type: String`
- `loan_type_id: String`
- `loan_amount: BigDecimal`
- `disbursement_date: Date`
- `repayment_term: String`
- `interest_rate: BigDecimal`
- `monthly_installment: BigDecimal`
- `remaining_balance: BigDecimal`
- `repayment_schedule: RepaymentScheduleDTO`
- `initiated_repayments: List<Repayment>`

#### RepaymentScheduleDTO

Attributes:
- `repayment_schedule: String`

#### ModificationDetailsDTO

Attributes:
- `modification_details: String`
