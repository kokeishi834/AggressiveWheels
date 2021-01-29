using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using HandleC;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    public List<GameObject> car_list;
    public List<GameObject> parts_list;
    public GameObject back_button = null;
    public GameObject select_text = null;
    int car_num = -1;
    int parts_num = -1;

    HC[] HANDLE_INPUT = {new HC(), new HC()};

    public string to_scene;

    // Start is called before the first frame update
    void Start()
    {
        //一番左にフォーカスさせる
        EventSystem.current.SetSelectedGameObject(car_list[0]);
        //パーツの選択ボタンを非表示にする
        for (int i = 0; i < parts_list.Count;i++)
        {
            parts_list[i].SetActive(false);
        }
        //戻るボタンを非表示にする
        back_button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            HANDLE_INPUT[i].UpdateJoyPad(i);

            if(back_button.activeSelf == false)
            {
                if(HANDLE_INPUT[i].Button(HC.Buttons.A,i))
                {
                    car_list[0].GetComponent<Button>().Select();
                    car_list[0].GetComponent<CarButtonController>().Click();
                }
                if (HANDLE_INPUT[i].Button(HC.Buttons.B, i))
                {
                    car_list[1].GetComponent<Button>().Select();
                    car_list[1].GetComponent<CarButtonController>().Click();
                }
                if (HANDLE_INPUT[i].Button(HC.Buttons.C, i))
                {
                    car_list[2].GetComponent<Button>().Select();
                    car_list[2].GetComponent<CarButtonController>().Click();
                }
            }
            else
            {
                if (HANDLE_INPUT[i].Button(HC.Buttons.X, i))
                {
                    parts_list[0].GetComponent<Button>().Select();
                    parts_list[0].GetComponent<PartsButtonController>().Click();
                }
                if (HANDLE_INPUT[i].Button(HC.Buttons.Y, i))
                {
                    parts_list[1].GetComponent<Button>().Select();
                    parts_list[1].GetComponent<PartsButtonController>().Click();
                }
                if (HANDLE_INPUT[i].Button(HC.Buttons.Z, i))
                {
                    parts_list[2].GetComponent<Button>().Select();
                    parts_list[2].GetComponent<PartsButtonController>().Click();
                }
                if (HANDLE_INPUT[i].Button(HC.Buttons.A, i))
                {
                    back_button.GetComponent<Button>().Select();
                    back_button.GetComponent<BackButtonController>().Click();
                }
            }
        }
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
        //一番左ににフォーカスさせる
        EventSystem.current.SetSelectedGameObject(parts_list[0]);
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
        SceneManager.LoadScene(to_scene);
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
        //一番左にフォーカスさせる
        EventSystem.current.SetSelectedGameObject(car_list[0]);

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
        var gameManager = GameObject.FindWithTag("SelectManager").GetComponent<buttonfunction>();
        
        // データを渡す処理
        gameManager.SetCustomNum(car_num,parts_num);

        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
