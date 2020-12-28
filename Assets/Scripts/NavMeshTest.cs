using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTest : MonoBehaviour
{
    public NavMeshAgent agent;       //探索を行うオブジェクト   
    public GameObject[] target;      //目的地
    public float range = 0;          //到達判定の範囲
    public int goal = 0;             //目的地の番号
    public float agent_range = 0.5f; //プレイヤーの半径
    // Start is called before the first frame update
    void Start()
    {
        //目的地を設定してあげる
        agent.SetDestination(target[goal].transform.position);
    }

    // Update is called once per frame
    void Update()
    { 
        //目的地付近に到達したら次に向かう
        float dis_x = transform.position.x - target[goal].transform.position.x;
        float dis_z = transform.position.z - target[goal].transform.position.z;

        //Debug.Log(Mathf.Sqrt(dis_x * dis_x + dis_z * dis_z));
        if (agent_range + range >= Mathf.Sqrt(dis_x * dis_x + dis_z* dis_z))
        {
            Debug.Log(target.Length);
            {
                if (goal != target.Length - 1)
                {
                    goal++;    
                }
                else
                {
                    goal = 0;
                }
                //目的地を設定してあげる
                agent.SetDestination(target[goal].transform.position);
            }
        }
    }
}
