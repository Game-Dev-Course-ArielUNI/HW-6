using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

/**
 * Lets the player carve mountain tiles into grass using the pickaxe.
 * Carving makes the tile permanently walkable as grass.
 */
public class TileCarver : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Tilemap tilemap = null;
    [SerializeField] private PlayerAbilities playerAbilities = null;
    [SerializeField] private AllowedTiles allowedTiles = null;

    [Header("Tile types")]
    [SerializeField] private TileBase[] mountainTiles = null;
    [SerializeField] private TileBase grassTile = null;

    [Header("Input")]
    [SerializeField] private InputAction carveAction = new InputAction(type: InputActionType.Button);
    [SerializeField] private InputAction carvePosition = new InputAction(type: InputActionType.Value, expectedControlType: "Vector2");

    private void OnValidate()
    {
        if (carveAction.bindings.Count == 0)
            carveAction.AddBinding("<Mouse>/rightButton");

        if (carvePosition.bindings.Count == 0)
            carvePosition.AddBinding("<Mouse>/position");
    }

    private void OnEnable()
    {
        carveAction.Enable();
        carvePosition.Enable();
    }

    private void OnDisable()
    {
        carveAction.Disable();
        carvePosition.Disable();
    }

    private void Update()
    {
        if (!carveAction.WasPerformedThisFrame())
            return;

        if (playerAbilities == null || !playerAbilities.hasPickaxe)
            return; // No pickaxe -> cannot carve

        Vector2 screenPos = carvePosition.ReadValue<Vector2>();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0f;

        Vector3Int cell = tilemap.WorldToCell(worldPos);
        TileBase currentTile = tilemap.GetTile(cell);

        if (currentTile == null)
            return;

        // Only carve if this tile is a mountain
        if (mountainTiles != null && System.Array.IndexOf(mountainTiles, currentTile) >= 0)
        {
            // Replace mountain with grass on the tilemap
            tilemap.SetTile(cell, grassTile);
            Debug.Log($"Carved mountain at {cell} into grass.");
        }
    }
}
