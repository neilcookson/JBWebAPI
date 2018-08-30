This API solution contains 3 projects -

  * JBWebAPI.Api
    * This project houses the Products controller, DTO models and DI config logic and should be set as the startup project within the solution.
  
  * JBWebAPI.Data
    * This project houses the entity models and test data. It also exposes the repositories for consumption by the API project. The repository has a dependency on a data service. In this implementation the data service simply reads json data from the test-data.json file located in the JBWebAPI.Data project root.
  
  * JBWebAPI.Test
    * Unit tests for the major components of the solution. The unit tests are using MSTest so you should have support to run / debug all configured tests from the test explorer baked into VS. At the time of the last push all tests were positive.
 
 To run the solution you should simply need to ensure that the startup project has been configured as the JBWebAPI.API project. Since the UI element has not been implemented you will need to hit the endpoints via your browser or via a 3rd party tool such as Postman. By default the project has been configured to run on port 50418.
 
 All endpoints follow convention-based routing as per a standard Web API implementation and meet the brief outlined for this test.
 
 There is also support for filtering within the products route where the parameter is expected to be passed-in as a query string i.e. .../?fc=brand:sony
 All filtering logic is contained within the FilterParser.cs file within the API project but is not yet complete as it is only filtering based on the Product entity properties as opposed to the DTO so it will only work if the property names match between the DTO and entity.
