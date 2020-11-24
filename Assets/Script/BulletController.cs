using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    // bullet prefab
    public GameObject bullet;

    // 弾丸の速度
    public float speed = 10000;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector3 pos, Vector3 rotate,GameObject owner_gameobject,float bulletSpeed,int damage)
    {
        // 弾丸の複製
        GameObject bullets = Instantiate(bullet) as GameObject;
        //所有権が誰かを渡す
        bullets.GetComponent<CollisionController>().GetOwner(owner_gameobject,damage);

        // 弾丸の位置を調整
        bullets.transform.position = pos;
        bullets.transform.rotation = Quaternion.Euler(rotate.x, rotate.y, rotate.z);

        // Rigidbodyに力を加えて発射
        speed = bulletSpeed;
        bullets.GetComponent<Rigidbody>().AddForce(bullets.transform.forward * speed);  
    }

}