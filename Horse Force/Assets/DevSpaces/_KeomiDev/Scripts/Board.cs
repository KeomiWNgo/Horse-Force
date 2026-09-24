using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Board : MonoBehaviour
{

    public SwipeDetection swipeDetection;

    public Tile tilePrefab;

    public TileState[] tileStates;
    private Grid grid;
    private List<Tile> tiles;

    private void Awake()
    {
        grid = GetComponentInChildren<Grid>();
        tiles = new List<Tile>(16);



    }

    private void OnEnable()
    {
        swipeDetection.EmovDir += InputReceived;
    }

   

    private void Start()
    {
        CreateTile();

        CreateTile();
    }

    private void Update()
    {
        
    }


    private void CreateTile() 
    {

        Tile tile = Instantiate(tilePrefab, grid.transform);
     
        tile.SetState(tileStates[0], 2);

        tile.Spawn(grid.GetRandomEmptyCell());

        tiles.Add(tile);
    }

    private void InputReceived(Vector2Int direction)
    {


        if (direction == Vector2.up)
        {
            MoveTiles(direction, 0, 1, 1, 1);
        }

        if (direction == Vector2.down)
        {
            MoveTiles(direction, 0, 1, grid.height - 2, -1);
        }

        if (direction == Vector2.left)
        {
            MoveTiles(direction, 1, 1, 0 , 1);
        }
        if (direction == Vector2.right)
        {
            MoveTiles(direction, grid.width -2 , - 1, 0, 1);
        }


    }
     private void MoveTiles(Vector2Int direction, int startX, int incrementX, int startY, int incrementY)
    {

        for (int x = startX; x >= 0 && x < grid.width; x += incrementX)
        {
            for (int y = startY; y >= 0 && y < grid.height; y += incrementY)
            {

                TileCell cell = grid.GetCell(x, y);

                if (cell.occupied)
                {
                    MoveTile(cell.tile, direction);
                }


            }
        }



    }


    private void MoveTile(Tile tile, Vector2Int direction) 
    {
        TileCell Startingcell = tile.cell;
     
        TileCell newCell = null;
        TileCell adjacentCell = grid.GetAdjacentCell(tile.cell, direction);

        while (adjacentCell != null)
        {
            if (adjacentCell.occupied)
            {
                // merging
                break;
            }


            newCell = adjacentCell;

            adjacentCell = grid.GetAdjacentCell(newCell, direction);

        }

        if (newCell != null)
        {
            tile.MoveTo(newCell);
        }
      //  Startingcell.tile = null;
    }


   /* private bool CanMerge(Tile a, Tile b) 
    { 
    
    
        
    }*/


}
