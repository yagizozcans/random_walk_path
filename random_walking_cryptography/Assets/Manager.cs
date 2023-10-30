using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text matrixText;
    public lrCircle lrc;

    private void Start()
    {
        lrc.SetMatrix();
        SetMatrixText();
    }
    public void Update()
    {
        if(Input.GetKey(KeyCode.U))
        {
            SetMatrixText();
        }
    }
    public void SetMatrixText()
    {
        string arrs = "";
        for (int i = 1; i < (int)lrc.gridsize.x; i++)
        {
            arrs += "|";
            for (int j = 1; j < (int)lrc.gridsize.y; j++)
            {
                arrs += $" {lrc.matrix[j, i]} ";
            }
            arrs += "|\n";
        }
        arrs += $"Current total walk is -> {lrc.currentPathNumber}";
        matrixText.text = arrs;
    }
}
