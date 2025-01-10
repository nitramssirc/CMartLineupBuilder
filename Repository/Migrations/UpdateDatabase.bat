@echo off

REM Move up two directories
cd ../..

REM Run the dotnet ef database update command
dotnet ef database update -p Repository -s UI_Server

REM Check if the command was successful
if %errorlevel% neq 0 (
    echo Failed to update the database.
    exit /b %errorlevel%
)

echo Database updated successfully.
exit /b 0
