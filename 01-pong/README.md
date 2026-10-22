# 01 - Pong

Recreation of classic Pong


**Play it:** [itch.io](#) | **Engine:** Unity 6 (6000.3.9f1) | **Time spent:** ~6 hours

## Controls

| Action | Input |
|--------|-------|
| Player 1 Move | W, S keys |
| Player 2 Move | Arrow keys |

## Goal of the game

Score 10 points first to win.

## Development Goals

- [x] Create an arena with two walls and a divider.

- [x] Add a paddle on either end of the play field. Use player inputs to move the paddles up and down.

- [x] Add a ball that moves around the playfield and bounces off of the paddles and walls.

- [x] Detect when the ball leaves the playfield. Assign a point to the player who scored.

- [x] Track and display the score for each player.
## Stretch Development Goals

- [ ] Write an AI script that can follow the ball so you can play with only one player.

- [ ] Add a menu and allow the player to reset the game.

- [x] Add some basic sounds. Play a sound every time the ball collides with something, and every time a player scores.

## Reflection

**What went well**
-

- Simple art only using Unity basic sprites.
- Easy player input to paddle movement

**What was hard**
-

- Making a collision detection system, even though it was only rectangles

**What I'd do differently**
-

- Spend more time learning about how game engine does collision detections
**New things I learned**
-

- Detecting collision without using Unity's rigidbody & colliders - Use AABB method for rectangular bounding box collisions.
    - Basics of Separating Axis Theorem
- Canvas Scaler can make UI elements scale with screen size.
- Making my own sound effects using Audacity

## Credits
  - Art/Audio
    - Font: https://www.mattlag.com/bitfonts/
    - Audio: Made by me using Audacity / Chrome Music Lab 
- References: Original "Pong(1972)" by Atari
