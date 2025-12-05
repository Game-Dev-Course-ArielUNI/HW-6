using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component keeps the rules of which tiles are walkable.
 * It now supports special player abilities:
 *  - Boat  -> allows walking on water tiles
 *  - Goat  -> allows walking on mountain tiles
 *  - Pickaxe -> used to carve mountains (handled in TileCarver).
 */
public class AllowedTiles : MonoBehaviour
{
    [Header("Always-walkable tiles (e.g. grass, floor)")]
    [SerializeField] private TileBase[] allowedTiles = null;

    [Header("Special terrain tiles")]
    [SerializeField] private TileBase[] waterTiles = null;
    [SerializeField] private TileBase[] mountainTiles = null;

    [Header("Whose abilities to use (usually the player)")]
    [SerializeField] private PlayerAbilities playerAbilities = null;

    /// <summary>
    /// Base tiles that are ALWAYS allowed, regardless of abilities
    /// (kept for compatibility with existing code).
    /// </summary>
    public TileBase[] Get()
    {
        return allowedTiles;
    }

    /// <summary>
    /// Return true if this tile is walkable under the current abilities.
    /// </summary>
    public bool Contains(TileBase tile)
    {
        if (tile == null)
        {
            Debug.Log("[AllowedTiles] tile == null → false");
            return false;
        }

        string tileName = tile.name;

        bool baseAllowed = (allowedTiles != null && allowedTiles.Contains(tile));

        // If no PlayerAbilities assigned, fall back to the old static behavior
        // (useful for enemies).
        if (playerAbilities == null)
        {
            Debug.Log($"[AllowedTiles] No PlayerAbilities, fallback. tile={tileName}, baseAllowed={baseAllowed}");
            return baseAllowed;
        }

        // 1. Tiles that are always walkable (like grass)
        if (baseAllowed)
        {
            Debug.Log($"[AllowedTiles] {tileName} is ALWAYS allowed (base list).");
            return true;
        }

        // 2. Water tiles: only walkable if we have a boat
        if (waterTiles != null && waterTiles.Contains(tile))
        {
            Debug.Log($"[AllowedTiles] {tileName} is WATER. hasBoat={playerAbilities.hasBoat}");
            return playerAbilities.hasBoat;
        }

        // 3. Mountain tiles: walkable only if we have a goat
        if (mountainTiles != null && mountainTiles.Contains(tile))
        {
            Debug.Log($"[AllowedTiles] {tileName} is MOUNTAIN. hasGoat={playerAbilities.hasGoat}");
            return playerAbilities.hasGoat;
        }

        Debug.Log($"[AllowedTiles] {tileName} is NOT walkable.");
        return false;
    }
}











//using System.Linq;
//using UnityEngine;
//using UnityEngine.Tilemaps;

///**
// * This component just keeps a list of allowed tiles.
// * Such a list is used both for pathfinding and for movement.
// */
//public class AllowedTiles : MonoBehaviour  {
//    [SerializeField] TileBase[] allowedTiles = null;

//    public bool Contains(TileBase tile) {
//        return allowedTiles.Contains(tile);
//    }

//    public TileBase[] Get() { return allowedTiles;  }
//}
