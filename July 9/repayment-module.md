# Repayment Module in Banking System



## Layers

### Controller Layer
**Interface: RepaymentController**

- **Methods**:
  - `recordRepayment(RepaymentDTO repaymentDTO)`: Endpoint for recording a new repayment.
  - `getRepaymentById(String repaymentId)`: Endpoint for retrieving a specific repayment by its ID.
  - `getRepaymentsByLoanId(String loanId)`: Endpoint for retrieving all repayments made towards a specific loan.
  - `getAllRepayments()`: Endpoint for retrieving all repayments.

### Service Layer
**Interface: RepaymentService**

- **Methods**:
  - `submitRepayment(RepaymentDTO repaymentDTO)`: Handles the recording of a new repayment.
  - `findRepaymentById(String repaymentId)`: Retrieves a specific repayment by its ID.
  - `findRepaymentsByLoanId(String loanId)`: Retrieves all repayments made towards a specific loan.
  - `listAllRepayments()`: Retrieves all repayments.

### Repository Layer
**Interface: RepaymentRepository**

- **Methods**:
  - `add(Repayment repayment)`: Saves a new repayment record.
  - `GetById(String repaymentId)`: Finds a repayment by its ID.
  - 
  - `GetAll()`: Retrieves all repayments.

## Endpoints and DTO

### Endpoints
- **POST /repayments**: Submits a new repayment.
- **GET /repayments/{repaymentId}**: Retrieves a specific repayment by its ID.
- **GET /repayments/loan/{loanId}**: Retrieves all repayments made towards a specific loan.
- **GET /repayments**: Retrieves all repayments.

### DTO: RepaymentDTO

**Attributes**:
- `repayment_id`: Unique identifier for the repayment.
- `loan_id`: Unique identifier for the associated loan.
- `repayment_date`: Date when the repayment was made.
- `amount`: Amount of money repaid.
- `remaining_balance`: Remaining balance of the loan after the repayment.
- `payment_method`: Method used for repayment (e.g., bank transfer, cash, cheque).
- `late_fee`: Late Fee charged for missed or delayed payments.
