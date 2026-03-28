# quizzi

## Frontend
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


## Backend
The Backend is written using .NET, current iteration has no database connection (lots of complexity for reviewers to run locally), but is open to be extensible for a PostgreSQL database in the future. 
```