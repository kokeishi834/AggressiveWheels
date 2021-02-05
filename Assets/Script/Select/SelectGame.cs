using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HandleC;
using UnityEngine.UI;

public class SelectGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] buttons;

    bool handle_trigger = false;

    int select_game = 0;

    HC HANDLE_INPUT = new HC();

    public string next_scene;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        HANDLE_INPUT.UpdateJoyPad(0);

        if (!handle_trigger)
        {
            if (HANDLE_INPUT.LimitHandle(0) > 0.5f)
            {
                select_game = (select_game + 1) % buttons.Length;
                handle_trigger = true;
            }
            else if (HANDLE_INPUT.LimitHandle(0) < -0.5f)
            {
                select_game = (select_game - 1) % buttons.Length;
                if (select_game < 0)
                {
                    select_game = 1;
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

        buttons[select_game].GetComponent<Button>().Select();

        if (HANDLE_INPUT.Button(HC.Buttons.A, 0) ||
           HANDLE_INPUT.Button(HC.Buttons.B, 0) ||
           HANDLE_INPUT.Button(HC.Buttons.C, 0) ||
           HANDLE_INPUT.Button(HC.Buttons.X, 0) ||
           HANDLE_INPUT.Button(HC.Buttons.Y, 0) ||
           HANDLE_INPUT.Button(HC.Buttons.Z, 0))
        {
            PlayerPrefs.SetInt("GameMode", select_game);
            SceneManager.LoadScene(next_scene);
        }

    }
}
