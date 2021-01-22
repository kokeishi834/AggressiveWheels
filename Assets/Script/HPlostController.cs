using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPlostController : MonoBehaviour
{
    GameObject HP;
    GameObject HPlost;
    float alpha;
    bool damage_flag;
    // Start is called before the first frame update
    void Start()
    {
        HP = GameObject.Find("HP");
        HPlost = GameObject.Find("HP_lost");
        alpha = 1.0f;
        damage_flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (damage_flag == true)
        {
            //透明にしていく
            alpha -= 0.05f;
            //緑色のとき
            if(HPlost.GetComponent<Image>().fillAmount > 0.5f)
            {
                GetComponent<Image>().color = new Color(0, 1.0f, 0, alpha);
            }
            //黄色のとき
            if (HPlost.GetComponent<Image>().fillAmount < 0.5f &&
                 HPlost.GetComponent<Image>().fillAmount >= 0.2f)
            {
                GetComponent<Image>().color = new Color(1.0f, 1.0f, 0, alpha);
            }
            //赤色のとき
            if (HPlost.GetComponent<Image>().fillAmount < 0.2f)
            {
                GetComponent<Image>().color = new Color(1.0f, 0, 0, alpha);
            }
            if(alpha < 0)
            {
                alpha = 1.0f;
                damage_flag = false;
            }
        }
    }
    //減る前のゲージをもらう
    public void Lost()
    {
        HPlost.GetComponent<Image>().fillAmount = HP.GetComponent<Image>().fillAmount;
        damage_flag = true;
    }
}
