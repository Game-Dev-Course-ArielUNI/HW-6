using UnityEngine;

/**
 * Stores which special abilities the player has collected.
 */
public class PlayerAbilities : MonoBehaviour
{
    [Header("Abilities")]
    public bool hasBoat = false;      // Can sail on water
    public bool hasGoat = false;      // Can walk on mountains
    public bool hasPickaxe = false;   // Can carve mountains into grass
}
