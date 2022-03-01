using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 endPosition = new Vector3(8, 5, 5);
    private Vector3 startPosition;
    private float desiredDuration = 3f;
    private float elapsedTime;

    private GridController gridController;
    public GameObject gridObject;

    void Start()
    {
        gridController = gridController.gameObject.GetComponent<GridController>();
    }

    void Update()
    {
        
    }
    private void CorrectLerpMovement() // Correct way to use lerp
    {
        elapsedTime += Time.deltaTime;
        float percentageCompleted = elapsedTime / desiredDuration;

        transform.position = Vector3.Lerp(startPosition, endPosition, percentageCompleted);
    }
    private void PlayerMovement()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

        }
    }
}
