## devpro-assessment
Project created as part of the challenge proposed by the DevPro company for a QA Engineer position

## Environment Setup
- Download and install .NET 8 (https://dotnet.microsoft.com/pt-br/download/dotnet/thank-you/sdk-8.0.100-windows-x64-installer)
- The project was developed using .NET 8.0 and VSCODE for the code editor + C# Dev Kit Extension (I recommend using this editor, for its lightness and practicality)
- Be sure to wait until everything is downloaded and set when opening the project for the first time

## Prerequisites
 - All dependencies download and set

## Frameworks/Libs
  - NET 8.0
  - Nunit 3

## General Info

 - When the test suite are run, a **'Log.txt'** file is created/updated in the project root directory

The solution consists of two projects, one of which is for testing. For the purpose of the task challenge it was created two applications in the same project (which I named 'QaAssessment'), one for logging messages to a file and the other one for sorting lists of an Inventory Management json. The test project was organized into two separate classes, each for its respective project.

It was used a "semi-mvc" approach, there's no controller neither View, of course (it didn't make sense for this purpose and size of the project), however the project was created following the best practices of OOP Concept, including encapsulation, inheritance and polymorphism.

For the purpose of this task challenge, it was not used a library for Logging (E.g. log4net, NLog etc.) as it would be in the real world, I've "manually" developed my own version of it.
