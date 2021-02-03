using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HandleC;

public class TitleController : MonoBehaviour
{
    // Start is called before the first frame update
    HC[] HANDLE_INPUT = {new HC(),new HC()};

    int use_display_num = 2;

    private void Awake()
    {
        int display_num = Mathf.Min(Display.displays.Length, use_display_num);
        for (int i = 0; i < display_num; i++)
        {
            Display.displays[i].Activate();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i < 2;i++)
        {
            HANDLE_INPUT[i].UpdateJoyPad(i);

            if (Input.GetKeyDown(KeyCode.Space) ||
               HANDLE_INPUT[i].Button(HC.Buttons.A, i) ||
               HANDLE_INPUT[i].Button(HC.Buttons.B, i) ||
               HANDLE_INPUT[i].Button(HC.Buttons.C, i) ||
               HANDLE_INPUT[i].Button(HC.Buttons.X, i) ||
               HANDLE_INPUT[i].Button(HC.Buttons.Y, i) ||
               HANDLE_INPUT[i].Button(HC.Buttons.Z, i)
               )
            {
                SceneManager.LoadScene("SelectScene");
            }
        }
    }
}
