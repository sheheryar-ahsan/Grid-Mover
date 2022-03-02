using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 endPosition = new Vector3(8, 5, 5);
    private Vector3 startPosition;
    private float desiredDuration = 3f;
    private float elapsedTime;

    private bool isMoving;
    public float speed;
    private Vector3 oriPos;
    private Vector3 targetPos;
    private float timeToMove = 0.15f;

    private GridController gridController;
    public GameObject gridObject;

    public int numOfCols;
    public int numOfRows;
    public float gapValue;

    void Start()
    {
        gridController = gridObject.gameObject.GetComponent<GridController>();
        gapValue = gridController.gapValue;
        numOfCols = gridController.numOfCols - 1;
        numOfRows = gridController.numOfRows - 1;
    }

    void Update()
    {
        PlayerInput();
    }
    private void CorrectLerpMovement() // Correct way to use lerp
    {
        elapsedTime += Time.deltaTime;
        float percentageCompleted = elapsedTime / desiredDuration;

        transform.position = Vector3.Lerp(startPosition, endPosition, percentageCompleted);
    }
    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isMoving && (transform.position.z + 1 * gapValue * 2.5f <= numOfCols * gapValue * 2.5f))
        {
            StartCoroutine(PlayerMovement((Vector3.forward) * gapValue * 2.5f));
        }
        if (Input.GetKeyDown(KeyCode.S) && !isMoving && (transform.position.z - 1 * gapValue * 2.5f <= numOfCols * gapValue * 2.5f) && (transform.position.z - 1 >= 0)) // Special case for zero and greater
        {
            StartCoroutine(PlayerMovement((Vector3.back) * gapValue * 2.5f));
        }
        if (Input.GetKeyDown(KeyCode.A) && !isMoving && (transform.position.x - 1 * gapValue * 2.5f <= numOfRows * gapValue * 2.5f) && (transform.position.x - 1 >= 0)) // Special case for zero and greater
        {
            StartCoroutine(PlayerMovement((Vector3.left) * gapValue * 2.5f));
        }
        if (Input.GetKeyDown(KeyCode.D) && !isMoving && (transform.position.x + 1 * gapValue * 2.5f <= numOfRows * gapValue * 2.5f))
        {
            StartCoroutine(PlayerMovement((Vector3.right) * gapValue * 2.5f));
        }
    }
    private IEnumerator PlayerMovement(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;

        oriPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        targetPos = oriPos + direction;

        while (elapsedTime < timeToMove)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(oriPos, targetPos, (elapsedTime / timeToMove));
            yield return null;
        }

        isMoving = false;
    }
}
