@echo off

CALL migration\configuration-%3.bat

SET AssemblyPath=..\%1\bin\%BuildMode%\%1.dll

..\packages\FluentMigrator.Tools.%FluentMigratorToolsVersion%\tools\AnyCPU\40\Migrate.exe /provider %DatabaseProvider% /connectionString %ConnectionString% /assembly %AssemblyPath% /t %2 /profile %3