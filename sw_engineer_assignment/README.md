# Equipment Tracker
## Overview
This application is able to let the user interact with json objects inside a json file which path is declared in the "FilePath" variable in the Equipment Class.
The app has the ability to: 
* Add new equipment, by selecting the Add Equipment option and giving the generated equipment a name which is just a basic string with no limitations, a status which can be chosen from multiple options of the enum "Status.cs" and an automatically generated ID which gets created by the app. The app generates the ID by checking the last ID in the json file and adding 1 to it. So the IDs go from 1 to n.
* Change the status of an equipment by selecting the equipment from the list by its ID and then choose the new status by accessing a dictionary by a number of ConsoleKeys based on the options from the enum "Status.cs".
* Retrieve the status of an equipment by selecting the equipment from the json by its ID and then the application will print the dedicated status of the equipment.
* And search the IDs of equipments by a search word. It is meant to only trigger with an object when the status or name is fully correct, or at least 5 consecutive characters of the search word fit to either the status or name. e.g. "opera" should trigger with the status "operational" or "Noteb" with the name "Notebook" but not Miss with "Missing" because "Miss" is neither completely identical to "Missing", nor it has 5 consecutive characters fitting into "Missing". Sadly I was not able to make the method work exactly as intended, but it is at least able to search equipment and get fitting IDs returned.

## How to use
The application is a console application and can be used by running the application and then following the instructions given by the console. The application will print out the options and the user can choose by pressing the dedicated key on the keyboard. The application will then ask for further input if needed and will print out the results of the action. The application will then ask the user if he wants to perform another task. If he selects yes (Y), the app will ask again which task he wants to do, if he selects no (N), the application will close.

## How to store and retrieve data
The application can store equipment parts as json objects by either using the "Add Equipment" option, which is the suggested way to use it or by manually changing the json file by adding a json object handmade. Keep in mind to use the correct format of the json object, which is for example:
```json
[
  {
    "Id": 1,
    "Status": "Operational",
    "Name": "CPU"
  }
]
```
Remember, the ID has to be unique, and be incremented by the latest object's ID by 1. Otherwise the application won't work correctly, because the json file got corrupted. It is highly suggested to use the given "Add Equipment" option.

To retrieve the data, the application has a dedicated method to read the json file and retrieve the status of the equipment with the ID given by the user.


## Others
It is to be mentioned, in the "sw_engineer_assignment" folder is a given folder "Testcases" which has a couple of screenshots with some tests done to the most common usecases.

Also I want to mention, that i wrote the whole application in the Jetbrains Rider IDE and just did the Tests in Visual Studio. I hope the using experience and reviewing works in Visual Studio the same as in Rider. The README.md is only shown in the solution in Visual Studio and gets ignored in Rider for some reason. 