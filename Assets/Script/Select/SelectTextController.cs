using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectTextController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text select_text = gameObject.GetComponent<Text>();
        // テキストの表示を入れ替える
        select_text.text = "クルマを選択してください";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPartsText()
    {
        //gameObject.transform.position -= new Vector3(0, 300, 0);

        Text select_text = gameObject.GetComponent<Text>();
        // テキストの表示を入れ替える
        select_text.text = "パーツを選択してください";

    }

    public void SetCarText()
    {
        //gameObject.transform.position += new Vector3(0, 300, 0);
        Text select_text = gameObject.GetComponent<Text>();
        // テキストの表示を入れ替える
        select_text.text = "クルマを選択してください";
    }
}
