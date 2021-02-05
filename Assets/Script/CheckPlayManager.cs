using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckPlayManager : MonoBehaviour
{
    int count;
    public int check_num = 0;//一人用で一時的に使う
    public GameObject[] obj = null;
    public GameObject[] check_obj = null;
    [SerializeField] GameObject goal = null;
    public GameObject arrival_pos;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        
        for (int i = 0; i < check_num; i++)
        {
            if (i == 0)
            {
                check_obj[i].SetActive(true);
            }
            else
            {
                check_obj[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //SelectSceneからプレイヤーとパーツの選択情報をintで貰う関数
    public void SetPlayerInfo(int car_num, int parts_num)
    {
        GameObject.Instantiate(obj[car_num], arrival_pos.transform.position,
            Quaternion.identity);
        obj[car_num].GetComponent<CarSecond>().SetGun(parts_num);
    }

    //一人用専用関数、後に変更
    public void Pass_Check()
    {
        count++;
        //次のチェックポイントを起動
        if (check_num > count)
        {
            check_obj[count].SetActive(true);
        }

        if (count >= check_num)//チェックポイントを通過したらゴールを出現させる,30fps
        {
            goal.SetActive(true);
            goal.GetComponent<GoalController>().SetCount(count);
        }
    }
}
