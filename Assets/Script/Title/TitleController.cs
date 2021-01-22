using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using HandleC;

public class TitleController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    HC[] HANDLE_INPUT = {new HC(),new HC()};

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
