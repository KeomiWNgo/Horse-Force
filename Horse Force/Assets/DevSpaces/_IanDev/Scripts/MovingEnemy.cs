using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This script is designed to give the enemies a bit of dynamicism.
// It will move them up and down on the screen while in play.

public class MovingEnemy : MonoBehaviour
{
    // Start at 20
    // Move to 18.5
    // Move up again

    // Initialize Variables
    public GameObject movingEnemy;
    [SerializeField] private float y = 20f;
    [SerializeField] private float moveSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        y = Mathf.PingPong(Time.time * moveSpeed, 1) + 20f;
        movingEnemy.transform.position = new Vector3(0, y, 53.7f);
    }
}
