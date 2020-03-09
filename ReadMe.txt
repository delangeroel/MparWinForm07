-------------------------------------------------------------------------------------------------------------------------------
Installatie nadat het project is gemaakt in Visual Studio
-------------------------------------------------------------------------------------------------------------------------------
Start met NuGet en haal de volgende software op
> Tools, NuGet, Manage..., dan Browse op onderstaande items en deze installeren
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Tools

Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration InitialCreate
Update-Database
// Numeric opmaak/formatting
https://documentation.devexpress.com/WindowsForms/1498/Controls-and-Libraries/Editors-and-Simple-Controls/Common-Editor-Features-and-Concepts/Input-Mask/Mask-Type-Numeric


-------------------------------------------------------------------------------------------------------------------------------
Database
-------------------------------------------------------------------------------------------------------------------------------
connection string
optionsBuilder.UseSqlServer("server=.;database=EFCore01;trusted_connection=true;Integrated Security=True;");

De xml versie kan ook gebruikt worden, deze staat in App.confix.xml, alleen staat deze niet ingesteld in de MyContext.cs file
optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MparWinForm07"].ConnectionString);


** Bevat ook een voorbeeld van een lokale db en eentje in sql server (deze is nu actief)

Regenerate source example: NuGet  //https://www.learnentityframeworkcore.com/walkthroughs/existing-database
Scaffold-DbContext "Server=.\;Database=AdventureWorksLT2012;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model -Context "AdventureContext" -DataAnnotations

-------------------------------------------------------------------------------------------------------------------------------
Instellen software op dezelfde land en opmaak instellingen
-------------------------------------------------------------------------------------------------------------------------------
Zet in Program.cs (het eerste programma dat opgestart word) nog voor dat er ook maar iets gedaan wordt: (dus voordat je het scherm start)
            //Set globalization the same for whole application
            var culture = new System.Globalization.CultureInfo("nl-NL");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
-------------------------------------------------------------------------------------------------------------------------------
Debug window
-------------------------------------------------------------------------------------------------------------------------------
            https://docs.microsoft.com/en-us/visualstudio/ide/reference/immediate-window?view=vs-2019
            CRTL+ALT+I

-------------------------------------------------------------------------------------------------------------------------------
Schermcontroles
-------------------------------------------------------------------------------------------------------------------------------
Toepassen zoals in ActionController en dan de save methode staat. Net voor de save check uitvoeren en afbreken indien er fouten gevonden zijn



-------------------------------------------------------------------------------------------------------------------------------
ToDo
-------------------------------------------------------------------------------------------------------------------------------
-- Linq
---- Select and where
---- Group by
---- Count records
---- Value conversions
-- Entity Core framework
---- Create database 
-- Lambdas 
-- On screens
---- Combobox on screen, position on selected, read selected etc.
---- Dates on screen
---- Numeric values on screen
---- Amount on screen
-- WPF
-- Web
-- Windows Communnications
