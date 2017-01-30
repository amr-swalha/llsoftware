# llsoftware
#The main repository for the Long Life Software Project on Medium
#https://medium.com/@amrswalha/lifelong-software-system-maintainability-part-1-7e0af04a179e
Hello and Welcome!
Every software system one day will be obsolte and working in a very old framework. These sofware become very expensive to support
and maintaine. Creating a new version might be very costy since there is no easy way to move all the business logic and data entities
to a new version.
To try to find a solution between these challanges, the Life Long Software project aims to help make the update process as smooth as possible. Technology independent no matter what you use, you can easliy updated the software or to change to a new version.

#Example code - Moving the MS SQL Enitites to XML and JSON
```
XmlGenerator xml = new XmlGenerator();
JSONGenerator json = new JSONGenerator();
xml.ConnectionString =
 "Data Source=.\\sql; Initial Catalog=LLProject; Integrated Security=True; MultipleActiveResultSets=True;";
json.ConnectionString =
 "Data Source=.\\sql; Initial Catalog=LLProject; Integrated Security=True; MultipleActiveResultSets=True;";
Console.WriteLine(xml.GenerateDescription("D:\\file2.xml"));
Console.WriteLine(json.GenerateDescription("D:\\file2.json"));
Console.Read();
```
