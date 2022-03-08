using System.Collections.Generic;
using UnityEngine;
public class CellGrids : Matrices
{

    List<List<Cell>> cell2dList;


    public delegate void CellCreated(Cell cell); //initialized
    public CellCreated cellCreated; //declaration

   

    public CellGrids(int rows, int columns) : base(rows, columns)
    {
        cell2dList = new List<List<Cell>>();

    }

    public void InitializeCell()
    {
        for (int i = 0; i < rows; i++)
        {
            cell2dList.Add(new List<Cell>());
            for (int j = 0; j < columns; j++)
            {
                Cell tempCell = new Cell(i, j);
                cell2dList[i].Add(tempCell);
                cellCreated?.Invoke(cell2dList[i][j]);   //invoke
                if(i==0 || i== rows-1 || j == 0 || j == columns-1)
                {
                    setElementsInMatrix(i, j, (int)Cell.Status.redColor);
                    cell2dList[i][j].SetStatus(Cell.Status.redColor);
                    //Debug.Log("Red");
                }
                else
                {
                    setElementsInMatrix(i, j, (int)Cell.Status.none);
                    //Debug.Log("white");
                }

                tempCell.positionRandC += setStatusWithPosition;
                //cell2dList[i][j].SetStatus(Cell.Status.none);

            }
        }
        //printMatrix();
    }

    public void setStatusWithPosition(int rows, int column)
    {

        // CheckDraw();
        setElementsInMatrix(rows, column, (int)Cell.Status.redColor);
        cell2dList[rows][column].SetStatus(Cell.Status.redColor);
       // Debug.Log(cell2dList[rows][column].GetStatus());

    }

    //public void CheckWin()
    //{

    //    for (int i = 0; i < rows; i++)
    //    {
    //        rowSame = IsRowSame(i);
    //        if (rowSame == true)
    //        {
    //            checkWin = true;
    //            setRow(i, (int)Cell.Status.tick);
    //            onMatrixUpdate();
    //            break;
    //        }
    //        else
    //        {
    //            checkWin = false;
    //        }
    //    }
    //    if (!checkWin)
    //    {
    //        for (int i = 0; i < columns; i++)
    //        {
    //            columnSame = IsColumnSame(i);
    //            if (columnSame)
    //            {
    //                checkWin = true;
    //                setColumn(i, (int)Cell.Status.tick);
    //                onMatrixUpdate();
    //                break;
    //            }
    //            else
    //            {
    //                checkWin = false;
    //            }
    //        }
    //    }

    //    diagnolSame = CheckDiagnolMatrix();
    //    if (diagnolSame)
    //    {
    //        checkWin = true;
    //        setDiagnolMatrix((int)Cell.Status.tick);
    //        onMatrixUpdate();
    //    }
    //    else
    //        checkWin = false;

    //}

    //public void CheckDraw()
    //{
    //    CheckingMatrix();
    //    if (!checkMatrixValue)
    //    {
    //        Debug.Log("Game is not completed to confirm draw");
    //    }
    //    else
    //    {
    //        Debug.Log("Draw");
    //        matchDraw = true;
    //    }

    //}
    //public void CheckingMatrix()
    //{
    //    for (int i = 0; i < rows; i++)
    //    {
    //        for (int j = 0; j < columns; j++)
    //        {
    //            if (matrix[i][j] == 0)
    //            {
    //                checkMatrixValue = false;
    //                break;
    //            }
    //            else
    //                checkMatrixValue = true;
    //        }
    //    }
    //}


    public void onMatrixUpdate()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                cell2dList[i][j].SetStatus((Cell.Status)getElementInMatrix(i, j));
            }
        }
    }


}
