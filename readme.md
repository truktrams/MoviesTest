## MoviesTest local deployment guideline

Hi there and welcome!
Here desribed information about how to run the appllication on local environment.

- Required software:
    - Any convenient .Net Ide (VS or Rider);
    - Docker Desktop;
	- Microsoft Sql Management Studio (or any other database interface);
	- .Net Core SDK v.6.0+;
	
- Run cunfiguration:
    - Go to **ConfigureEnvironment** folder and execute both scripts:
        - `setup-execution-policy.txt` - execute its content in PowerShell (As administrator);
		- `setup-https-certificates.bat` - just run as administrator and confirm (to install local https certificates);
	- Go to **DatabaseContainer** and run `start.cmd` (it will spin-up local instance of MsSql Server on default port);
	- Go to **DatabaseMigrations** and run `create_merged_sql.bat`. It will create `merged_migration.sql` file for you. (Run this file on you local MsSql Server to generate database structure with demo data);
	- Go to **MoviesTest** and run solution `MoviesTest.sln`. (feel free learn the codebase and run the project);
	- Go to **RestRequest** and use some helpful request to play with API.
	
Now we are done with it =_)