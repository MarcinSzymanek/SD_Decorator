This project is a zero player game intended solely for showing some of the ways to use Decorator pattern in game design.

In the game, Player battles against Monsters. Once a monster is defeated, a new one is spawned with a chance of being special. Special monsters can be Big (increases damage and hitpoints), Critical (chance of critical damage), or armoured (Reduce damage by one). This continues until player dies.

The different special varieties of enemies (or the player) are implemented using the Decorator pattern, see diagrams in Docs/out folder.

Because of the short development time, a lot of non-critical features were added on the fly and the project struggles with Interface Segregation Principle: in particular GameController and UI classes are too big and could very much use to be split into subclasses, or separate controllers for gamelogic and for example message log. Simply put, the project as a whole does not adhere to SOLID-principles.

10/11/2022 Marcin Szymanek
