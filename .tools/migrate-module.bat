@echo off

CALL configuration.bat

SET AssemblyPath=..\%1\bin\%BuildMode%\%1.dll

..\packages\FluentMigrator.Tools.%FluentMigratorToolsVersion%\tools\AnyCPU\40\Migrate.exe /provider %DatabaseProvider% /connectionString %ConnectionString% /assembly %AssemblyPath% /t %2