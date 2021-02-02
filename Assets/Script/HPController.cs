using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPController : MonoBehaviour
{
    GameObject HP;
    GameObject HPlost;
    GameObject HPtext;
    // Start is called before the first frame update
    void Start()
    {
        HP = GameObject.Find("HP");
        HPlost = GameObject.Find("HP_lost");
        HPtext = GameObject.Find("HP_text");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Damage(0.1f);
        }
        //HPが0の時にそれ以上減らないようにして復活する
        if(HP.GetComponent<Image>().fillAmount < 0)
        {
            HP.GetComponent<Image>().fillAmount = 1.0f;
        }
        
        //ゲージの色を黄色に変更
        if(HP.GetComponent<Image>().fillAmount < 0.5f && 
            HP.GetComponent<Image>().fillAmount >= 0.2f)
        {
            GetComponent<Image>().color = new Color(1.0f, 1.0f, 0, 1);
        }
        //ゲージの色を赤色に変更
        if (HP.GetComponent<Image>().fillAmount < 0.2f)
        {
            GetComponent<Image>().color = new Color(1.0f, 0, 0, 1);
        }


    }
    //減少疑似エフェクトとHPの減少を行う関数
    public void Damage(float damage)
    {
        HPlost.GetComponent<HPlostController>().Lost();
        HP.GetComponent<Image>().fillAmount -= damage;   
    }
}
