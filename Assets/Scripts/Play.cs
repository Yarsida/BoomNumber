using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Play : MonoBehaviour
{
    public int[,] playGrid = new int[5, 5];
    public int startGrid = 0;
    public int[,] newGrid = new int[5, 5];
    public int[,] mergeGrid = new int[7, 7];
    public int[,] genGrid = new int[5, 5];
    public int[,] valueGrid = new int[7, 7];
    public int[,] valurgenGrid = new int[7, 7];
    public int[,] valueplayGrid = new int[7, 7];
    public int[,] valuegenGrid = new int[7, 7];

    // Start is called before the first frame update
    void Start()
    {
        #region 生成初始数字
        while (startGrid < 2)
        {
            int m = Random.Range(0, 5);
            int n = Random.Range(0, 5);
            if (playGrid[m, n] == 0)
            {

                playGrid[m, n] = 2;
                mergeGrid[m + 1, n + 1] = 1;
                valueGrid[m + 1, n + 1] = 2;
                startGrid++;
                //Debug.Log(m);
                //Debug.Log(n);
            }
        }
        startGrid = 0;

        #endregion
        #region 检验数组
        //Debug.Log(numListToString(playGrid));
        ////把每一个数取出来转化为字符串
        //string numListToString(int[,] list)
        //{
        //    string str = "";
        //    foreach (int n in list)
        //        str += n + " ";

        //    return str;
        //}
        //Debug.Log(playGrid.ToString());
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i =0; i < 5; i++)
        //{
        //    for (int j = 0; j < 5; i++)
        //    {

        //    }
        //}
    }


}
