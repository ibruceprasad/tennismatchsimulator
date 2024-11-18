# tennismatchsimulator

### <ins>About</ins>
This .Net 8 Console Application project simulate tennis match score board.



### <ins>Project structure</ins>


├── src/<br>
│   ├──TennisMatchSimulator/ #-----------*Main Console APplication*<br>
│   ├──TennisMatchService/ #-------------*Core business layer*<br>
│   ├──Contract/ #-----------------------*The interface contract*<br>
<br><br>
├── tests/<br>
│   ├──Library.Api.Integration.Test/       #---------------- *The Integration test suite*<br>
│   ├──Library.Api.Repository.UnitTest     #---------------- *The unit tests for repository layer*<br>
|   ├──Library.Api.Services.UnitTest       #---------------- *The unit tests for  service layer* <br>
└── README.md<br>
└── .gitignore<br>

### <ins>Technologies<ins>
* .Net 8 Web Api,<br> 
* Minimal API <br> 
* API versioning <br>
* automapper
* OpenAPI Swashbuckle <br> 
* Global Exception handler middleware <br>
* Dependecy registration and injuction for service layer and repository layer <br>
* Generic repository layer for CURD operation of entities<br>
* Entity Framework Core <br> 
* sqllite database <br>
* xUnit mock tests for service layer and repository layer <br>
* xUnit integration tests<br>
* Integration test suite spin off MSSQL Docker container<br>
* xUnit test results and coverage using coverlet
