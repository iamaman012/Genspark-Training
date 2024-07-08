### LoanApplication
 
**Description**: Represents a loan application submitted by a customer.
 
**Attributes**:
 
- `application_id`: Unique identifier for the loan application.
- `customer_id`: Unique identifier for the customer applying for the loan.
- `loan_type`: Type of loan (Secured,UnSecured).
 
- `remarks`: Additional remarks or notes related to the application.
 
### UnsecuredLoanApplication(Loan-Sub-Class)
 
**Description**: Represents an application for an unsecured loan submitted by a customer.
 
**Attributes**:
 
- `unsecured_loan_id`: Unique identifier for the loan Id.
- `application_id`: Unique identifier for the loan application.
 
- `loan_amount`: Amount of money requested by the customer.
- `application_date`: Date when the loan application was submitted.
- `loan_duration`: (str) Duration over which the loan is repaid (e.g., 5 years).
  `repayment_terms`: (str) Terms of repayment (e.g., Standard).
- `status`: Status of the application (e.g., pending, approved, rejected).
- `credit_score`: Credit score of the customer at the time of application.
- `income`: Customer's monthly or annual income.
- `purpose`: Purpose of the loan (e.g., debt consolidation, medical expenses).
- `documents`: List of documents submitted with the application (e.g., proof of income, ID proof).
- `remarks`: Additional remarks or notes related to the application.
 
### SecuredLoan Class (Sub Class of Loan)
 
**Attributes**:
 
- `secured_loan_id`: .
- `application_id`: Unique identifier for the loan application.
- `loan_amount`: (float) Total amount of the loan.
 
- `repayment_terms`: (str) Terms of repayment (e.g., Standard).
- `loan_duration`: (str) Duration over which the loan is repaid (e.g., 5 years).
- `borrower_details`: (dict) Dictionary containing details about the borrower (name,id, credit score and other details).
- `application_date`: Date when the loan application was submitted.
- `cosigner`: (str, optional) Another party who guarantees the loan.
- `collateral`: (str, optional) Type of collateral provided for the loan (e.g., Property).
- `DownPayment`: (str, optional) Down Payment paid for the property or anything.
 
- `collateral_value`: (float, optional) Value of the collateral provided.
 
### Loan
 
**Description**: Represents an approved unsecured loan that has been disbursed to a customer.
 
**Attributes**:
 
- `loan_id`: Unique identifier for the loan.
- `acc_id`: Account for which loan is initiated
- `Loan Type`: Unique identifier for the associated loan application.
- `Loan Type Id`: Unique identifier for the type
- `loan_amount`: Amount of money disbursed to the customer.
- `disbursement_date`: Date when the loan was disbursed.
- `repayment_term`: Repayment term (e.g., 12 months, 5 years).
- `interest_rate`: Interest rate applied to the loan.
- `monthly_installment`: Monthly installment amount to be repaid by the customer.
- `remaining_balance`: Remaining balance of the loan.
- `repayment_schedule`: Detailed schedule of repayment dates and amounts.
- `Initiated_Repayments`: List of repayments made for loan amount
 
### Repayment
 
**Description**: Represents a repayment made by a customer towards a loan.
 
**Attributes**:
 
- `repayment_id`: Unique identifier for the repayment.
- `loan_id`: Unique identifier for the associated loan.
- `repayment_date`: Date when the repayment was made.
- `amount`: Amount of money repaid.
- `remaining_balance`: Remaining balance of the loan after the repayment.
- `payment_method`: Method used for repayment (e.g., bank transfer, cash, cheque).
- `late_fee`: Late Fee charged for missed or delayed payments.
 
