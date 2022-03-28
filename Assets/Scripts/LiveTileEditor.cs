using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LiveTileEditor : MonoBehaviour
{
    public Tile chosenTile;
    public Tilemap tileMap;
    public Transform gridCursor;

    int maxHeight = 10;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnTile(GetWorldToCellPosition(gridCursor.position));
        }

        if (Input.GetMouseButtonDown(1))
        {
            RemoveTile(GetWorldToCellPosition(gridCursor.position));
        }
    }

    Vector3Int GetWorldToCellPosition(Vector3 worldPosition)
    {
        return tileMap.WorldToCell(worldPosition);
    }

    void SpawnTile(Vector3Int cellPosition)
    {
        for(int i = 0; i < maxHeight; i++)
        {
            Vector3Int checkPos = new Vector3Int(cellPosition.x, cellPosition.y, i);

            if (!tileMap.HasTile(checkPos))
            {
                tileMap.SetTile(checkPos, chosenTile);
                break;
            }
        }
    }

    void RemoveTile(Vector3Int cellPosition)
    {
        for(int i = maxHeight; i > 0; i--)
        {
            Vector3Int checkPos = new Vector3Int(cellPosition.x, cellPosition.y, i);

            if (tileMap.HasTile(checkPos))
            {
                tileMap.SetTile(checkPos, null);
                break;
            }
        }
    }
}