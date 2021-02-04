using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
    public List<GameObject> cars;
    public List<GameObject> shooters;
    public List<GameObject> guns;

    int now_gun = -1;
    int now_car = -1;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject obj in cars)
        {
            obj.SetActive(false);
        }
        foreach(GameObject obj in cars)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, -1.0f, 0.0f);

        foreach (GameObject obj in cars)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in guns)
        {
            obj.SetActive(false);
        }

        if (now_car != -1)
            cars[now_car].SetActive(true);

        if (now_gun != -1)
        {
            guns[now_gun].SetActive(true);
            guns[now_gun].transform.position = shooters[now_car].transform.position;
        }
    }

    public void set_car(int num_car)
    {
        now_car = num_car;
    }
    public void set_gun(int num_gun)
    {
        now_gun = num_gun;
    }
}
