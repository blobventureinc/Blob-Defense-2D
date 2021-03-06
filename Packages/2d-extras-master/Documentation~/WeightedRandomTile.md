# Weighted Random Tile

###### *Contributions by:  nicovain, distantcam*

Weighted Random Tiles are tiles which randomly pick a sprite from a given list of sprites and a target location, and displays that sprite. The sprites can be weighted with a value to change its probability of appearing. The Sprite displayed for the Tile is randomized based on its location and will be fixed for that particular location.

### Properties

| Property              | Function                                  |
| --------------------- | ----------------------------------------- |
| __Number of Sprites__ | The number of Sprites to randomize from.  |
| __Sprite__            | A Sprite to randomize with.               |
| __Weight__            | A Weight of the Sprite to randomize with. |
| __Color__             | The Color of the Tile.                    |
| __Collider Type__     | The Collider Shape generated by the Tile. |

### Usage

Set up the Weighted Random Tile with the Sprites to select from. The Weight of each Sprite determines the probability of the appearance of the Sprite where the higher the weight, the higher the probability of appearance.

![Weighted Random Tile Editor](images/WeightedRandomTileEditor.png)

Paint the Weighted Random Tile using the Tile Palette tools.

![Scene View with Weighted Random Tile](images/WeightedRandomTile.png)