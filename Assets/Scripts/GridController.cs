using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridController : MonoBehaviour
{
    public GameObject planePrefab;
    public TextMeshProUGUI birdText;
    public int numOfCols;
    public int numOfRows;
    public float gapValue = 1.1f;
    public GameObject[,] planeArray;
    Dictionary<int, string> dicObject = new Dictionary<int, string>();
    void Start()
    {
        GridSystem();
    }

    void Update()
    {
        
    }
    private void GridSystem()
    {
        planeArray = new GameObject[numOfCols, numOfRows];

        for (int i = 0; i < numOfCols; i++)
        {
            for (int j = 0; j < numOfRows; j++)
            {
                planeArray[i, j] = Instantiate(planePrefab, new Vector3(i*2.5f* gapValue,0.1f,j*2.5f* gapValue), planePrefab.transform.rotation);

            }
        }
    }
    private void RandomBirds()
    {
        dicObject.Add(1, "Sparrow");
        dicObject.Add(2, "Crow");
    }
}
