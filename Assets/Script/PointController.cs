using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointController : MonoBehaviour
{
    public int now_point = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ポイントを加算する関数
    public void PlusPoint(int point)
    {
        now_point += point;
        
    }
    
    //死亡時ポイントを半減する関数
    public void DeathPoint()
    {
        now_point = now_point / 2;
    }   
    
    //ポイントを渡す関数
    public int GetPoint()
    {
        return now_point;
    } 
}
