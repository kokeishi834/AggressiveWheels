using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsButtonController : MonoBehaviour
{
    public int obj_num = 0;//オブジェクトの管理番号
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
        manager.GetComponent<SelectManager>().GetPartsNum(obj_num);
    }
}
