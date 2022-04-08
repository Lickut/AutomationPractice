# AutomationPractice
*Selenium UI Automation task
Please create a  simple Selenium based framework using the following Portal:					
http://automationpractice.com/index.php*					
					
					
### Requirements:					
Language: Java/.Net preferrable (but any other language can be used)			

Browers: at least Chrome, Firefox	

Parallelization: min 2 threads, each with different browser			

BDD: Cucumber (Optionally, if you have experience)		

Reporing: Any desired framework					

Source code repository: Github					
					
### Tasks:					
1. Create automation testing framework and implement each scenario mentioned below					
2. Create repository on Github and commit source code into repository. Coding must be done in separate branch then merged into master					
3. Present test run report					
4. Provide instructions how to setup framework and execute tests					
					
### Test scenarios:					
1. Create two users					
2. Check that front page contains main elements (chose which elements to check)					
3. Buy clothes using user1 credentials and random basket					
        Clothes must be bought using search field by name					
4. Buy clothes using user2 credentials and basket which is left					
        Clothes must be bought using path from basket configuration					
       
#
### Prerequisites:
1. [dotnet 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
2. [Chrome](https://www.google.com/chrome/) (v.100.0)
3. [Firefox](https://www.mozilla.org/) (v.99.0)
4. [SpecFlow LivingDoc CLI](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Installing-the-command-line-tool.html)

### How to run tests:
1. dotnet test .\AutomationPractice.UITests\AutomationPractice.UITests.csproj

### How to create SpecFlow LivingDoc test report:
1. cd .\AutomationPractice.UITests\bin\Debug\net6.0
2. livingdoc test-assembly .\AutomationPractice.UITests.dll -t .\TestExecution.json

Default report file name: LivingDoc.html
