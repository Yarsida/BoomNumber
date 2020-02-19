using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NumberPad : MonoBehaviour, IPointerClickHandler
{
    public bool onShow = false;
    public float value = 0f;
    public GameObject Play;
    public int row;
    public int col;
    public Animation numberPad;
    public bool phaseA = false;
    public bool phaseB = false;
    public bool phaseC = false;
    public bool phaseD = false;


    // Start is called before the first frame update
    void Start()
    {


    }

    void afterMerge()
    {
        for (int i = 1; i < 6; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                Play.GetComponent<Play>().playGrid[i - 1, j - 1] = Play.GetComponent<Play>().valueGrid[i, j];
                if (Play.GetComponent<Play>().genGrid[i - 1, j - 1] == 1)
                {
                    int x = Random.Range(1, 3);

                    Play.GetComponent<Play>().playGrid[i - 1, j - 1] = x;
                }




            }
        }
    }


    void mergeIntoOne()
    {
        for (int i = 1; i < 6; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                if (Play.GetComponent<Play>().newGrid[i - 1, j - 1] == 0)
                {
                    //Play.GetComponent<Play>().valueGrid[i, j] = 0;
                }
            }
        }
        for (int i = 1; i < 6; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                if (Play.GetComponent<Play>().newGrid[i - 1, j - 1] == 1)
                {
                    int a = Play.GetComponent<Play>().valueGrid[i + 1, j];
                    int b = Play.GetComponent<Play>().valueGrid[i - 1, j];
                    int c = Play.GetComponent<Play>().valueGrid[i, j + 1];
                    int d = Play.GetComponent<Play>().valueGrid[i, j - 1];

                    Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i, j] + a + b + c + d;

                    if (Play.GetComponent<Play>().mergeGrid[i + 1, j] < 15)
                    {
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i - 1, j] < 15)
                    {
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j + 1] < 15)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j - 1] < 15)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                    }

                }

            }
        }
        for (int i = 1; i < 6; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                if (Play.GetComponent<Play>().mergeGrid[i, j] == 15)
                {
                    phaseA = true;
                }
                if (Play.GetComponent<Play>().mergeGrid[i, j] == 35)
                {
                    phaseB = true;
                }
                if (Play.GetComponent<Play>().mergeGrid[i, j] == 63)
                {
                    phaseC = true;
                }
                if (Play.GetComponent<Play>().mergeGrid[i, j] == 27)
                {
                    phaseD = true;
                }
            }
        }
        if (phaseA == true && phaseB == false && phaseD == false)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 15)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 1, j] + Play.GetComponent<Play>().valueGrid[i, j + 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = 0;
                        Play.GetComponent<Play>().mergeGrid[i, j] = 6;
                    }
                }
            }
        }
        if (phaseB == true && phaseA == false && phaseC == false)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 35)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 1, j] + Play.GetComponent<Play>().valueGrid[i, j - 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                        Play.GetComponent<Play>().mergeGrid[i, j] = 6;
                    }
                }
            }
        }
        if (phaseC == true && phaseB == false && phaseD == false)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 63)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 1, j] + Play.GetComponent<Play>().valueGrid[i, j - 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                        Play.GetComponent<Play>().mergeGrid[i, j] = 6;
                    }
                }
            }
        }
        if (phaseD == true && phaseC == false && phaseA == false)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 27)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 1, j] + Play.GetComponent<Play>().valueGrid[i, j + 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = 0;
                        Play.GetComponent<Play>().mergeGrid[i, j] = 6;
                    }
                }
            }
        }
        if (phaseA == true && phaseB == true && phaseC == false && phaseD == false)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 15)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 1, j] + Play.GetComponent<Play>().valueGrid[i, j + 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 35)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 1, j] + Play.GetComponent<Play>().valueGrid[i, j - 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = Play.GetComponent<Play>().valueGrid[i, j] + Play.GetComponent<Play>().valueGrid[i, j - 2];
                        Play.GetComponent<Play>().valueGrid[i, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 2] = 0;

                        Play.GetComponent<Play>().mergeGrid[i, j - 1] = 6;
                    }
                }
            }
        }
        if (phaseB == true && phaseC == true && phaseD == false && phaseA == false)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 35)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 1, j] + Play.GetComponent<Play>().valueGrid[i, j - 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 63)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 1, j] + Play.GetComponent<Play>().valueGrid[i, j - 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = Play.GetComponent<Play>().valueGrid[i, j] + Play.GetComponent<Play>().valueGrid[i + 2, j];
                        Play.GetComponent<Play>().valueGrid[i, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i + 2, j] = 0;
                        Play.GetComponent<Play>().mergeGrid[i + 1, j] = 6;
                    }
                }
            }
        }
        if (phaseC == true && phaseD == true && phaseA == false && phaseB == false)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 63)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 1, j] + Play.GetComponent<Play>().valueGrid[i, j - 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 27)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 1, j] + Play.GetComponent<Play>().valueGrid[i, j + 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = Play.GetComponent<Play>().valueGrid[i, j] + Play.GetComponent<Play>().valueGrid[i, j + 2];
                        Play.GetComponent<Play>().valueGrid[i, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 2] = 0;
                        Play.GetComponent<Play>().mergeGrid[i, j + 1] = 6;
                    }
                }
            }
        }
        if (phaseD == true && phaseA == true && phaseB == false && phaseC == false)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 27)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 1, j] + Play.GetComponent<Play>().valueGrid[i, j + 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 15)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 1, j] + Play.GetComponent<Play>().valueGrid[i, j + 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = 0;
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = Play.GetComponent<Play>().valueGrid[i, j] + Play.GetComponent<Play>().valueGrid[i - 2, j];
                        Play.GetComponent<Play>().valueGrid[i, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i - 2, j] = 0;
                        Play.GetComponent<Play>().mergeGrid[i - 1, j] = 6;
                    }
                }
            }
        }
        if (phaseA == true && phaseB == true && phaseC == true && phaseD == false)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 15)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 1, j] + Play.GetComponent<Play>().valueGrid[i, j + 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 63)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 1, j] + Play.GetComponent<Play>().valueGrid[i, j - 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 35)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 1, j] + Play.GetComponent<Play>().valueGrid[i, j - 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 2, j] + Play.GetComponent<Play>().valueGrid[i, j - 2] + Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 2, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 2] = 0;
                        Play.GetComponent<Play>().mergeGrid[i, j] = 6;
                    }
                }
            }
        }
        if (phaseD == true && phaseB == true && phaseC == true && phaseA == false)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 35)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 1, j] + Play.GetComponent<Play>().valueGrid[i, j - 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 27)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 1, j] + Play.GetComponent<Play>().valueGrid[i, j + 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 63)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 1, j] + Play.GetComponent<Play>().valueGrid[i, j - 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 2, j] + Play.GetComponent<Play>().valueGrid[i, j - 2] + Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 2, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 2] = 0;
                        Play.GetComponent<Play>().mergeGrid[i, j] = 6;
                    }
                }
            }
        }
        if (phaseA == true && phaseD == true && phaseC == true && phaseB == false)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 15)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 1, j] + Play.GetComponent<Play>().valueGrid[i, j + 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 63)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 1, j] + Play.GetComponent<Play>().valueGrid[i, j - 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 27)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 1, j] + Play.GetComponent<Play>().valueGrid[i, j + 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 2, j] + Play.GetComponent<Play>().valueGrid[i, j + 2] + Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 2, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 2] = 0;

                        Play.GetComponent<Play>().mergeGrid[i, j] = 6;
                    }
                }
            }
        }
        if (phaseA == true && phaseB == true && phaseD == true && phaseB == false)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 35)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 1, j] + Play.GetComponent<Play>().valueGrid[i, j - 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 27)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 1, j] + Play.GetComponent<Play>().valueGrid[i, j + 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 15)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 1, j] + Play.GetComponent<Play>().valueGrid[i, j + 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 2, j] + Play.GetComponent<Play>().valueGrid[i, j + 2] + Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 2, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 2] = 0;
                        Play.GetComponent<Play>().mergeGrid[i, j] = 6;
                    }
                }
            }
        }
        if (phaseA == true && phaseB == true && phaseC == true && phaseD == true)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 15)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 1, j] + Play.GetComponent<Play>().valueGrid[i, j + 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 35)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 1, j] + Play.GetComponent<Play>().valueGrid[i, j - 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i - 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 63)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 1, j] + Play.GetComponent<Play>().valueGrid[i, j - 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j - 1] = 0;
                    }
                    if (Play.GetComponent<Play>().mergeGrid[i, j] == 27)
                    {
                        Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 1, j] + Play.GetComponent<Play>().valueGrid[i, j + 1] - Play.GetComponent<Play>().valueGrid[i, j];
                        Play.GetComponent<Play>().valueGrid[i + 1, j] = 0;
                        Play.GetComponent<Play>().valueGrid[i, j + 1] = 0;
                    }
                }
            }
            int k = Random.Range(0, 4);
            if (k == 0)
            {
                for (int i = 1; i < 6; i++)
                {
                    for (int j = 1; j < 6; j++)
                    {
                        if (Play.GetComponent<Play>().mergeGrid[i, j] == 15)
                        {
                            Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 2, j] + Play.GetComponent<Play>().valueGrid[i, j + 2] + Play.GetComponent<Play>().valueGrid[i - 2, j + 2] + Play.GetComponent<Play>().valueGrid[i, j];
                            Play.GetComponent<Play>().valueGrid[i - 2, j] = 0;
                            Play.GetComponent<Play>().valueGrid[i, j + 2] = 0;
                            Play.GetComponent<Play>().valueGrid[i - 2, j + 2] = 0;

                            Play.GetComponent<Play>().mergeGrid[i, j] = 6;
                        }
                    }
                }
            }
            else if (k == 1)
            {
                for (int i = 1; i < 6; i++)
                {
                    for (int j = 1; j < 6; j++)
                    {
                        if (Play.GetComponent<Play>().mergeGrid[i, j] == 35)
                        {
                            Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i - 2, j] + Play.GetComponent<Play>().valueGrid[i, j - 2] + Play.GetComponent<Play>().valueGrid[i - 2, j - 2] + Play.GetComponent<Play>().valueGrid[i, j];
                            Play.GetComponent<Play>().valueGrid[i - 2, j] = 0;
                            Play.GetComponent<Play>().valueGrid[i, j - 2] = 0;
                            Play.GetComponent<Play>().valueGrid[i - 2, j - 2] = 0;

                            Play.GetComponent<Play>().mergeGrid[i, j] = 6;
                        }
                    }
                }
            }
            else if (k == 2)
            {
                for (int i = 1; i < 6; i++)
                {
                    for (int j = 1; j < 6; j++)
                    {
                        if (Play.GetComponent<Play>().mergeGrid[i, j] == 63)
                        {
                            Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 2, j] + Play.GetComponent<Play>().valueGrid[i, j - 2] + Play.GetComponent<Play>().valueGrid[i + 2, j - 2] + Play.GetComponent<Play>().valueGrid[i, j];
                            Play.GetComponent<Play>().valueGrid[i + 2, j] = 0;
                            Play.GetComponent<Play>().valueGrid[i, j - 2] = 0;
                            Play.GetComponent<Play>().valueGrid[i + 2, j - 2] = 0;
                            Play.GetComponent<Play>().mergeGrid[i, j] = 6;
                        }
                    }
                }
            }
            else if (k == 3)
            {
                for (int i = 1; i < 6; i++)
                {
                    for (int j = 1; j < 6; j++)
                    {
                        if (Play.GetComponent<Play>().mergeGrid[i, j] == 27)
                        {
                            Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().valueGrid[i + 2, j] + Play.GetComponent<Play>().valueGrid[i, j + 2] + Play.GetComponent<Play>().valueGrid[i + 2, j + 2] + Play.GetComponent<Play>().valueGrid[i, j];
                            Play.GetComponent<Play>().valueGrid[i + 2, j] = 0;
                            Play.GetComponent<Play>().valueGrid[i, j + 2] = 0;
                            Play.GetComponent<Play>().valueGrid[i + 2, j + 2] = 0;
                            Play.GetComponent<Play>().mergeGrid[i, j] = 6;
                        }
                    }
                }
            }
        }
    }


     //CapsulecastCommand
    


    void merge()
    {
        for (int i = 1; i < 6; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                if (Play.GetComponent<Play>().newGrid[i - 1, j - 1] == 1)
                {
                    if (Play.GetComponent<Play>().valueGrid[i, j - 1] > 0)
                    {
                        Play.GetComponent<Play>().mergeGrid[i, j - 1] = Play.GetComponent<Play>().mergeGrid[i, j - 1] * Play.GetComponent<Play>().mergeGrid[i, j] * Mathf.Min(1, 1 + Play.GetComponent<Play>().valueplayGrid[i, j - 1]) * Mathf.Abs(1 - Play.GetComponent<Play>().valuegenGrid[i, j - 1]);
                    }
                    if (Play.GetComponent<Play>().valueGrid[i, j + 1] > 0)
                    {
                        Play.GetComponent<Play>().mergeGrid[i, j + 1] = Play.GetComponent<Play>().mergeGrid[i, j + 1] * Play.GetComponent<Play>().mergeGrid[i, j] * Mathf.Min(1, 1 + Play.GetComponent<Play>().valueplayGrid[i, j + 1]) * Mathf.Abs(1 - Play.GetComponent<Play>().valuegenGrid[i, j + 1]);
                    }
                    if (Play.GetComponent<Play>().valueGrid[i - 1, j] > 0)
                    {
                        Play.GetComponent<Play>().mergeGrid[i - 1, j] = Play.GetComponent<Play>().mergeGrid[i - 1, j] * Play.GetComponent<Play>().mergeGrid[i, j] * Mathf.Min(1, 1 + Play.GetComponent<Play>().valueplayGrid[i - 1, j]) * Mathf.Abs(1 - Play.GetComponent<Play>().valuegenGrid[i - 1, j]);
                    }
                    if (Play.GetComponent<Play>().valueGrid[i + 1, j] > 0)
                    {
                        Play.GetComponent<Play>().mergeGrid[i + 1, j] = Play.GetComponent<Play>().mergeGrid[i + 1, j] * Play.GetComponent<Play>().mergeGrid[i, j] * Mathf.Min(1, 1 + Play.GetComponent<Play>().valueplayGrid[i + 1, j]) * Mathf.Abs(1 - Play.GetComponent<Play>().valuegenGrid[i + 1, j]);
                    }

                }
            }
        }

        for (int i = 1; i < 6; i++)
        {
            for (int j = 1; j < 6; j++)
            {

                Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().playGrid[i - 1, j - 1];

                if (Play.GetComponent<Play>().genGrid[i - 1, j - 1] == 1)
                {
                    Play.GetComponent<Play>().mergeGrid[i, j] = 0;
                    Play.GetComponent<Play>().valueGrid[i, j] = 0;
                }
                if (Play.GetComponent<Play>().newGrid[i - 1, j - 1] == 2)
                {
                    Play.GetComponent<Play>().mergeGrid[i, j] = 0;
                    Play.GetComponent<Play>().valueGrid[i, j] = 0;
                    Debug.Log("a");
                }

            }
        }

        mergeIntoOne();
        afterMerge();


    }

    // Update is called once per frame
    void Update()
    {
        int end = 0;
        #region 结束游戏
        for (int i = 1; i < 6; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                if (Play.GetComponent<Play>().playGrid[i - 1, j - 1] > 0)
                {
                    end = end + 1;
                }
            }
        }
        if (end > 21)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }

        #endregion





        #region 配色
        if (Play.GetComponent<Play>().playGrid[row, col] == 0)
        {
            this.onShow = false;
            this.GetComponent<Image>().color = Color.clear;
            
        }
        else
        {
            this.onShow = true;
            if (Play.GetComponent<Play>().mergeGrid[row + 1, col + 1] == 1)
            {
                this.GetComponent<Image>().color = new Color(242f / 255, 177f / 255, 121f / 255);
            }




            if (Play.GetComponent<Play>().newGrid[row, col] == 1)
            {
                this.GetComponent<Image>().color = new Color(80f / 255, 197f / 255, 195f / 255);               
            }
            else if (Play.GetComponent<Play>().genGrid[row, col] != 0)
            {
                this.GetComponent<Image>().color = new Color(170f / 255, 159f / 255, 47f / 255);
            }
            else
            {
                this.GetComponent<Image>().color = new Color(63f / 255, 136f / 255, 135f / 255);
            }
            if (Play.GetComponent<Play>().mergeGrid[row + 1, col + 1] == 6)
            {
                this.GetComponent<Image>().color = new Color(80f / 255, 197f / 255, 195f / 255);
            }

        }
        #endregion

        #region 边界矩阵归零
        for (int i = 0; i < 7; i++)
        {
            Play.GetComponent<Play>().valueGrid[i, 0] = 0;
            Play.GetComponent<Play>().valurgenGrid[i, 0] = 0;
            Play.GetComponent<Play>().valueGrid[i, 6] = 0;
            Play.GetComponent<Play>().valurgenGrid[i, 6] = 0;
            Play.GetComponent<Play>().valueplayGrid[i, 0] = 0;
            Play.GetComponent<Play>().valueplayGrid[i, 6] = 0;
            Play.GetComponent<Play>().valuegenGrid[i, 0] = 0;
            Play.GetComponent<Play>().valuegenGrid[i, 6] = 0;


        }
        for (int i = 0; i < 7; i++)
        {
            Play.GetComponent<Play>().valueGrid[0, i] = 0;
            Play.GetComponent<Play>().valurgenGrid[0, i] = 0;
            Play.GetComponent<Play>().valueGrid[6, i] = 0;
            Play.GetComponent<Play>().valurgenGrid[6, i] = 0;
            Play.GetComponent<Play>().valueplayGrid[0, i] = 0;
            Play.GetComponent<Play>().valueplayGrid[6, i] = 0;
            Play.GetComponent<Play>().valuegenGrid[0, i] = 0;
            Play.GetComponent<Play>().valuegenGrid[6, i] = 0;
        }
        #endregion

        for (int i = 1; i < 6; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                Play.GetComponent<Play>().valueplayGrid[i, j] = Play.GetComponent<Play>().playGrid[i - 1, j - 1];
                Play.GetComponent<Play>().valueGrid[i, j] = Play.GetComponent<Play>().playGrid[i - 1, j - 1];
                Play.GetComponent<Play>().valuegenGrid[i, j] = Play.GetComponent<Play>().genGrid[i - 1, j - 1];
            }
        }



    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        //Debug.Log(name + " Game Object Clicked!");

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Play.GetComponent<Play>().newGrid[i, j] = 0;
                Play.GetComponent<Play>().genGrid[i, j] = 0;

            }
        }

        if (this.onShow == true && Play.GetComponent<Play>().playGrid[row, col] > 1)
        {
            if (row == 0)
            {
                if (col == 0)
                {
                    if (Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] == 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = {k1, k2};
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row + 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col + 1] = v2;
                        Play.GetComponent<Play>().newGrid[row + 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col + 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {
                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                }
                else if (col == 4)
                {
                    if (Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row + 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col - 1] = v2;
                        Play.GetComponent<Play>().newGrid[row + 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col - 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;

                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                }
                else
                {
                    if (Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row + 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col - 1] = v2;
                        Play.GetComponent<Play>().newGrid[row + 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col - 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;
                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row + 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col + 1] = v2;
                        Play.GetComponent<Play>().newGrid[row + 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col + 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row + 1, col] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row, col + 1] = v1;
                        Play.GetComponent<Play>().playGrid[row, col - 1] = v2;
                        Play.GetComponent<Play>().newGrid[row, col + 1] = 1;
                        Play.GetComponent<Play>().newGrid[row, col - 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row + 1, col] == 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Random.Range(0, Play.GetComponent<Play>().playGrid[row, col] - k1 + 1);
                        int k3;
                        if (Play.GetComponent<Play>().playGrid[row,col] - k1 - k2 >0)
                        {
                            k3 = Play.GetComponent<Play>().playGrid[row, col] - k1 - k2;
                        }
                        else
                        {
                            k3 = 0;
                        }
                        int r = Random.Range(0, 3);
                        int p = Random.Range(0, 2);
                        int[] v = { k1, k2, k3};
                        if (r == 0)
                        {
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p + 1];
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[2 - p];
                        }
                        else if (r == 1)
                        {
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p * 2];
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[2 - 2 * p];
                        }
                        else
                        {
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p];
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[1 - p];
                        }
                        Play.GetComponent<Play>().newGrid[row, col + 1] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row, col + 1]);
                        Play.GetComponent<Play>().newGrid[row, col - 1] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row, col - 1]);
                        Play.GetComponent<Play>().newGrid[row + 1, col] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row + 1, col]);
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                Play.GetComponent<Play>().playGrid[m, n] = 2;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else
                    {

                    }
                }
            }
            else if (row == 4)
            {
                if (col == 0)
                {
                    if (Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] == 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row - 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col + 1] = v2;
                        Play.GetComponent<Play>().newGrid[row - 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col + 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row - 1 + 1, col + 1] = 9;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                }
                else if (col == 4)
                {
                    if (Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row - 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col - 1] = v2;
                        Play.GetComponent<Play>().newGrid[row - 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col - 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row - 1 + 1, col + 1] = 9;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                }
                else
                {
                    if (Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row - 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col - 1] = v2;
                        Play.GetComponent<Play>().newGrid[row - 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col - 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row - 1 + 1, col + 1] = 9;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row - 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col + 1] = v2;
                        Play.GetComponent<Play>().newGrid[row - 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col + 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row - 1 + 1, col + 1] = 9;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row - 1, col] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row, col + 1] = v1;
                        Play.GetComponent<Play>().playGrid[row, col - 1] = v2;
                        Play.GetComponent<Play>().newGrid[row, col + 1] = 1;
                        Play.GetComponent<Play>().newGrid[row, col - 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row - 1, col] == 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Random.Range(0, Play.GetComponent<Play>().playGrid[row, col] - k1 + 1);
                        int k3;
                        if (Play.GetComponent<Play>().playGrid[row, col] - k1 - k2 > 0)
                        {
                            k3 = Play.GetComponent<Play>().playGrid[row, col] - k1 - k2;
                        }
                        else
                        {
                            k3 = 0;
                        }
                        int r = Random.Range(0, 3);
                        int p = Random.Range(0, 2);
                        int[] v = { k1, k2, k3 };
                        if (r == 0)
                        {
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p + 1];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[2 - p];
                        }
                        else if (r == 1)
                        {
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p * 2];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[2 - 2 * p];
                        }
                        else
                        {
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[1 - p];
                        }
                        Play.GetComponent<Play>().newGrid[row, col + 1] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row, col + 1]);
                        Play.GetComponent<Play>().newGrid[row, col - 1] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row, col - 1]);
                        Play.GetComponent<Play>().newGrid[row - 1, col] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row - 1, col]);
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;
                        Play.GetComponent<Play>().mergeGrid[row + 1 - 1, col + 1] = 9;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                }
            }
            else
            {
                if (col == 0)
                {
                    if (Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row - 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row + 1, col] = v2;
                        Play.GetComponent<Play>().newGrid[row - 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row + 1, col] = 1;
                        Play.GetComponent<Play>().mergeGrid[row - 1 + 1, col + 1] = 9;
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row + 1, col] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row - 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col + 1] = v2;
                        Play.GetComponent<Play>().newGrid[row - 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col + 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row - 1 + 1, col + 1] = 9;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row - 1, col] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row, col + 1] = v1;
                        Play.GetComponent<Play>().playGrid[row + 1, col] = v2;
                        Play.GetComponent<Play>().newGrid[row, col + 1] = v1;
                        Play.GetComponent<Play>().newGrid[row + 1, col] = v2;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row - 1, col] == 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Random.Range(0, Play.GetComponent<Play>().playGrid[row, col] - k1 + 1);
                        int k3;
                        if (Play.GetComponent<Play>().playGrid[row, col] - k1 - k2 > 0)
                        {
                            k3 = Play.GetComponent<Play>().playGrid[row, col] - k1 - k2;
                        }
                        else
                        {
                            k3 = 0;
                        }
                        int r = Random.Range(0, 3);
                        int p = Random.Range(0, 2);
                        int[] v = { k1, k2, k3 };
                        if (r == 0)
                        {
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[r];
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[p + 1];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[2 - p];
                        }
                        else if (r == 1)
                        {
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[r];
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[p * 2];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[2 - 2 * p];
                        }
                        else
                        {
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[r];
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[p];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[1 - p];
                        }

                        Play.GetComponent<Play>().newGrid[row, col + 1] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row, col + 1]);
                        Play.GetComponent<Play>().newGrid[row + 1, col] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row + 1, col]);
                        Play.GetComponent<Play>().newGrid[row - 1, col] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row - 1, col]);
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;
                        Play.GetComponent<Play>().mergeGrid[row + 1 - 1, col + 1] = 9;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                }
                else if (col == 4)
                {
                    if (Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row + 1, col] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row - 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col - 1] = v2;
                        Play.GetComponent<Play>().newGrid[row - 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col - 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row + 1 - 1, col + 1] = 9;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row - 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row + 1, col] = v2;
                        Play.GetComponent<Play>().newGrid[row - 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row + 1, col] = 1;
                        Play.GetComponent<Play>().mergeGrid[row + 1 - 1, col + 1] = 9;
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row - 1, col] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row + 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col - 1] = v2;
                        Play.GetComponent<Play>().newGrid[row + 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col - 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row - 1, col] == 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Random.Range(0, Play.GetComponent<Play>().playGrid[row, col] - k1 + 1);
                        int k3;
                        if (Play.GetComponent<Play>().playGrid[row, col] - k1 - k2 > 0)
                        {
                            k3 = Play.GetComponent<Play>().playGrid[row, col] - k1 - k2;
                        }
                        else
                        {
                            k3 = 0;
                        }
                        int r = Random.Range(0, 3);
                        int p = Random.Range(0, 2);
                        int[] v = { k1, k2, k3 };
                        if (r == 0)
                        {
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p + 1];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[2 - p];
                        }
                        else if (r == 1)
                        {
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p * 2];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[2 - 2 * p];
                        }
                        else
                        {
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[1 - p];
                        }
                        Play.GetComponent<Play>().newGrid[row + 1, col] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row + 1, col]);
                        Play.GetComponent<Play>().newGrid[row, col - 1] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row, col - 1]);
                        Play.GetComponent<Play>().newGrid[row - 1, col] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row - 1, col]);
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;
                        Play.GetComponent<Play>().mergeGrid[row + 1 - 1, col + 1] = 9;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                }
                else
                {
                    if (Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row + 1, col] != 0 && Play.GetComponent<Play>().playGrid[row, col + 1] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row - 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col - 1] = v2;
                        Play.GetComponent<Play>().newGrid[row - 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col - 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row - 1 + 1, col + 1] = 9;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row - 1, col] != 0 && Play.GetComponent<Play>().playGrid[row, col + 1] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row + 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col - 1] = v2;
                        Play.GetComponent<Play>().newGrid[row + 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col - 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row + 1, col] != 0 && Play.GetComponent<Play>().playGrid[row, col - 1] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row - 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col + 1] = v2;
                        Play.GetComponent<Play>().newGrid[row - 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col + 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row - 1 + 1, col + 1] = 9;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row - 1, col] != 0 && Play.GetComponent<Play>().playGrid[row, col - 1] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row + 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row, col + 1] = v2;
                        Play.GetComponent<Play>().newGrid[row + 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row, col + 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] != 0 && Play.GetComponent<Play>().playGrid[row, col + 1] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row + 1, col] = v1;
                        Play.GetComponent<Play>().playGrid[row - 1, col] = v2;
                        Play.GetComponent<Play>().newGrid[row + 1, col] = 1;
                        Play.GetComponent<Play>().newGrid[row - 1, col] = 1;
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;
                        Play.GetComponent<Play>().mergeGrid[row - 1 + 1, col + 1] = 9;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row + 1, col] != 0 && Play.GetComponent<Play>().playGrid[row - 1, col] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Play.GetComponent<Play>().playGrid[row, col] - k1;
                        int r = Random.Range(0, 2);
                        int[] v = { k1, k2 };
                        int v1 = v[r];
                        int v2 = v[1 - r];
                        Play.GetComponent<Play>().playGrid[row, col - 1] = v1;
                        Play.GetComponent<Play>().playGrid[row, col + 1] = v2;
                        Play.GetComponent<Play>().newGrid[row, col - 1] = 1;
                        Play.GetComponent<Play>().newGrid[row, col + 1] = 1;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Random.Range(0, Play.GetComponent<Play>().playGrid[row, col] - k1 + 1);
                        int k3;
                        if (Play.GetComponent<Play>().playGrid[row, col] - k1 - k2 > 0)
                        {
                            k3 = Play.GetComponent<Play>().playGrid[row, col] - k1 - k2;
                        }
                        else
                        {
                            k3 = 0;
                        }
                        int r = Random.Range(0, 3);
                        int p = Random.Range(0, 2);
                        int[] v = { k1, k2, k3 };
                        if (r == 0)
                        {
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p + 1];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[2 - p];
                        }
                        else if (r == 1)
                        {
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p * 2];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[2 - 2 * p];
                        }
                        else
                        {
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[1 - p];
                        }
                        Play.GetComponent<Play>().newGrid[row + 1, col] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row + 1, col]);
                        Play.GetComponent<Play>().newGrid[row, col - 1] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row, col - 1]);
                        Play.GetComponent<Play>().newGrid[row - 1, col] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row - 1, col]);
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;
                        Play.GetComponent<Play>().mergeGrid[row - 1 + 1, col + 1] = 9;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row - 1, col] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Random.Range(0, Play.GetComponent<Play>().playGrid[row, col] - k1 + 1);
                        int k3;
                        if (Play.GetComponent<Play>().playGrid[row, col] - k1 - k2 > 0)
                        {
                            k3 = Play.GetComponent<Play>().playGrid[row, col] - k1 - k2;
                        }
                        else
                        {
                            k3 = 0;
                        }
                        int r = Random.Range(0, 3);
                        int p = Random.Range(0, 2);
                        int[] v = { k1, k2, k3 };
                        if (r == 0)
                        {
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p + 1];
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[2 - p];
                        }
                        else if (r == 1)
                        {
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p * 2];
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[2 - 2 * p];
                        }
                        else
                        {
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p];
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[1 - p];
                        }
                        Play.GetComponent<Play>().newGrid[row + 1, col] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row + 1, col]);
                        Play.GetComponent<Play>().newGrid[row, col - 1] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row, col - 1]);
                        Play.GetComponent<Play>().newGrid[row, col + 1] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row, col + 1]);
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0 && Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row + 1, col] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Random.Range(0, Play.GetComponent<Play>().playGrid[row, col] - k1 + 1);
                        int k3;
                        if (Play.GetComponent<Play>().playGrid[row, col] - k1 - k2 > 0)
                        {
                            k3 = Play.GetComponent<Play>().playGrid[row, col] - k1 - k2;
                        }
                        else
                        {
                            k3 = 0;
                        }
                        int r = Random.Range(0, 3);
                        int p = Random.Range(0, 2);
                        int[] v = { k1, k2, k3 };
                        if (r == 0)
                        {
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p + 1];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[2 - p];
                        }
                        else if (r == 1)
                        {
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p * 2];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[2 - 2 * p];
                        }
                        else
                        {
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col - 1] = v[p];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[1 - p];
                        }
                        Play.GetComponent<Play>().newGrid[row, col + 1] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row, col + 1]);
                        Play.GetComponent<Play>().newGrid[row, col - 1] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row, col - 1]);
                        Play.GetComponent<Play>().newGrid[row - 1, col] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row - 1, col]);
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;
                        Play.GetComponent<Play>().mergeGrid[row + 1 - 1, col + 1] = 9;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] != 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Random.Range(0, Play.GetComponent<Play>().playGrid[row, col] - k1 + 1);
                        int k3;
                        if (Play.GetComponent<Play>().playGrid[row, col] - k1 - k2 > 0)
                        {
                            k3 = Play.GetComponent<Play>().playGrid[row, col] - k1 - k2;
                        }
                        else
                        {
                            k3 = 0;
                        }
                        int r = Random.Range(0, 3);
                        int p = Random.Range(0, 2);
                        int[] v = { k1, k2, k3 };
                        if (r == 0)
                        {
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[p + 1];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[2 - p];
                        }
                        else if (r == 1)
                        {
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[p * 2];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[2 - 2 * p];
                        }
                        else
                        {
                            Play.GetComponent<Play>().playGrid[row + 1, col] = v[r];
                            Play.GetComponent<Play>().playGrid[row, col + 1] = v[p];
                            Play.GetComponent<Play>().playGrid[row - 1, col] = v[1 - p];
                        }
                        Play.GetComponent<Play>().newGrid[row + 1, col] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row + 1, col]);
                        Play.GetComponent<Play>().newGrid[row, col + 1] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row, col + 1]);
                        Play.GetComponent<Play>().newGrid[row - 1, col] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row - 1, col]);
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;
                        Play.GetComponent<Play>().mergeGrid[row + 1 - 1, col + 1] = 9;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        //待选;
                        merge();
                    }
                    else if (Play.GetComponent<Play>().playGrid[row + 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col + 1] == 0 && Play.GetComponent<Play>().playGrid[row - 1, col] == 0 && Play.GetComponent<Play>().playGrid[row, col - 1] == 0)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Play.GetComponent<Play>().newGrid[i, j] = 0;
                                Play.GetComponent<Play>().genGrid[i, j] = 0;
                                 
                            }
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                Play.GetComponent<Play>().mergeGrid[i, j] = 1;
                            }
                        }
                        int k1 = Random.Range(1, Play.GetComponent<Play>().playGrid[row, col]);
                        int k2 = Random.Range(0, Play.GetComponent<Play>().playGrid[row, col] - k1 + 1);
                        int k3;
                        int k4;
                        if (Play.GetComponent<Play>().playGrid[row, col] - k1 - k2 > 0)
                        {
                            k3 = Random.Range(0, Play.GetComponent<Play>().playGrid[row, col] - k1 -k2 + 1);
                            if (Play.GetComponent<Play>().playGrid[row, col] - k1 - k2 -k3 > 0)
                            {
                                k4 = Play.GetComponent<Play>().playGrid[row, col] - k1 - k2 - k3;
                            }
                            else
                            {
                                k4 = 0;
                            }
                        }
                        else
                        {
                            k3 = 0;
                            k4 = 0;
                        }
                        int r = Random.Range(0, 2);
                        int p = Random.Range(0, 2);
                        int[,] v = { { k1, k2 }, { k3, k4 } };
                        Play.GetComponent<Play>().playGrid[row + 1, col] = v[r, p];
                        Play.GetComponent<Play>().playGrid[row, col + 1] = v[r, 1-p];
                        Play.GetComponent<Play>().playGrid[row - 1, col] = v[1-r, p];
                        Play.GetComponent<Play>().playGrid[row, col - 1] = v[1-r, 1-p];
                        Play.GetComponent<Play>().newGrid[row + 1, col] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row + 1, col]);
                        Play.GetComponent<Play>().newGrid[row, col + 1] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row, col + 1]);
                        Play.GetComponent<Play>().newGrid[row - 1, col] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row - 1, col]);
                        Play.GetComponent<Play>().newGrid[row, col - 1] = Mathf.Min(1, Play.GetComponent<Play>().playGrid[row, col - 1]);
                        Play.GetComponent<Play>().mergeGrid[row + 1 + 1, col + 1] = 5;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col + 1 + 1] = 7;
                        Play.GetComponent<Play>().mergeGrid[row - 1 + 1, col + 1] = 9;
                        Play.GetComponent<Play>().mergeGrid[row + 1, col - 1 + 1] = 3;

                        //暂留待定
                        while (Play.GetComponent<Play>().startGrid < 2)
                        {
                            int m = Random.Range(0, 5);
                            int n = Random.Range(0, 5);
                            if (Play.GetComponent<Play>().playGrid[m, n] == 0)
                            {

                                int x = Random.Range(1, 3);
                                Play.GetComponent<Play>().playGrid[m, n] = x;
                                Play.GetComponent<Play>().genGrid[m, n] = 1;
                                Play.GetComponent<Play>().valuegenGrid[m + 1, n + 1] = 0;
                                Play.GetComponent<Play>().startGrid++;
                                Play.GetComponent<Play>().mergeGrid[m + 1, n + 1] = 4;
                                Play.GetComponent<Play>().newGrid[m, n] = 0;
                            }

                        }
                        Play.GetComponent<Play>().startGrid = 0;
                        Play.GetComponent<Play>().playGrid[row, col] = 0;
                        Play.GetComponent<Play>().newGrid[row, col] = 2;
                        
                        //待选;
                        merge();
                    }

                }
            }
                     

        }
        else
        {

        }
        


    }

}
