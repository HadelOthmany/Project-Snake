# Snake Game – C# Windows Forms

This project is an extended version of the classic Snake game, developed in **C# using Windows Forms**.

The game supports multiple players and different types of food that affect the snake in different ways.

## Main Features

- 1–3 player support
- Keyboard-controlled snakes
- Score tracking
- Snake growth and shrinking
- Collision detection
- Different player colors
- Random food spawning
- Game restart menu

### Player Controls

- **Player 1:** W, A, S, D
- **Player 2:** Arrow Keys
- **Player 3:** I, J, K, L

## Food Types

The game contains several food types implemented using inheritance.

- **Standard Food** – gives points and increases the snake length
- **Valuable Food** – gives more points and increases the snake length more
- **Diet Food** – gives points but decreases the snake length
- **Random Speed Booster Food** – temporarily increases the speed of a randomly selected snake

A `FoodFactory` is used to randomly create the different food types.

## Object-Oriented Design

The project uses several object-oriented programming concepts:

- Classes and objects
- Encapsulation
- Inheritance
- Abstract classes
- Polymorphism
- Factory pattern
- Separation of responsibilities

`AbstractFood` acts as the base class for the different food types, while each food class implements its own behavior when consumed.

The `GameEngine` manages the game state, players, movement, food generation and collision detection.

## Learning

Through this project I practiced:

- Object-oriented programming in C#
- Inheritance and polymorphism
- Abstract classes
- Factory pattern
- Event handling
- Windows Forms
- Timers
- Collision detection
- Multiplayer input handling
- Game state management

## Technologies

- C#
- .NET 6
- Windows Forms
- Visual Studio

## Author

**Hadel Othmany**

Computer Science  
Mälardalen University
