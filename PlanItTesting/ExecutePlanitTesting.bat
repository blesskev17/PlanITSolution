cd packages\NUnit.ConsoleRunner.3.14.0\tools
nunit3-console.exe "..\..\..\PlanItTesting\bin\Debug\PlanItTesting.dll" "--result=..\..\..\TestResults\Result.xml;format=nunit2"
cd ..\..\..\report\SpecFlow.2.4.1\tools
specflow.exe nunitexecutionreport --ProjectFile ..\..\..\PlanItTesting\PlanItTesting.csproj --xmlTestResult ..\..\..\TestResults\Result.xml --OutputFile ..\..\..\TestResults\TestReport.html
cd ..\..\..\
start chrome %cd%\TestResults\TestReport.html