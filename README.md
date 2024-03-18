## Problem:  Martian  Robots

The surface of Mars can be modelled by a rectangular grid around which robots are able to
move according to instructions provided from Earth. You are to write a program that
determines each sequence of robot positions and reports the final position of the robot.
A robot position consists of a grid coordinate (a pair of integers: x-coordinate followed by
y-coordinate) and an orientation (N, S, E, W for north, south, east, and west).
A robot instruction is a string of the letters “L”, “R”, and “F” which represent, respectively, the
instructions:

* Left : the robot turns left 90 degrees and remains on the current grid point.
* Right : the robot turns right 90 degrees and remains on the current grid point.
* Forward : the robot moves forward one grid point in the direction of the current
  orientation and maintains the same orientation

The direction North corresponds to the direction from grid point (x, y) to grid point (x, y+1).
Developer Programming Problem
Red Badger Consulting Limited
Page 1 of 3
There is also a possibility that additional command types may be required in the future and
provision should be made for this.
Since the grid is rectangular and bounded (…yes Mars is a strange planet), a robot that
moves “off” an edge of the grid is lost forever. However, lost robots leave a robot “scent” that
prohibits future robots from dropping off the world at the same grid point. The scent is left at
the last grid position the robot occupied before disappearing over the edge. An instruction to
move “off” the world from a grid point from which a robot has been previously lost is simply
ignored by the current robot

### Input

```
5 3 

1 1 E
RFRFRFRF

3 2 N
FRRFLLFFRRFLL

0 3 W
LLFFFLFLFL      

```

### Output

```
1 1 E
3 3 N LOST
2 3 S
```

## Structure

The tests are written in a way which can be easily readable and explain the unit under tests.

There are 2 main folders

- Test -> contains unit tests and setup
- Src -> contains the core domain logic

The core logic is split into folder structures which define the paths taken to help solve the problem in hand. Two key processes was used to help use the solution adheres to SOLID, KISS, AND DRY.

## Prerequisites

To run the solution locally, please ensure you have the .Net 6 SDK on your machine .

- CD into working directory and try

`
dotnet test
`

## Solution Console App in .NET 6

- Based on the given test cases the implementation is driven by test driven development . You can review the commits to see the tests are written first and the the solution is provided. When the given test passes, then we have an opportunity to refactor and use some design patterns.
- A factory design pattern was used to help create multiple commands based on the input. This pattern allows you to extend in the future if a new command is available.
- A strategy design pattern was used to help with the SOLID principles, extensibility and ensure the N,E,S,W (directions) are in a single unit with its own context.
- Based on the given input, a technique of sociable unit test was used this help drive the implementation of the robot movement based on the instructions.
- The approach was to keep it simple

## Run the Application to see the output

- Please modify the file path in program.cs to point to the location of TestCases.txt on your machine.
- I have crated a FileReader.cs class which reads the given test cases from the file and creates the Mars Surface / Robot and executes its instructions.
- If the file path is pointed correctly, then run f5 and this will execute the given inputs above and display the output.

## Improvements

Given more time i would have
- Added defensive coding
- Additional error handling
- Added error logging
- Provided component level testing
- Provided a more clear approach to having a context builder which keeps hold of the state per instruction . (Maybe a bit overkill)