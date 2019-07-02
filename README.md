# BettingApp
ODDESTODDS.com betting solution
	ARCHITECTURE DESCRIPTION
--------------------------------------------------------------------------
I used clean Architecture for my Architecture model.
I used entityframeworkcore for my data access
I used Asp.Net core 2.1 for my api

I used S.O.L.I.D
Unfortunately I was not able to finish all my test cases, because I had a bug and it was taking a lot of time. And I had to move on.

Layers
------------------------------------------
Application:this is where the business logic stays.
Domain: All application Database Enities.
Persistence: All Data call eg Add, Delete, Update, Get happens in there, I use sql lite for database.
Presentation/Ui: contains al the view or user interface for the project .
UnitTest:Contain unit tests.

3rd Party Tool 
----------------------------------
for Real time notification on the UI i used Pusher for sending realtime notofication when some operation happens at the backend .
https://pusher.com/tutorials/activity-feed-dotnet


Total hours spent: 48Hours
Github Url: 
