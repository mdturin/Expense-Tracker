# Expense Tracker Console App [RoadMap](https://roadmap.sh/projects/expense-tracker)

## Overview
A simple command-line application to manage your expenses and track your finances. The Expense Tracker allows users to add, delete, update, and view expenses, as well as generate summaries of expenses for both specific months and overall totals.

## Features
- **Add an expense:** Add an expense with a description and amount.
- **Update an expense:** Modify an existing expense's details.
- **Delete an expense:** Remove an expense by its ID.
- **View all expenses:** List all recorded expenses.
- **View expense summary:** Display the total amount spent.
- **Monthly summary:** View a summary of expenses for a specific month.

## Direct Running the Task Tracker Console App (Windows) 

You can directly run the Task Tracker Console App using the published build file. Follow these steps to get started:

### 1. Clone the repository:
```
git clone https://github.com/mdturin/Expense-Tracker.git
```
### 2. Navigate to the project directory:
```
cd expense-tracker
```
### 3. Add the `run` folder to the environment variable `PATH`:
After building the project, the compiled files are stored in the `run` folder. To run the app from anywhere, you need to add this folder to your system's `PATH` environment variable.
-   **Windows**:
    1.  Open System Properties → Advanced → Environment Variables.
    2.  Under `System variables`, find the `Path` variable, select it, and click `Edit`.
    3.  Click `New` and add the path to the `run` folder (e.g., `C:\path\to\expense-tracker\run`).
    4.  Click `OK` to save the changes.

## Configuration
You can customize the directory where the tasks are stored by providing a configuration file. The app will look for the configuration file at:	```C:\AppStore\appconfig.json```

## Sample appconfig.json
	{
	  "StorePath": "D:\\MyExpenseStore\\",
	  "FileName": "expenses.json"
	}
	
- `StorePath`: The directory where tasks should be stored.
- `FileName`: The name of the file in which tasks will be saved.

## Default Configuration
If the config file is not set up, the app will default to storing tasks in the system's temporary folder (`%TEMP%` on Windows).

## Additional Features
- **Expense categories:** Categorize your expenses and filter them by category.
- **Monthly budget tracking:** Set a budget and get warnings when you exceed it.
- **Export to CSV:** Export all expenses to a CSV file for external use.

## Commands

Here are the available commands for interacting with the Expense Tracker:
### Add Expense
```bash
$ expense-tracker add --description "Lunch" --amount 20
```

### Update Expense
```bash
$ expense-tracker update --id 1 --description "Brunch" --amount 25
```

### Delete Expense
```bash
$ expense-tracker delete --id 1
```

### List All Expenses
```bash
$ expense-tracker list
```

### View Expense Summary
```bash
$ expense-tracker summary
```

### Monthly Expense Summary
```bash
$ expense-tracker summary --month 8
```

### Export Expenses to CSV
```bash
$ expense-tracker export --file expenses.csv
```

## Contributing
Feel free to submit pull requests or report issues on the [GitHub repository](https://github.com/mdturin/Expense-Tracker).

## License
This project is licensed under the MIT License.
