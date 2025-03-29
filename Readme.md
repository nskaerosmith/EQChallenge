# C# Pensions Challenge :moneybag:

This is the code repository for the Pensions Challenge, published by @EQPaymaster.

### The Challenge
>You have been given a subset of a HR database from the HR team at EQPaymaster.  They are looking to expand their processes and would like to use their information stored to create an API that calculates a simple pension.  Some of the data retrieval steps, services and controller endpoints have already been created by another member of the team.

The EQPaymaster HR team have given you the formula you should use to calculate the pension for each member.

`(Service / 365) * (FinalSalary /Accrual)`

where
- `Service` = Total number of days service
- `FinalSalary` = The latest Salary for a particular member
- `Accrual` = The accrual rate based on the last end date of the members service (or today if the member is still in employment)

The HR team has also given you the expected resulst for each member in the database.

| Id (Basic.Id) | Expected Pension (12 OCt 2019) | Expected Formula (12 Oct 2019)     |
| ------------- | ------------------------------ | ------------------------------     |
| 1             | £6,956.85                      | `(10725 / 365) * (29594.98 / 125)` |
| 2             | £2,063.87                      | `(3548/ 365) * (26540 / 125)`      |
| 3             | £3,116.72                      | `(1580/ 365) * (90000.27/ 125)`    |
| 4             | £8,562.82                      | `(7574/ 365) * (33012.20/ 80)`     |

You should build your calculation API following the usual best practices such as SOLID principles.

### Pre Requisites
In this challenge, you will work with
- .Net Core 2.2
- Swagger
- EntityFrameworkCore

and you will need the following tools
- Visual Studio (2019 Community Edition or later)

### To Do List
- [ ] Add a new calculations API controller endpoint that takes a parameter Id (e.g. api/calculation/1).  Id should be the basic Id.

and within the calculations controller

- [ ] Get the service history for a member
- [ ] Convert the service history for a member into days
- [ ] Get the accrual rate for a  member based on their end date (or today if still in employment)
- [ ] Get the latest salary for a member
- [ ] Calculate the pension for a member
- [ ] Return the calculated result to the user
- [ ] Update the unit test suite

### Setup
1. Clone the repository
2.  Make Pensions.Host the default startup project
3. Run the project - https://localhost:44367/swagger/index.html should open automatically and create a new Pensions database in your local DB store.
4. Use the swagger UI to test your APIs uing the Try it out option.  https://www.blazemeter.com/blog/getting-started-with-swagger-ui/ has a good tutorial using Swagger UI if you've never used it before.

#### Bonus challenge
:: You will need to amend the database structure to complete this bonus challenge ::

The HR team would also like the option to save each of the calculations to the database.  There should be a new table called `Results` with the columns
- `Id` - index of result
- `BasicId` - the member Id
- `Value` - the calculated pension
- `DateOfCalculation` - the date the calculation was run

The option should be a parameter used by the calculations endpoint controller.

### Good Luck!

# :rocket:
