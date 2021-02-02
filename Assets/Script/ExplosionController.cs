using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
   public GameObject particle = null;
   public GameObject audiosource = null;
    // Start is called before the first frame update
    void Start()
    {
        
        //audiosource = GameObject.Find("Audio");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void EffectPlay(Vector3 pos)
    {
        this.transform.position = pos;
        particle.GetComponent<ParticleSystem>().Play();
        audiosource.GetComponent<AudioSource>().Play();
    }
}
