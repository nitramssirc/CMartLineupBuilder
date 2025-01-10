@echo off
REM Check if a migration name is provided
if "%1"=="" (
    echo Please provide a migration name.
    exit /b 1
)

REM Set the migration name
set MIGRATION_NAME=%1

REM Move up two directories
cd ../..

REM Run the dotnet ef migrations add command
dotnet ef migrations add %MIGRATION_NAME% -p Repository -s UI_Server

REM Check if the command was successful
if %errorlevel% neq 0 (
    echo Failed to create migration.
    exit /b %errorlevel%
)

echo Migration %MIGRATION_NAME% created successfully.
exit /b 0