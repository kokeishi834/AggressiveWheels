using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemygene : MonoBehaviour
{
    GameObject[] enemise;
    int[] time;

    // Start is called before the first frame update
    void Start()
    {
        enemise = GameObject.FindGameObjectsWithTag ("Enemy");
        time = new int[enemise.Length];
        Debug.Log("timesize = " + time.Length);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("enemise = " + enemise.Length);
        for(int i = 0;i < enemise.Length;i++)
        {
            if (enemise[i].activeSelf == false)
            {
                time[i]++;
                if(time[i] > 30)
                {
                    time[i] = 0;
                    enemise[i].GetComponent<EnemyController>().initialize();
                };
            }
        }
    }
}
