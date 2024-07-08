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