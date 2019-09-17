## AVALARA INTERVIEW ASSIGNMENT
### *David Green, 9/17/2019*

### Problem Definition
Using your favorite IDE or text editor, create a program which accomplishes the following:

+ The program should be written in C#.
+ The program should predict the amount of precipitation in the 27612 ZIP Code, without making any external HTTP calls to do so. Historical precipitation data for 27612 can be accessed here.
+ The program should return the predicted precipitation amount for the current date (if a date was NOT passed in) or for the given date (if a date WAS passed in).
+ The response should be in JSON format.
+ The code should be well organized, documented, and unit tested.
+ Please upload your source code to a Git repository such as GitHub or Bitbucket, to allow for efficient review. Please do not upload as a zip file.


### Solution/Approach
+ The dataset given in the spreadsheet has several features, but only one feature is relavent for this asisgnment - date.
+ Conceptually there is no meaningful relationship between an exact date (mm/dd/yyyy) and rainfall we can use in our engine, but between a date's **month** and rainfall there is one.
+ The prediction model basically works by using the date supplied by the user and doing a dictionary lookup against the mean value of rainfall for that month.
+ Linear regression for something like this is a bit overkill, so I didn't go down that route (but originally looked into it).


### Usage/ Notes 

+ Launch point is the **Weather27612.WebApi** project which takes you to a web page with further instructions in how to use/test with Swashbuckle
+ Had trouble accessing the Excel URL from within C# (I get a 403 Forbidden HTTP status when trying to stream, so I just downloaded the file locally). If given more time I'd go back and debug the issue.
+ Ended up using .NET 4.72 instead of .NET Core because the 3rd party library I wanted to use for parsing Excel was having trouble in .NET Core


