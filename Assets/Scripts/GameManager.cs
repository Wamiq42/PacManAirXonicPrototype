using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int rows;
    public int columns;
    public CellGrids cellGrid;
    public GameObject boxPrefab;
    public PlayerController playerController;
    public Text percentageText;
    public Text timeText;
    public bool gameState = false;
    public GameObject resetButton;

    //private float doubleRows;
    //private float halfRows;
    private float time;
    private float percentage;
    private float totalIndexes;
    private float totalWalkedCells;
    private float horizontalSpacing = 2.0f;
    private float verticalSpacing = 2.0f;
    private int counter = 0;
    private string percentageString;

    private void Awake()
    {
        InitializeCellGrid();
        counter -= rows;
        totalIndexes = rows * columns;
        playerController.counterAdd += AddCounter;
    }

    private void Update()
    {
        if (gameState == false)
        {
            time += Time.deltaTime;
            float minutes = Mathf.Floor(time / 60);
            float seconds = Mathf.RoundToInt(time % 60);
            timeText.text = minutes.ToString() + " : " + seconds.ToString();
           
        }
        else if(gameState)
        {
            resetButton.SetActive(true);
        }

        totalWalkedCells = counter;
        
        percentage = (totalWalkedCells / totalIndexes) * 100;

        if (percentage > 50)
        {
            gameState = true;
        }

        percentageString = "Percentage : " + percentage;

        percentageText.text = percentageString;


    }

    void AddCounter(int count)
    {
        counter += count;
    }
    void InitializeCellGrid()
    {
        cellGrid = new CellGrids(rows, columns);
        cellGrid.cellCreated += CellInstantiate;
        cellGrid.InitializeCell();
        
    }

    private void CellInstantiate(Cell cell)
    {
        GameObject temp;
        CellPositionSetUp();
        temp = Instantiate(boxPrefab,new Vector3(horizontalSpacing,0,verticalSpacing),boxPrefab.transform.rotation);
        counter++;
        temp.GetComponent<UnityCell>().setCell(cell);
        temp.GetComponent<UnityCell>().getCell().nextStatus += temp.GetComponent<UnityCell>().SettingUpStatus;
        

    }

    void CellPositionSetUp()
    {
        if (counter == rows)
        {
            verticalSpacing -= 2.0f;
            counter=0;
            horizontalSpacing = 0f;
        }
        else
        {
            horizontalSpacing -= 2.0f;
        }   
    }

    //public List<GameObject> GetGameObjects()
    //{
    //    return gameObjects;
    //}
}
