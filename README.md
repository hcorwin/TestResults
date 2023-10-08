# TestResults
angular/c# application for viewing test results

Simple Api/Angular front end for logging in/viewing test results

The api:
1.  Uses a background service and System.Threading.Channels to log in a non-blocking way
2.  Handles exceptions globally with exception filter
3.  Generated jwt that is used to authorize access to test results endpoint

UI:
1. logs in and stores jwt
2. uses jwt to load information into table to display
