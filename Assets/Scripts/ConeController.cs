using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeController : MonoBehaviour
{
    Time time;
    float pos_y;
    // Start is called before the first frame update
    void Start()
    {
        pos_y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //上下させる部分（跳ねる感じを出したver）
        float sin = Mathf.Sin(Time.time);

        this.transform.Rotate(0.0f, 1.0f, 0.0f);

        this.transform.position = new Vector3(transform.position.x,
            sin / 4 + pos_y, transform.position.z);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //ここにギミック発動の処理を入れる
        }
    }
}
