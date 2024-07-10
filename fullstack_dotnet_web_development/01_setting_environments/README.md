# Initialize a project

- Install DotNet CLI
- Run dotnet --help to check if dotnet is installed
- Create a Console App Project:
    - Create project: dotnet new console -n [projectName]
    - cd [projectName]
    - Restore Up-to-date: dotnet restore
    - Run project: dotnet run
- Create a MVC Project: Same as Create a Console App Project, but in step 1, change the command to dotnet new mvc -n [projectName]