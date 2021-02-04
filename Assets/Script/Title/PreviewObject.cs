using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
    public List<GameObject> cars;
    public List<GameObject> shooters;
    public List<GameObject> guns;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, -1.0f, 0.0f);
    }
}
