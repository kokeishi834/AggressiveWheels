using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePlayManager : MonoBehaviour
{
    public int goal_appearance = 0;//ゴール出現までの時間
    //public List<GameObject> myList;
    int count;
    int kill_enemy_num;//一人用で一時的に使う
    public int enemy_num = 0;//一人用で一時的に使う
    public GameObject[] obj = null;
    //Canvas prefab;
    //public GameObject text;
    //GameObject Canvas;
    [SerializeField] GameObject goal = null;

    public GameObject arrival_pos;
     // Start is called before the first frame update
    void Start()
    { 
        count = 0;
        kill_enemy_num = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        count++;

        if(Input.GetKeyDown(KeyCode.G))
        {
            goal.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            KillEnemy();
        }
        //if(/*count >= goal_appearance * 30*/ kill_enemy_num >= enemy_num)//指定の時間が経過したらゴールを出現させる,30fps
        //{
        //    goal.SetActive(true);
        //}

        //for (int i= 0; i < myList.Count; i++)
        //{
        //    int player_point = myList[i].GetComponent<PointController>().GetPoint();
        //    //int をstringに変換する
        //    string score = player_point.ToString();

        //    // テキストの変更
        //    //Canvas.GetComponent<PointDisplay>().SetObject("Player", player_point);
        //}
    }

    //SelectSceneからプレイヤーとパーツの選択情報をintで貰う関数
    public void SetPlayerInfo(int car_num, int parts_num)
    {
        GameObject.Instantiate(obj[car_num], arrival_pos.transform.position, Quaternion.identity);
        obj[car_num].GetComponent<CarSecond>().SetGun(parts_num);
        //Debug.Log("c" + car_num);
        //Debug.Log("p" + parts_num);
        
    }


    //一人用専用関数、後に変更
    public void KillEnemy()
    {
        kill_enemy_num++;
        if (/*count >= goal_appearance * 30*/ kill_enemy_num >= enemy_num)//指定の時間が経過したらゴールを出現させる,30fps
        {
            goal.SetActive(true);
            goal.GetComponent<GoalController>().SetCount(count);
        }
    }
}
