# quizzi

## Frontend Setup
The Frontend is written using Angular. To install Angular run:
```bash
npm install -g @angular/cli
```
Then clone/fork the Github repo and enter the directory to run the app:
```
git clone git@github.com:mosspaul/quizzi.git
cd quizzi.frontend
ng serve
```
Angular will launch in the browser, normally on `localhost:4200` (Check terminal for exact port information)


## Backend Setup
The Backend is written using .NET, current iteration has no database connection (lots of complexity for reviewers to run locally), but is open to be extensible for a PostgreSQL database in the future. 

#### Install .NET 9 SDK

1. Go to https://dotnet.microsoft.com/en-us/download/dotnet/9.0
2. Download the SDK installer for your operating system (Windows, macOS, or Linux)
3. Run the installer and follow the prompts
4. Verify the installation by opening a terminal and running: `dotnet --version`. This projects uses version 9, so anything like `9.0.2` should be good.
5. `cd quizzi.backend` and run: `dotnet restore`.
6. The github repo contains special build and launch files for VS Code. If run from VS Code these files while launch the app on the correct port, build the app, etc. Can be run with the VS Code run with or without debugging.

## Next Steps
These are the features and functionality I would have liked to add but unfortunately did not have the time to build out. 
- **UI/UX Overhaul:** The current UX is not ideal, it is functional, but there are some minor improvements to routing and needed additions for accessibility. The UI also needs better and consistent theming, as well as more interaction with the user (sound effects, styling, etc).
- **User Authorization:** When opening the page, users should be prompted to sign in or sign up, so that they can have an account which actually stores past scores, maybe even add a leaderboard. Some type of user authorization middleware would be needed. All other calls to the API should then be authenticated, with JWT tokens or something of the like.
- **Full Fledged Database:** Those users would then be stored in a PostgreSQL database, the .NET app is set up to easily add a database and use EF Core and Database migrations, so building out a simple schema (Users, LeaderBoard, Groups?, CustomQuestions, etc) could be added as needed. Simple CRUD functionality would probably be sufficient for this use case.
