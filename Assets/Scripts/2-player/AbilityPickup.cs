using UnityEngine;

/**
 * Place this on Boat / Goat / Pickaxe prefab objects with a 2D trigger collider.
 * When the player touches it, they gain the ability and the pickup disappears.
 */
public class AbilityPickup : MonoBehaviour
{
    public enum AbilityType
    {
        Boat,
        Goat,
        Pickaxe
    }

    [SerializeField] private AbilityType abilityType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerAbilities abilities = other.GetComponent<PlayerAbilities>();
        if (abilities == null)
            return; // Not the player

        switch (abilityType)
        {
            case AbilityType.Boat:
                abilities.hasBoat = true;
                break;
            case AbilityType.Goat:
                abilities.hasGoat = true;
                break;
            case AbilityType.Pickaxe:
                abilities.hasPickaxe = true;
                break;
        }

        // Destroy this pickup after being collected
        Destroy(gameObject);
    }
}
