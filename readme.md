# Creating a Banking Account Manager

This is a simple example application that started in the [OpenClassrooms "Learn programming with C#" course](https://openclassrooms.com/en/courses/5670356-learn-programming-with-c),
but has changed enough with later iteration that the original specs are no longer completely valid. Changes are highlighted below:

```diff
Create a console application to manage a Checking account and Savings account. Implement the ability to view account information and balances, make deposits, and make withdrawals.

When the application exits, write all Checking and Savings transactions to a text file.

**Include the following features:**

* View Account Holder Information - such as the account holder's name and account number.
* View Checking account balance
* View Savings account balance
* Deposit funds into Checking
* Deposit funds into Savings
* Withdraw funds from Checking
* Withdraw funds from Savings.
* Exit

- When you click the blue Run button, display the message:
+ When the application executes, prompt the user to create a new user profile by supplying their first and last names. 
+ After this, display the message: "Hit [ENTER] to display banking menu."

Upon Enter, the menu displays:

- Please select an option below:
- [I] View Account Holder Information 
- [CB] Checking - View Balance 
- [CD] Checking - Deposit Funds 
- [CW] Checking - Withdraw Funds 
- [SB] Savings - View Balance 
- [SD] Savings - Deposit Funds 
- [SW] Savings - Withdraw Funds 
- [ X ] Exit

+ Please select from the below options:
+ * 0: Account holder information
+ * 1: Banking operations
+ * 2: Exit 

- When you enter one of the key sequences identified in brackets, that feature is executed.
+ When you enter one of the numbers identified before the menu option, that feature is executed.

+ When you choose "Banking operations", a further menu prompts you to choose between a checking account and a savings account. 

+ Choosing for example "checking" will result in a confirmation that "checking is selected", before you are again prompted 
+ to choose between the following options:
+ * 0: View balance
+ * 1: Deposit funds
+ * 2: Withdraw funds

- For example, if you typed "CD" and Enter, the following would display.

- How much would you like to deposit?

- You type "20" and hit Enter.

- You deposited: \$20
- Hit Enter to Display Banking Menu

- Type Enter to see the banking menu again. Then type "CB"

- Checking Account Balance: \$20
- Hit Enter to Display Banking Menu

- Other application features work in a similar manner.

In this excercise you should be using the following:

    Inheritance
    Constructors
    List
    Loop
    Properties

```