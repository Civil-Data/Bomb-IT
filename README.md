# BOMB-IT
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
* Items, pickup and powerups. Player will pickup items to improve his or her stats. Ie More powerful bombs (+1 range), faster movement (increase by a factor of 1.1 (10%)) etc. When picked up these shall be removed
* Basic UI. Choose number of players, size of map and gamemode.
* Random map generator.

## Build System
We have not currently choosen a build system for this project. Currently choosing between: mark and ant.   
For starters we will just use visual studio as our build system but we will change this.

## Requirements 
* Unity Hub is needed to run our program you can download Unity Hub from this link: https://store.unity.com/download
* When Unity is installed you also need to install Unity Editor version 2022.2.2f1

## Compiling and Running
1. Clone our repository to desired location on your computer.
2. Open the project from Unity Hub
3. Compile and run with Unity Editor by pressing play button.
4. When playbutton is pressed our ingame Menu will be shown.

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
