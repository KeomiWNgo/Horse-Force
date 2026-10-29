using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;

public class Board : MonoBehaviour
{

    #region Events
    public delegate void Add2Score(int calc);

    public event Add2Score EAdd2Score;
    #endregion

    #region Vars
    AttackButton atkButton;
    private SwipeDetection swipeDetection;

    private GameManager gameManager;

    public Tile tilePrefab;

    public TileState[] tileStates;
    private Grid grid;
    public List<Tile> tiles { get; private set; }

    private bool waiting;

    private int toSend;

    #endregion

    private void Awake()
    {
        atkButton = FindAnyObjectByType<AttackButton>();
        grid = GetComponentInChildren<Grid>();
        tiles = new List<Tile>(16);
        gameManager = FindAnyObjectByType<GameManager>();
        swipeDetection = FindAnyObjectByType<SwipeDetection>();

    }

    private void OnEnable()
    {
        swipeDetection.EmovDir += InputReceived;
    }

    /// <summary>
    /// clears Board
    /// </summary>
    public void ClearBoard()
    {
        foreach (var tileCell in grid.cells)
        {
            tileCell.tile = null;
        }

        foreach (var tile in tiles)
        {
            Destroy(tile.gameObject);
        }

        tiles.Clear();

    }


    /// <summary>
    /// Creates Tile
    /// </summary>
    public void CreateTile()
    {

        Tile tile = Instantiate(tilePrefab, grid.transform);

        tile.SetState(tileStates[0], 2);

        tile.Spawn(grid.GetRandomEmptyCell());

        tiles.Add(tile);
    }





    // This portion is the delagate funtion form detect swipe that takes the swipe detection and call [Movetiles function] and provides start and increments based on direction
    private void InputReceived(Vector2Int direction)
    {

        if (!waiting)
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
                MoveTiles(direction, 1, 1, 0, 1);
            }
            if (direction == Vector2.right)
            {
                MoveTiles(direction, grid.width - 2, -1, 0, 1);
            }
        }

    }
    //


    // This Portions cyles through all the tiles on the board in a given direction and start while also setting if it's been changed
    private void MoveTiles(Vector2Int direction, int startX, int incrementX, int startY, int incrementY)
    {

        bool changed = false;

        for (int x = startX; x >= 0 && x < grid.width; x += incrementX)
        {
            for (int y = startY; y >= 0 && y < grid.height; y += incrementY)
            {

                TileCell cell = grid.GetCell(x, y);

                if (cell.occupied)
                {
                    changed |= MoveTile(cell.tile, direction);

                }


            }
        }

        if (changed)
        {
            StartCoroutine(WaitForChanges());
        }

    }
    //


    // This Portion is what moves it by calling [tile.moveto] [canmerge] and [get adjacent]
    private bool MoveTile(Tile tile, Vector2Int direction)
    {
        TileCell Startingcell = tile.cell;

        TileCell newCell = null;
        TileCell adjacentCell = grid.GetAdjacentCell(tile.cell, direction);

        while (adjacentCell != null)
        {
            if (adjacentCell.occupied)
            {
                if (CanMerge(tile, adjacentCell.tile))
                {
                    Merge(tile, adjacentCell.tile);
                    return true;
                }
                break;
            }


            newCell = adjacentCell;

            adjacentCell = grid.GetAdjacentCell(newCell, direction);

        }

        if (newCell != null)
        {
            tile.MoveTo(newCell);
            return true;
        }
        return false;
    }




    // this is called apon merging
    private void Merge(Tile a, Tile b)
    {
        tiles.Remove(a);
        a.Merge(b.cell);

        int index = Mathf.Clamp(IndexOf(b.state) + 1, 0, tileStates.Length - 1);
        int number = b.number * 2;

        b.SetState(tileStates[index], number);
        b.Mat2Change.material.color = b.state.platformColor;
        b.childTMP.text = b.number.ToString();
        StartCoroutine(Mergefeedback(b.transform.localScale, b));



    }

    private int IndexOf(TileState state)
    {
        for (int i = 0; i < tileStates.Length; i++)
        {
            if (state == tileStates[i])
            {
                return i;
            }


        }


        return -1;

    }


    /// <summary>
    /// This Portion checks if a and be can merge
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private bool CanMerge(Tile a, Tile b)
    {

        return a.number == b.number && !b.locked;

    }




    //Calculates the score and the attack value
    public int ScoreCalc()
    {

        toSend = 0;

        for (int i = 0; i < tiles.Count; i++)
        {
            toSend = toSend + tiles[i].number;
        }

            EAdd2Score(toSend);


        return toSend;

    }





    private IEnumerator Mergefeedback(Vector3 start, Tile tiletochange)
    {
        float elapsed = 0f;
        float duration0 = 0.05f;

        Vector3 end = start + new Vector3(5f, 5f, 5f);

        while (elapsed < duration0)
        {
            tiletochange.transform.localScale = Vector3.Lerp(start, end, elapsed / duration0);
            elapsed += Time.deltaTime;

            yield return null;
        }

        elapsed = 0f;
        duration0 = 0.1f;

        while (elapsed < duration0)
        {
            tiletochange.transform.localScale = Vector3.Lerp(end , start, elapsed / duration0);
            elapsed += Time.deltaTime;

            yield return null;
        }

    }


    public IEnumerator WaitForChanges() 
    {
        waiting = true;

        yield return new WaitForSeconds(0.25f);
        
        waiting = false;


        foreach (var tile in tiles)
        {
            tile.locked = false;
        }



        if (tiles.Count != grid.size)
        {
            CreateTile();
        }

        if (CheckForGameOVer())
        {
            ScoreCalc();
            Debug.Log("LOST");
            gameManager.GameOver();
            
        }




    }
    /// <summary>
    /// Checks if the game is over
    /// </summary>
    /// <returns></returns>
    private bool CheckForGameOVer ()
    
    {
        if (tiles.Count != grid.size)
        {
            return false;
        }

        foreach (var tile in tiles)
        {
            TileCell up = grid.GetAdjacentCell(tile.cell, Vector2Int.up);
            TileCell down = grid.GetAdjacentCell(tile.cell, Vector2Int.down);
            TileCell left = grid.GetAdjacentCell(tile.cell, Vector2Int.left);
            TileCell right = grid.GetAdjacentCell(tile.cell, Vector2Int.right);

            if (up != null && CanMerge(tile, up.tile)) 
            {
                return false;
            }
            if (down != null && CanMerge(tile, down.tile))
            {
                return false;
            }
            if (left != null && CanMerge(tile, left.tile))
            {
                return false;
            }
            if (right != null && CanMerge(tile, right.tile))
            {
                return false;
            }
        }


        if (atkButton.GetCooldown() >= atkButton.coolThresh)
        {

            return false;

        }


        

        return true;


    }







}
