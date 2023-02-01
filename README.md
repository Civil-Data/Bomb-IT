[![Aquire activation file](https://github.com/Civil-Data/Bomb-IT/actions/workflows/activation.yml/badge.svg)](https://github.com/Civil-Data/Bomb-IT/actions/workflows/activation.yml)

[![Build and tests 🎮](https://github.com/Civil-Data/Bomb-IT/actions/workflows/NyastetestettillMartin.yml/badge.svg)](https://github.com/Civil-Data/Bomb-IT/actions/workflows/NyastetestettillMartin.yml)

Bomb-IT
=======
Project is a school project in software development.

## Project Description
 This a recreation of the classic Bomb It game. The main purpose of this project is the to learn various software development techniques.

## Game Details
Bomb-IT can be played with or agains other players that can both be computer- and/or human players. To start, the maximum amount of players will be six. The playing field will be a square field to begin with and could perhaps be changed through game settings to change size and shape. The game will have two modes:
* **Single player:** The game can only be played against computer players.
* **Multi-player:** The game is hosted and managed by one player and up to five human players can join.  
**NOTE: multi-player will only be working on a local network.**

Players can be devided into teams such as **2vs2**, **3vs3** or play **free-for-all**.

## Development
This project is being developed using the Unity game development software together with the written functionality in C# using Visual Studio as IDE.
We will start with making graphical assets in photoshop and the code behind these. For example player movement, object states and basic UI. Later we will add local multiplayer.

### Some Initial features
###### NOTE: Will be added continuously
* Basic player control. Movement with arrow keys and placing bombs with space.
* Bomb Logic. Countdown, range (power). Example for countdown is 5 sek, and the initial radius is 2 blocks.
* Initial Map objects and placement of these. Can include player spawn. Destructable and indestructable.These objects will block player movement and the destructive radius of the bomb. If the destructable objects are inside of the radius of a bomb, then these will be removed from the map. If not destructable then the object remains. 
* Items, pickup and powerups. Player will pickup items to improve his or her stats. Ie More powerful bombs (+1 range), faster movement (increase by a factor of 1.1 (10%)) etc. When picked up these shall be removed.
* Basic UI. Choose number of players, size of map and gamemode.
* Random map generator.

## Build System
We have not currently choosen a build system for this project. Currently choosing between: mark and ant.   
For starters we will just use visual studio as our build system but we will change this.

## Requirements 
* Unity Hub is needed to run our program you can download Unity Hub from this link: https://store.unity.com/download
* When Unity is installed you also need to install Unity Editor version 2022.2.4f1
*  .NET 6 SDK for uses of dotnet or else you have to enter the following command in a terminal `dotnet tool install -g dotnet-format`

## Compiling and Running
1. Clone our repository to desired location on your computer.
2. Open the project from Unity Hub
3. When project is open, go to: **File > Build Settings > Build And Run**. Then create a new folder outside the project folder where the build will be created. The folder will now hold a Bomb-IT.exe file used to execute the program. 
4. The game should now run and a unity window with a playing field and two characters should pop up. You should be able to control one of them with W,A,S,D or arrow keys. You can also push around the other player around the map.
5. To exit the game press **Alt+F4**.

## How to generate code coverage information
1. Open the project from Unity Hub
2. When the project is open in the Unity Editor go to: **Window > Package Manager.** This opens up the Packet Manager in a popup window.
3. In the upper left hand corner of the Package Manager window you will see a plus sign. To the right of this sign, click on the Tab where it says "Packages: ....". This will open a drop down menu. In the drop down menu, select "Unity Registry".  
It should now look something like this:  
![image](https://user-images.githubusercontent.com/58775643/215223673-6af75ba5-18da-4865-b4f7-b88afab82144.png)

4. Search and find the Code Coverage package and click on install.
5. Close the Package Manager after the installation is done and go to: **Window > Analysis > Code Coverage.** This will open the Code Cover Manager.
6. Enable Code Coverage by enabling the checkbox **¨Enable Code Coverage"**
7. **Optional:** Change the directory where you want the code coverage Result and Report to go to.
8. Make sure all the items except the "Tests" item in are unchecked in the **Included Assemblies**  
![image](https://user-images.githubusercontent.com/58775643/215226026-79885c84-a358-4bda-8306-503bc005ec1a.png)

9. These Reports will be generated when you run the unit tests. To check the code coverage information open up the directory where these are generated and open the **index.html** file in a **web browser**.

## How to run the unit tests
1. Open the project from Unity Hub
2. When the project is open go to **Window > General > Test Runner**. This will open the Test Runner window in which we run all our test in.
3. Click on Run all.  
4. You might be prompted with a popup window asking you to switch to **debug mode**. If so click "Switch to debug mode".  
5. Now the test results should be visable and you can see which tests have either passed or failed.  
For further statistics open up the **index.html** file in the directory where the report was generated.  
![image](https://user-images.githubusercontent.com/58775643/215228810-9a908dad-c943-49ed-a111-cde218d6526c.png)

(6. If the above points dont work. Try to do the steps in **Compiling and Running**) 

## How to run a linter in our project
1. Open a terminal
2. Go to the directory where your cloned version of Bomb-IT is
3. Insert script `dotnet format Bomb-IT.sln`
4. Command will fix whitespace, code style, and analyzer issues by default.

## Kanban Board
* https://github.com/orgs/Civil-Data/projects/1/views/1

## List of names in Group 5
* Martin Nilsson, **Github:** MarrisSparrisNilsson
* Felix Stockinger, **Github:** Stocken99
* Joel Scarinius, **Github:** JoelScarinius
* Jacob Danielsson, **Github:** McFluffen
* Matilda Ronder, **Github:** matildaronder
* Lukas Ydkvist, **Github:** Lukasydkvist

## Declaration
I, Joel Scarinius, declare that I am the sole auther of the content I add to this repository.  
I, Matilda Ronder, declare that I am the sole auther of the content I add to this repository.  
I, Martin Nilsson, declare that I am the sole auther of the content I add to this repository.  
I, Felix Stockinger, declare that I am the sole auther of the content I add to this repository.  
I, Lukas Ydkvist, declare that I am the sole auther of the content I add to this repository.  
I, Jacob Danielsson, declare that I am the sole auther of the content i add to this repository.  
