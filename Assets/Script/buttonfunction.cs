using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HandleC;
using UnityEngine.SceneManagement;
public class buttonfunction : MonoBehaviour
{
    // Start is called before the first frame update
    int car_num;
    int parts_num;

    HC HANDLE_INPUT = new HC();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HANDLE_INPUT.UpdateJoyPad(0);
        if (HANDLE_INPUT.Button(HC.Buttons.A, 0))
        {
            //stage_list[0].GetComponent<Button>().Select();
            StringArgFunction("MakeStage1");
        }
        if (HANDLE_INPUT.Button(HC.Buttons.B, 0))
        {
            //car_list[1].GetComponent<Button>().Select();
            StringArgFunction("MakeStage2");
        }
        if (HANDLE_INPUT.Button(HC.Buttons.C, 0))
        {
            //car_list[2].GetComponent<Button>().Select();
            StringArgFunction("MakeStage3");
        }
    }

    public void StringArgFunction(string s)
    {
        SceneManager.sceneLoaded += GameSceneLoaded;

        SceneManager.LoadScene(s);
    }

    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {

        // シーン切り替え後のスクリプトを取得
        var gameManager = GameObject.FindWithTag("GamePlayManager").GetComponent<GamePlayManager>();

        // データを渡す処理
        gameManager.SetPlayerInfo(car_num, parts_num);

        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }

    public void SetCustomNum(int car,int parts)
    {
        car_num = car;
        parts_num = parts;
    }
}
