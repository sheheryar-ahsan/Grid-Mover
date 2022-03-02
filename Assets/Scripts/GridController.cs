using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class GridController : MonoBehaviour
{
    public GameObject planePrefab;
    public Canvas canvasPrefab;
    public TextMeshProUGUI birdText;
    public int numOfCols;
    public int numOfRows;
    public float gapValue;
    public GameObject[,] planeArray;

    Dictionary<int, string> dicObject = new Dictionary<int, string>();
    void Start()
    {
        AddToDictionary();
        GridSystem();
        //RandomBirds();
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
                planeArray[i, j] = Instantiate(planePrefab, new Vector3(i * 2.5f * gapValue, 0.1f, j * 2.5f * gapValue), planePrefab.transform.rotation);
                TextMeshProUGUI textObj = Instantiate(birdText, new Vector3(i * 2.5f * gapValue, 0.15f, j * 2.5f * gapValue), birdText.transform.rotation);
                textObj.transform.SetParent(canvasPrefab.transform);
                birdText.text = RandomBirds();
            }
        }
    }
    private void AddToDictionary()
    {
        dicObject.Add(0, "Sparrow");
        dicObject.Add(1, "Crow");
        dicObject.Add(2, "Pigeon");
        dicObject.Add(3, "Peacock");
        dicObject.Add(4, "Parrot");
        dicObject.Add(5, "Dove");
        dicObject.Add(6, "Owl");
        dicObject.Add(7, "Kingfisher");
        dicObject.Add(8, "Kite");
        dicObject.Add(9, "Eagle");
        dicObject.Add(10, "Ostrich");
    }
    private string RandomBirds()
    {
        var randomKey = Random.Range(0, dicObject.Count);
        return dicObject[randomKey].ToString();
    }
}
