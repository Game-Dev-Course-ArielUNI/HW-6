# Unity week 5: Two-dimensional scene-building and path-finding

A project with step-by-step scenes illustrating how to construct a 2D scene using tilemaps,
and how to do path-finding using the BFS algorithm.

* Text explanations are available 
[here](https://github.com/gamedev-at-ariel/gamedev-5782) in folder 07.

* the game in itch.io are available
 [here](https://yousef-masarwa97.itch.io/player-vs-enemy)


---
# Part A:

 * enemey chase the player that can pick abilities to help him run:

->boat:can use it to walk on sea

->goat:can use it to walk on mountains

->Pickaxe:can use it to swap mountains  to grass by clicking on the right mouse button

---

# Part B:

now the enemy run away from the player by using a greedy algorithm that always picks to walk to the farest position from the player position from the 4 nearest מeighbors.
