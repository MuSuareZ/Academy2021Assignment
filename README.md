# Academy2021Assignment

### My Implementation Approach

#### Camera and Player Movement
- The player movement had a simple approach since its X value is constrained, having only one axis to focus on. By pressing the mouse left button, a certain velocity is applied to the player's ball while having a gravity force always pulling its body downwards (opposite direction).
- While the player can go upwards and downwards, the camera's movement is only able to go upwards. The camera follows the player's movement, if the player's Y position is bigger than the camera's Y position, therefore only going upwards.

#### Color Switching and Collisions 
- Color switching was probably the most tricky part of this assignment due to the restriction of never selecting a new color that was equal to the player's current color. At first, my approach was on using shuffling methods but after a few tries, I managed to accomplish this task by using a generic collection (Dictionary(string)(color)) to store the color tags and the player's sprite renderer color. When setting an initial color, a simple method was called to sort a random color from this collection and assigned to the player. When setting a new color after each collision on a color switch, a temporary list is created while ignoring the player's current color to make sure the same color would never be selected and then from this list a new random color is selected and assigned to the player.
 - Tags played a major role to accomplish these mandatory features. Since every piece of an obstacle would have one and only exact color, it made the use of tags possible in order
to validate a possible collision or not while always saving the current player's color and comparing both.

#### Obstacle's Spawner and Destruction
- The obstacle's spawner is a gameObject present in the scene that receives a list of all prefab obstacles, sorts a random value from 0 to the amount of prefabs on the list and takes this value to instantiate a random prefab and a color switch at a position outside the player view range. While the player progresses through the scene, new obstacles are generated. That gives the player the feeling of an infinite game.
- Attached to the camera are two box colliders, in which one is responsible for triggering the player defeat in case its Y position reaches the camera bottom side and the other is responsible for destroying already crossed obstacle's to avoid generating so many data and eventually affecting the game's performance.

#### HUD and UI
- As suggested, I decided to use TextMeshPro for my UI elements such as Text and Buttons.
- The text was generated on the left top corner of the screen with the variable "Score" that shows how many stars the player has collected during its gameplay.
- A button at game start is set as Deactivated and only activated once the player is at dead state. OnButtonPressing, a method restart game is called and the scene is set to the beggining.

### Possible Implementations

- New obstacles with varied speed and sizes by randomizing its rotation speed and scale with possible values in order to avoid exceeding the game screen size or making an obstacle impossible to be crossed.
- A highest score value storing and leveling up system to give players a sense of progression.
- Monetization through advertisements and visual customization (visuals for the player's ball, background, obstacle themes). Free but simple visual customizations could be given according to the player's progression/level.
- A better approach at design patterns (separation of concerns). Some functionalities could be moved to their own places for a more concise and organized code.
