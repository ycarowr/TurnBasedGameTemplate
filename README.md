# TurnBasedGameTemplate
 
The idea here is to have the core implementation and the basic funcionalities of a turn-based game working in a clean repository, so every time a new project/prototype comes along I may use this implementation and skip rebuilding the basic mechanics.

## Structures and funcionalities:

1. Two players, Top and Bottom; (can be extended to more players)
2. Events such as Start and End match integrated with an UI;
3. Events like Player Started and Finished Turn also integrated with a simple UI;
4. Restart point.

I am not going to go further with details about the implementation because you can check the repo. But the idea is to have a MVC with a separation between Model and UI. 

All the comunication UI and Model is done using the Singleton Pattern and the Observer Pattern.

1. [State Machine that controls the game flow](https://github.com/ycarowr/TurnBasedGameTemplate/tree/master/Assets/Scripts/TurnBasedGameTemplate/Model/TurnBasedFSM)
2. [Game Model](https://github.com/ycarowr/TurnBasedGameTemplate/tree/master/Assets/Scripts/TurnBasedGameTemplate/Model)
3. [Game Controller](https://github.com/ycarowr/TurnBasedGameTemplate/tree/master/Assets/Scripts/TurnBasedGameTemplate/GameController)
4. [Mechanics](https://github.com/ycarowr/TurnBasedGameTemplate/tree/master/Assets/Scripts/TurnBasedGameTemplate/Model/Game)
5. [Game Events](https://github.com/ycarowr/TurnBasedGameTemplate/blob/master/Assets/Scripts/TurnBasedGameTemplate/GameEvents/GameEvents.cs)
6. [UI](https://github.com/ycarowr/TurnBasedGameTemplate/tree/master/Assets/Scripts/TurnBasedGameTemplate/UI)
7. [Patterns and Tools](https://github.com/ycarowr/TurnBasedGameTemplate/tree/master/Assets/Scripts/TurnBasedGameTemplate/Tools)

Gif for a better visualization of the game flow:
![alt](https://github.com/ycarowr/TurnBasedGameTemplate/blob/master/Assets/Textures/TurnBasedTemplate.gif)

Default Configurations:

![alt](https://github.com/ycarowr/TurnBasedGameTemplate/blob/master/Assets/Textures/TurnBasedGameTemplate/parameters.GIF)

