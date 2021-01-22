using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingObject : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time++;

        this.gameObject.GetComponent<Text>().color = new Color(1.0f,1.0f,1.0f, Mathf.Cos(time/20));
    }
}
