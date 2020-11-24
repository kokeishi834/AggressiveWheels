using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        GameObject manager = GameObject.Find("SelectManager");
        manager.GetComponent<SelectManager>().PushBackButton();
    }
}
