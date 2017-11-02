# BaltLogger
BaltLogger is a logging solution based on pluggable components for .Net Core 2. This proposed solution uses the following tools:
* .Net Core 2
* .Net Standard 2
* Entity Framework Core 2
* MEF 2.0

## Install

### Prerequisites
* [.Net Core 2 SDK](https://www.microsoft.com/net/learn/get-started/windows)

### Steps
1. Clone this repository: `git clone https://github.com/abalbin/BaltLogger.git`
2. Navigate to `src` folder
3. Execute `dotnet restore`
4. Then `dotnet build`
5. Navigate to project `BaltLogger.ConsoleApp` and create a new folder called **plugins**. This is where you should copy the dll's o the IBaltLogger implementations.
6. Run `dotnet run` in BaltLogger.ConsoleApp project and have fun!

## IBaltLogger
This is the interface that will be implemented by the loggers. Currently this solution only have 3 types of loggers:
* Console Logger
* Database Logger
* File System Logger

The types of messages that are currently supported are: success, warning and error.

## Console Logger
The implementation of this logger is in the class `ConsoleBaltLogger.cs`. It consists of a simple printed message in Console.

## Database Logger
This implementation uses Entity Framework Core with Sql Server for data persistance. Currently, the default database is named `BaltLoggerDb` and works with SQL Server LocalDB.

## File System Logger
This logger will save the logging messages in a `.txt` file that will be created in a folder called **logs** within the ConsoleApp folder.

## Plugging and Unplugging Loggers
For plugging or unplugging the loggers, simply add or remove the libraries (dll) of each one in the **plugins** folder. For instance, if you wish to use all of the 3 loggers available, your plugins folder should look like this:

![logger](https://i.imgur.com/gI2Qs7v.png)