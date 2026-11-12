using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileRow : MonoBehaviour
{
    public TileCell[] cells { get; private set; }

    private void Awake()
    {
        cells = GetComponentsInChildren<TileCell>();

        if (cells.Length == 0)
        {
            Debug.Log("Row Cells list Fucked");
        }


    }
}
