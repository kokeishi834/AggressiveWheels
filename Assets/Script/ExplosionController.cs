using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ExplosionController : MonoBehaviourPunCallbacks
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
