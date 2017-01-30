# llsoftware
#The main repository for the Long Life Software Project on Medium
#https://medium.com/@amrswalha/lifelong-software-system-maintainability-part-1-7e0af04a179e
#NuGet: https://www.nuget.org/packages/LifeLongSoftware/
Hello and Welcome!
Every software system one day will be **obsolete and working in a very old framework**. These software become very expensive to support
and maintain. Creating a new version might be very costly since there is no easy way to move all the business logic and data entities
To a new version.

To try to find a solution between these challenges, the Life Long Software project aims to help make the update process as smooth as possible. Technology independent no matter what you use, you can easily updated the software or to change to a new version.

#Example code - Moving the MS SQL Entities to XML and JSON
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
