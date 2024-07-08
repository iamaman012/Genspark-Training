# Loan Module



### Controller Layer

**Interface: LoanController**

- **Methods**:
  - `initiateLoan(LoanDTO loanDTO)`: Endpoint for initiating a new loan.
  - `getLoanById(String loanId)`: Endpoint for retrieving a specific loan by its ID.
  - `updateLoan(LoanDTO loanDTO)`: Endpoint for updating loan details.
  - `getLoanRepaymentSchedule(String loanId)`: Endpoint for retrieving the repayment schedule of a loan.
  - `updateRepaymentSchedule(String loanId, RepaymentScheduleDTO scheduleDTO)`: Endpoint for updating the repayment schedule of a loan.
  - `updateRemainingBalance(String loanId, BigDecimal remainingBalance)`: Endpoint for updating the remaining balance of a loan.
  - `updateInterest(String loanId, BigDecimal interestRate)`: Endpoint for updating the interest rate of a loan.
  - `updateRepaymentTerm(String loanId, String repaymentTerm)`: Endpoint for updating the repayment term of a loan.
  - `getAllLoans()`: Endpoint for retrieving all loans.
  - `requestLoanStatement(loan_id)`:Provides the borrower with a detailed statement of their active loan, including transaction history, repayments, and current status.
  - `getLoanHistoryForCustomer(customer_id)`:Retrieves a history of all loans associated with a specific customer, including both active and closed loans.
  - `notifyLatePayment(loan_id)`:Sends notifications to the borrower if a payment on the active loan is late or overdue.
  - `getAllActiveLoans()`:Retrieves a list of all currently active loans.
  - `calculateRemainingBalance(loan_id)`:Calculates the remaining balance of the active loan, considering repayments and accrued interest.
  - `makeRepayment(loan_id, repayment_amount)`:Registers a repayment made by the borrower towards the active loan, updating the remaining balance and repayment history.
  - `applyInterestAccrual(loan_id)`:Applies interest accrual to the active loan based on its current balance and interest rate.
  - `notifyUpcomingPayments(loan_id)`:Sends notifications to the borrower about upcoming loan payments.
  - `closeLoan(loan_id)`:Marks the active loan as closed or fully repaid, updating its status and finalizing any outstanding financial transactions.
  -  `approveLoanModificationRequest(loan_id, modification_details)`: Processes and approves requests for modifications to an active loan, such as term extensions or changes in repayment conditions
  - `rejectLoanModificationRequest(loan_id, reason)`:Rejects requests for modifications to an active loan, notifying the borrower of the decision.
  - `reviewLoanDefaultRisk(loan_id)`:Evaluates the risk of default on an active loan based on borrower behavior and financial indicators, initiating appropriate risk management actions if necessary.



### Service Layer

**Interface: LoanService**

- **Methods**:
  - `initiateLoan(LoanDTO loanDTO)`: Handles the initiation of a new loan.
  - `findLoanById(String loanId)`: Retrieves a specific loan by its ID.
  - `updateLoan(LoanDTO loanDTO)`: Updates loan details.
  - `generateRepaymentSchedule(String loanId)`: Generates and retrieves the repayment schedule of a loan.
  - `updateRepaymentSchedule(String loanId, RepaymentScheduleDTO scheduleDTO)`: Updates the repayment schedule of a loan.
  - `updateRemainingBalance(String loanId, BigDecimal remainingBalance)`: Updates the remaining balance of a loan.
  - `updateInterest(String loanId, BigDecimal interestRate)`: Updates the interest rate of a loan.
  - `updateRepaymentTerm(String loanId, String repaymentTerm)`: Updates the repayment term of a loan.
  - `listAllLoans()`: Retrieves all loans.

### Repository Layer

**Interface: LoanRepository**

- **Methods**:
  - `save(Loan loan)`: Saves a new loan record.
  - `findById(String loanId)`: Finds a loan by its ID.
  - `update(Loan loan)`: Updates a loan record.
  - `findAll()`: Retrieves all loans.

### Endpoints and DTO

#### Endpoints

- **POST /loans**: Initiates a new loan.
- **GET /loans/{loanId}**: Retrieves a specific loan by its ID.
- **PUT /loans/{loanId}**: Updates loan details.
- **GET /loans/{loanId}/repayment-schedule**: Retrieves the repayment schedule of a loan.
- **PUT /loans/{loanId}/repayment-schedule**: Updates the repayment schedule of a loan.
- **PUT /loans/{loanId}/remaining-balance**: Updates the remaining balance of a loan.
- **PUT /loans/{loanId}/interest-rate**: Updates the interest rate of a loan.
- **PUT /loans/{loanId}/repayment-term**: Updates the repayment term of a loan.
- **GET /loans**: Retrieves all loans.

#### DTO: LoanDTO

**Attributes**:

- `loan_id`: Unique identifier for the loan.
- `acc_id`: Account for which loan is initiated.
- `loan_type`: Type of loan.
- `loan_type_id`: Unique identifier for the type.
- `loan_amount`: Amount of money disbursed to the customer.
- `disbursement_date`: Date when the loan was disbursed.
- `repayment_term`: Repayment term (e.g., 12 months, 5 years).
- `interest_rate`: Interest rate applied to the loan.
- `monthly_installment`: Monthly installment amount to be repaid by the customer.
- `remaining_balance`: Remaining balance of the loan.
- `repayment_schedule`: Detailed schedule of repayment dates and amounts.
- `initiated_repayments`: List of repayments made for the loan amount.


## Loan Management
 
### `getLoanById(loan_id)`
- **Description**: Retrieves detailed information about a specific active loan by its unique identifier.
- **Parameters**: `loan_id` (int) - Unique identifier for the loan.
 
### `getAllActiveLoans()`
- **Description**: Retrieves a list of all currently active loans.
- **Parameters**: None.
 
### `updateLoanRepaymentTerms(loan_id, new_repayment_terms)`
- **Description**: Updates the repayment terms of an active loan.
- **Parameters**:
  - `loan_id` (int) - Unique identifier for the loan.
  - `new_repayment_terms` (str) - Updated repayment terms for the loan.
 
### `calculateRemainingBalance(loan_id)`
- **Description**: Calculates the remaining balance of the active loan, considering repayments and accrued interest.
- **Parameters**: `loan_id` (int) - Unique identifier for the loan.
 
### `generateRepaymentSchedule(loan_id)`
- **Description**: Generates a repayment schedule outlining dates and amounts due for the active loan.
- **Parameters**: `loan_id` (int) - Unique identifier for the loan.
 
### `makeRepayment(loan_id, repayment_amount)`
- **Description**: Registers a repayment made by the borrower towards the active loan, updating the remaining balance and repayment history.
- **Parameters**:
  - `loan_id` (int) - Unique identifier for the loan.
  - `repayment_amount` (float) - Amount to be repaid by the borrower.
 
### `applyInterestAccrual(loan_id)`
- **Description**: Applies interest accrual to the active loan based on its current balance and interest rate.
- **Parameters**: `loan_id` (int) - Unique identifier for the loan.
 
### `notifyUpcomingPayments(loan_id)`
- **Description**: Sends notifications to the borrower about upcoming loan payments.
- **Parameters**: `loan_id` (int) - Unique identifier for the loan.
 
### `closeLoan(loan_id)`
- **Description**: Marks the active loan as closed or fully repaid, updating its status and finalizing any outstanding financial transactions.
- **Parameters**: `loan_id` (int) - Unique identifier for the loan.
 
## Customer Interaction
 
### `getLoanHistoryForCustomer(customer_id)`
- **Description**: Retrieves a history of all loans associated with a specific customer, including both active and closed loans.
- **Parameters**: `customer_id` (int) - Unique identifier for the customer.
 
### `notifyLatePayment(loan_id)`
- **Description**: Sends notifications to the borrower if a payment on the active loan is late or overdue.
- **Parameters**: `loan_id` (int) - Unique identifier for the loan.
 
### `requestLoanStatement(loan_id)`
- **Description**: Provides the borrower with a detailed statement of their active loan, including transaction history, repayments, and current status.
- **Parameters**: `loan_id` (int) - Unique identifier for the loan.
 
## Administrative Actions
 
### `approveLoanModificationRequest(loan_id, modification_details)`
- **Description**: Processes and approves requests for modifications to an active loan, such as term extensions or changes in repayment conditions.
- **Parameters**:
  - `loan_id` (int) - Unique identifier for the loan.
  - `modification_details` (dict) - Details of the requested modifications.
 
### `rejectLoanModificationRequest(loan_id, reason)`
- **Description**: Rejects requests for modifications to an active loan, notifying the borrower of the decision.
- **Parameters**:
  - `loan_id` (int) - Unique identifier for the loan.
  - `reason` (str) - Explanation for rejecting the modification request.
 
### `reviewLoanDefaultRisk(loan_id)`
- **Description**: Evaluates the risk of default on an active loan based on borrower behavior and financial indicators, initiating appropriate risk management actions if necessary.
- **Parameters**: `loan_id` (int) - Unique identifier for the loan.