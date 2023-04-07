# Space Ship Core Game

Game Link: https://wissam111.itch.io/spaceship-ass4-part1

## Implemented

- -----------From the list-----------
- 1- the space ship has 3 hits till it gets destroyed (3 hearts at start of the game)
- 2- The player cannot shoot lasers non-stop, there is a trigger delay
- -----------Not from the list-----------
- 3- Leaser,Hit SoundEffects.
- 4- Each time the player score + amoutOfpoints for example 50, he will be granted a new life and at will be showed in screen as heart (he can only reaches 5 hearts).
- 5- Background Music.
- 6- GameOver Screen.
- 7- Explosion animation.

## Changes

the changes where made in **scences -> triggers -> d-shield**

- Adding Playerlife script to the Player Object, and unchecked DestroyOnTrigger2D Script in Player.
- Adding EndMenu Script that handle endgame.
- In ScoreAdder Script added if statment that checks if to give reward.
- In ClickSpawner Script added a shooting rate.
- Added Heart Prefab.
