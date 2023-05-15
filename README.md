# StudentManagement System


This project is a simple student management system that reads student data from a CSV file, generates email addresses for the students, saves the student list as XML and JSON files, displays the student list in the console, and shows statistics about the students.

## Prerequisites

- .NET Core SDK [link](https://dotnet.microsoft.com/download)

## Getting Started

To get started with the student management system, follow these steps:

1. Clone the repository:

   ```shell
   git clone https://github.com/your-username/StudentManagement.git
   ```

2. Open the project in your favorite IDE or text editor.

3. Build the project to restore the dependencies:

   ```shell
   dotnet build
   ```

4. Modify the `Main` method in the `Program.cs` file to specify the path to your CSV file:

   ```csharp
   string csvPath = "C:\\path\\to\\your\\file.csv";
   ```

   Replace `"C:\\path\\to\\your\\file.csv"` with the actual path to your CSV file.

5. Run the project:

   ```shell
   dotnet run
   ```

## Functionality

### Reading Student Data

The system reads student data from a CSV file specified by the `csvPath` variable in the `Main` method. The CSV file should have the following format:

```
FirstName,LastName,SchoolClass
John,Doe,Class A
Jane,Smith,Class B
```

### Generating Email Addresses

For each student in the student list, the system generates an email address in the format `firstname.lastname@tfbseke.at`. The generated email addresses are stored in the `Email` property of each student object.

### Saving Student List as XML

The student list is saved as an XML file specified by the `xmlPath` variable in the `Main` method. If a file with the same name already exists, the system will automatically generate a new file name with an incremented number appended to it (e.g., `schueler1.xml`, `schueler2.xml`, etc.).

### Saving Student List as JSON

Similarly to saving as XML, the student list is also saved as a JSON file specified by the `jsonPath` variable in the `Main` method. If a file with the same name already exists, the system will generate a new file name with an incremented number appended to it (e.g., `schueler1.json`, `schueler2.json`, etc.).

### Console Output

The system displays the student list in the console, showing each student's first name, last name, school class, and email address.

### Statistics

The system provides a `StudentControl.StatisticHelper` method that calculates and displays statistics about the students, such as the total number of students, the number of students in each school class, and other relevant information.

## Contributing

Contributions to the student management system are welcome. If you have any suggestions, improvements, or bug fixes, please create a new issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
