TransacManager
Git repository: https://github.com/smcoronel/TransactionManager.git

Follow these instructions to have the project up and running on your local machine:

Prerequisites

Visual Studio 2015
MS SQL Server Express 2016

Deploying

1. Open SQL Server and run the /dcuments/script.sql file to create the database. This script has test data included.
   I have added the entity relationship diagram in the documents folder.
2. To run the web site, open solution TransactionManager in VS Studio. Make sure TransacManager is set as startup project
3. Modify the connection string in the web.config file to point to the database server you are using for testing.
4. Clic in Log in link to access the application. You can use the following users:
	username		password
	admin			@dm1n.2017
	assistant		Ass3st1nt.2017
	superintendent	S5p2r.2017
	manager			M1n1g2r.2017

5. To test the web service, set the project TransacManager.Service as the startup project
6. Modify the connection string in the web.config file to point to the database server you are using for testing.
7. To test the get method in the web service, you can use the file /documents/WebService_Test.html. This file contains an ajax instruction to get 
   the transaction with id 2. Modify the url attribute according to your web service's url.
   If you inspect the javascript code, you can see that the response is a json object.
   

