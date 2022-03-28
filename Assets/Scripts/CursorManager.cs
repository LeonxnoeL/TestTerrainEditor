using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CursorManager : MonoBehaviour
{
    public Tilemap tileMap;

    public Transform cursorPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCursor();
    }

    void UpdateCursor()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 gridPosition = GetCellPosition(worldPosition);

        cursorPosition.position = gridPosition;
    }

    Vector3 GetCellPosition(Vector3 worldPosition)
    {
        Vector3Int cellPosition = tileMap.WorldToCell(worldPosition);

        Vector3 centerCell = tileMap.GetCellCenterWorld(cellPosition);

        Vector3 finalPosition = new Vector3(centerCell.x, centerCell.y, 0);

        return finalPosition;
    }
}