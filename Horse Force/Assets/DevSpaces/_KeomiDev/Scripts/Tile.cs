using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class Tile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  public TileState state { get; private set; }

    public TileCell cell { get; private set; }

    public int number { get; private set; }

    public void SetState(TileState state, int number) 
    {
        this.state = state;
        this.number = number;
    }


    public void Spawn(TileCell cell) 
    {
        if (this.cell != null) {

            this.cell.tile = null;
        
        }

        this.cell = cell;
        this.cell.tile = this;

        transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z - 2);
        
    
    }


    public void MoveTo(TileCell cell) 
    {
        if (this.cell != null)
        {

            this.cell.tile = null;

        }

        this.cell = cell;
        this.cell.tile = this;

        StartCoroutine(Animate(cell.transform.position ));

    }


    private IEnumerator Animate(Vector3 to) 
    {
        float elapsed = 0f;
        float duration0 = 0.1f;

        Vector3 from = transform.position;

        while (elapsed < duration0)
        {
            transform.position = Vector3.Lerp(from, to, elapsed / duration0);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = to;

    }



}



