using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberText : MonoBehaviour
{
    public GameObject NumberPad;
    public GameObject Play;
    public int row;
    public int col;
    public int value;



    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().text = Play.GetComponent<Play>().playGrid[NumberPad.GetComponent<NumberPad>().row, NumberPad.GetComponent<NumberPad>().col].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = Play.GetComponent<Play>().playGrid[NumberPad.GetComponent<NumberPad>().row, NumberPad.GetComponent<NumberPad>().col].ToString();

        if (NumberPad.GetComponent<NumberPad>().onShow == true)
        {
            
            this.GetComponent<Text>().color = new Color(251f / 255, 248f / 255, 239f / 255);

        }
        else
        {
            this.GetComponent<Text>().color = Color.clear;
        }

        //row = NumberPad.GetComponent<NumberPad>().row;
        //col = NumberPad.GetComponent<NumberPad>().col;
        //value = Play.GetComponent<Play>().newGrid[row, col];
    }
}
