# Car-Race
CarRaceSimulation
CarRaceSimulation is a console application that simulates a car race between three cars. Each car has a speed and a starting position, and the application simulates the time it takes for each car to reach the finish line.

During the race, random events can affect the speed and time of both cars. For example, a car may need to make pit stops to refuel or change tires, or experience delays due to technical issues.

Codebase
The codebase is written in C# and comprises three methods:

Main: The main method that executes when the program starts. It creates two cars and then invokes the RunRace method for each car.

RunRace: Simulates the race for a single car. This method takes two parameters: a CarModelClass that represents the car and a racelength that denotes the track's length in kilometers.

RaceStatus: Updates the console with information regarding both cars and their progress throughout the race.

The codebase also encompasses a CarModelClass class that defines the properties of a car.
