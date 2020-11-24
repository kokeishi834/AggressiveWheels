using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEffectController : MonoBehaviour
{
    
    Time time;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //上下させる部分（跳ねる感じを出したver）
        float sin = Mathf.Sin(Time.time);
        this.transform.position = new Vector3(transform.position.x,
            sin * 10 + 10, transform.position.z);
    }
}
