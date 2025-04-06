JOHN STRITZINGER
FOR CSCE590 - AZURE DEVELOPMENT SERVICES

Hi Everyone We are Running on Version6.6 APIs in a DB First Model. [DATED 3/28/2025]

This means that SQL Changes are made on SQL Azure either from the Azure Console or Via Sql Server Management Studio (Latest Build) then replicated to the API as models.
We have developed a method to do this in bulk which doesnt disturb the process as follows:


THE REVERSE ENGINEERING REFERENCE ON MICROSOFT. LEARN IS BELOW AND THE EXACT CONNECTION STRING WE ARE USING.....

https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli

PM> dotnet ef dbcontext scaffold "Server=tcp:cockysql.database.windows.net,1433;Initial Catalog=ce;Persist Security Info=False;User ID=cockysa;Password=*Columbia1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer --context-namespace Enterprise.Models -o Models --namespace Enterprise.Models -f --no-build

MAKING CHANGES TO THE API - DOS AND DONTS

GENERAL PROCESSES
The Api has changed fairly significantly so we recommend rather than synching changes for each revision you should clone the entire API, make changes, make a commit and then push to root. We do not have branching turned on so the main thing is dont
mess with the Models. We will synch them via the Database Every Sprint or perhaps a bit faster for the team.

TO WORK ON THE API - WE RECOMMEND WORKING IN THE CONTROLLERS, SERVICES, AND INTERFACES UP STREAM FROM THE MODELS AND LIMIT CHANGES TO THE program.cs file which runs the API wholistically. BUT
for each new controller there needs to be a map statement added to the Program as follows:

app.Map{NEWCONTROLLERNAME}Endpoints();

TO BUILD A NEW API... ITS FAIRLY EASY.....
copy the BU.cs to the name of the new controller... lets say USERLOGS.cs then search and replace BU for USERLOG including the pluralities....

THEN YOU NEED TO UPDATE THE UPDATE API to include all of the fields in the table defision specifically.

The API when published is continually published to Azure in its configuration(Continous Deployment).... so effectively the Run Button in Visual Studio is "ALWAYS ON".... via the URL for the website. Thus doing
development is much easier as you are not going back and forth from local URLs to production URLS.

NOTE ON UI development from DBFIRST MECHANISMS
There are a number of tools which can build complete UIs just from the Swagger JSON... and CoPilot given the JSON response... can in fact build a full program to update, insert, and delete records. You just have to tell it
a few things and redirect the output a few times to get it exactly the way you want.

FULL API PATH GENERATED
The Default Weather Controller is HERE... it will run without the Databases being Operational (CE.SQL DOWN). This is important as the API can run even if DB connectivity is down or asleep. Since the API has a hard IP address standard
SNMP pollers can determine if its responding and since it responds to HTTP REQUESTS... you can even run Performance tools against the URL.....
https://cockyapiv3-bugudue8akcsbacz.westus3-01.azurewebsites.net/WeatherForecast

SWAGGER IN PRODUCTION AZURE IS AT THE FOLLOWING LINK

https://cockyapiv3-bugudue8akcsbacz.westus3-01.azurewebsites.net/swagger/index.html

GENERAL FORM OF API LINKS
https://cockyapiv3-bugudue8akcsbacz.westus3-01.azurewebsites.net/api/CONTROLLERNAME
https://cockyapiv3-bugudue8akcsbacz.westus3-01.azurewebsites.net/api/CONTROLLERNAME/ID

API ON CAMPUS BEING PORTED TO API.590TEAM1.INFO
we are experimenting with the API on Linux... it works....but in limited form. all the same links with api.590team1.info/swagger/index.html

