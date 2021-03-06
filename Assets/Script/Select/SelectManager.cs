﻿using System.Collections;
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

    HC HANDLE_INPUT = new HC();

    bool handle_trigger = false;
    bool button_trigger = false;
    int select_car = 0;
    int select_parts = 0;

    public string to_scene;

    public int player_num = 0;

    public GameObject preview;
    // Start is called before the first frame update
    void Start()
    {
        //一番左にフォーカスさせる
        EventSystem.current.SetSelectedGameObject(car_list[0]);
        select_car = 0;
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
        HANDLE_INPUT.UpdateJoyPad(0);

        if(button_trigger)
        {
            if (!HANDLE_INPUT.Button(HC.Buttons.A, 0) &&
               !HANDLE_INPUT.Button(HC.Buttons.B, 0) &&
               !HANDLE_INPUT.Button(HC.Buttons.C, 0) &&
               !HANDLE_INPUT.Button(HC.Buttons.X, 0) &&
               !HANDLE_INPUT.Button(HC.Buttons.Y, 0) &&
               !HANDLE_INPUT.Button(HC.Buttons.Z, 0))
            {
                button_trigger = false;
            }
        }
        if (back_button.activeSelf == false)
        {
            if (!handle_trigger)
            {
                if (HANDLE_INPUT.LimitHandle(0) > 0.5f)
                {
                    select_car = (select_car + 1) % car_list.Count;
                    handle_trigger = true;
                }
                else if (HANDLE_INPUT.LimitHandle(0) < -0.5f)
                {
                    select_car = (select_car - 1) % car_list.Count;
                    if (select_car < 0)
                    {
                        select_car = 2;
                    }
                    handle_trigger = true;
                }
            }
            else
            {
                if (HANDLE_INPUT.LimitHandle(0) < 0.3f &&
                  HANDLE_INPUT.LimitHandle(0) > -0.3f)
                {
                    handle_trigger = false;
                }
            }

            preview.GetComponent<PreviewObject>().set_car(select_car);
            car_list[select_car].GetComponent<Button>().Select();

            if(!button_trigger)
            {
                if (HANDLE_INPUT.Button(HC.Buttons.A, 0) ||
                   HANDLE_INPUT.Button(HC.Buttons.B, 0) ||
                   HANDLE_INPUT.Button(HC.Buttons.C, 0) ||
                   HANDLE_INPUT.Button(HC.Buttons.X, 0) ||
                   HANDLE_INPUT.Button(HC.Buttons.Y, 0) ||
                   HANDLE_INPUT.Button(HC.Buttons.Z, 0))
                {
                    car_list[select_car].GetComponent<CarButtonController>().Click();
                    button_trigger = true;
                }
            }
        }
        else
        {
            if (!handle_trigger)
            {
                if (HANDLE_INPUT.LimitHandle(0) > 0.5f)
                {
                    select_parts = (select_parts + 1) % (parts_list.Count + 1);
                    handle_trigger = true;
                }
                else if (HANDLE_INPUT.LimitHandle(0) < -0.5f)
                {
                    select_parts = (select_parts - 1) % (parts_list.Count + 1);
                    if (select_parts < 0)
                    {
                        select_parts = 3;
                    }
                    handle_trigger = true;
                }
            }
            else
            {
                if (HANDLE_INPUT.LimitHandle(0) < 0.3f &&
                  HANDLE_INPUT.LimitHandle(0) > -0.3f)
                {
                    handle_trigger = false;
                }
            }

            if(select_parts != 3)
            {
                parts_list[select_parts].GetComponent<Button>().Select();
            }
            else
            {
                back_button.GetComponent<Button>().Select();
            }
            preview.GetComponent<PreviewObject>().set_gun(select_parts);
            Debug.Log(select_parts);

            if (!button_trigger)
            {
                if (HANDLE_INPUT.Button(HC.Buttons.A, 0) ||
                   HANDLE_INPUT.Button(HC.Buttons.B, 0) ||
                   HANDLE_INPUT.Button(HC.Buttons.C, 0) ||
                   HANDLE_INPUT.Button(HC.Buttons.X, 0) ||
                   HANDLE_INPUT.Button(HC.Buttons.Y, 0) ||
                   HANDLE_INPUT.Button(HC.Buttons.Z, 0))
                {
                    if (select_parts != 3)
                    {
                        parts_list[select_parts].GetComponent<PartsButtonController>().Click();
                    }
                    else
                    {
                        back_button.GetComponent<BackButtonController>().Click();
                    }
                    button_trigger = true;
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
        select_parts = 0;
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
        select_car = 0;

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
