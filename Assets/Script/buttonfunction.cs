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
    int player_num;
    public List<GameObject> buttons;
    bool handle_trigger = false;
    bool button_trigger = false;

    int select_button = 0;

    HC HANDLE_INPUT = new HC();

    int game_mode = 0;
    void Start()
    {
        game_mode = PlayerPrefs.GetInt("GameMode");

        Debug.Log("GAME_MODE" + game_mode);
    }

    // Update is called once per frame
    void Update()
    {
        HANDLE_INPUT.UpdateJoyPad(0);

        if (button_trigger)
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


        buttons[select_button].GetComponent<Button>().Select();

        if (!handle_trigger)
        {
            if (HANDLE_INPUT.LimitHandle(0) > 0.5f)
            {
                select_button = (select_button + 1) % buttons.Count;
                handle_trigger = true;
            }
            else if (HANDLE_INPUT.LimitHandle(0) < -0.5f)
            {
                select_button = (select_button - 1) % buttons.Count;
                if (select_button < 0)
                {
                    select_button = buttons.Count - 1 ;
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


        if (!button_trigger)
        {
            if (HANDLE_INPUT.Button(HC.Buttons.A, 0) ||
               HANDLE_INPUT.Button(HC.Buttons.B, 0) ||
               HANDLE_INPUT.Button(HC.Buttons.C, 0) ||
               HANDLE_INPUT.Button(HC.Buttons.X, 0) ||
               HANDLE_INPUT.Button(HC.Buttons.Y, 0) ||
               HANDLE_INPUT.Button(HC.Buttons.Z, 0))
            {
                switch(select_button)
                {
                    case 0:
                        StringArgFunction("MakeStage1");
                        break;

                    case 1:
                        StringArgFunction("MakeStage2");
                        break;

                    case 2:
                        StringArgFunction("MakeStage3");
                        break;

                    case 3:
                        SceneManager.LoadScene("SelectScene");
                        break;
                }
                button_trigger = true;
            }
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
        if(game_mode == 0)
        {
            var gameManager = GameObject.FindWithTag("GamePlayManager").GetComponent<GamePlayManager>();
            // データを渡す処理
            gameManager.SetPlayerInfo(car_num, parts_num, player_num);
        }
        if (game_mode == 1)
        {
            var gameManager = GameObject.FindWithTag("GamePlayManager").GetComponent<GamePlayManager>();
            // データを渡す処理
            gameManager.SetPlayerInfo(car_num, parts_num, player_num);
        }

        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }

    public void SetCustomNum(int car,int parts,int p_num)
    {
        car_num = car;
        parts_num = parts;
        player_num = p_num;
    }
}
