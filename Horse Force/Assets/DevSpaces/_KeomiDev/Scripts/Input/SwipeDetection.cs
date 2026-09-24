using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{

    #region Events
    public delegate void MoveDir(Vector2Int direction);
    public event MoveDir EmovDir;



    #endregion Events

    private InputManager inputManager;

    [SerializeField]
    private float minimumDistance = .2f;
    [SerializeField]
    private float maximumTime = 1f;
    [SerializeField, Range (0,1)]
    private float directionThreshold =.9f;

    [SerializeField]
    private GameObject trail;

    private Vector2 startPosition;
    private float startTime;

    private Vector2 endPosition;
    private float endTime;

    private Coroutine coroutine;


    private void Awake()
    {
        inputManager = FindAnyObjectByType<InputManager>(); 

    }
    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;

    }
    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time) {
        startPosition = position;
            startTime = time;
        trail.SetActive(true);
        trail.transform.position = position;
        coroutine = StartCoroutine(Trail());
    }


    private IEnumerator Trail() {
        while (true) { trail.transform.position = inputManager.PrimaryPosition();
            yield return null;
        }
    }

    private void SwipeEnd(Vector2 position, float time){
        endPosition = position;
        endTime = time;
        StopCoroutine(coroutine);
        DetectSwipe();
    }

    private void DetectSwipe() {
        if (Vector3.Distance(startPosition, endPosition) >= minimumDistance && (endTime - startTime) <= maximumTime) {
            Debug.Log("Swipe Detected");
            Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
                }
    }

    private void SwipeDirection(Vector2 direction) {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
          //  Debug.Log("Swipe UP");
            if (EmovDir != null)
            {
                EmovDir(Vector2Int.up);

            }

        }
        if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            if (EmovDir != null)
            {
                EmovDir(Vector2Int.down);

            }

        }
        if (Vector2.Dot(Vector2.left, direction) > directionThreshold) 
        { 
         //   Debug.Log("Swipe Left");
            if (EmovDir != null)
            {
                EmovDir(Vector2Int.left);
            }
        }
        if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
          //  Debug.Log("Swipe Right");
            if (EmovDir != null)
            {
                EmovDir(Vector2Int.right);
            }
        }
    }






}
