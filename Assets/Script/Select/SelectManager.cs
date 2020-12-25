using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectManager : MonoBehaviour
{
    public List<GameObject> car_list;
    public List<GameObject> parts_list;
    public GameObject back_button = null;
    public GameObject select_text = null;
    int car_num = -1;
    int parts_num = -1;
    // Start is called before the first frame update
    void Start()
    {
        //パーツの選択ボタンを非表示にする
        for(int i = 0; i < parts_list.Count;i++)
        {
            parts_list[i].SetActive(false);
        }
        //戻るボタンを非表示にする
        back_button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCarNum(int num)
    {
        car_num = num;
        //Debug.Log("cs" + car_num);

        //パーツの選択ボタンを出現させる
        for (int i = 0; i < parts_list.Count; i++)
        {
            parts_list[i].SetActive(true);
        }

        //戻るボタンを出現させる
        back_button.SetActive(true);

        //クルマの選択ボタンを非表示にする
        for (int i = 0; i < car_list.Count; i++)
        {
            car_list[i].SetActive(false);
        }
        //テキストを移動
        select_text.GetComponent<SelectTextController>().SetPartsText();
    }

    public void GetPartsNum(int num)
    {
        parts_num = num;
        //Debug.Log("ps" + parts_num);


        //パーツの選択がされたらゲームシーンへ移行
        // イベントに登録
        SceneManager.sceneLoaded += GameSceneLoaded;

        //SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("test");
    }

    //戻るボタンが押された時の処理
    public void PushBackButton()
    {
        //パーツの選択ボタンを非表示にする
        for (int i = 0; i < parts_list.Count; i++)
        {
            parts_list[i].SetActive(false);
        }

        //クルマの選択ボタンを出現させる
        for (int i = 0; i < car_list.Count; i++)
        {
            car_list[i].SetActive(true);
        }

        //戻るボタンを非表示にする
        back_button.SetActive(false);

        //クルマの情報をリセットする
        car_num = -1;

        //テキストを移動
        select_text.GetComponent<SelectTextController>().SetCarText();
    }

    //シーン遷移時にポイントを渡す関数（要調整）
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {

        // シーン切り替え後のスクリプトを取得
        var gameManager = GameObject.FindWithTag("GamePlayManager").GetComponent<GamePlayManager>();
        
        // データを渡す処理
        gameManager.SetPlayerInfo(car_num,parts_num);

        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
