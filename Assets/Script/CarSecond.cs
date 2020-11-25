using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using HandleC;

public class CarSecond : MonoBehaviourPunCallbacks
{
    public Vector3 Gravity;
    int gun_num = -1;
    public GameObject[] gun;

    Rigidbody rb;

    float speed;
    float handle;

    float direction;

    public float max_speed = 100.0f;
    public float accelerator = 0.5f;
    public float max_rotate = 4.0f;

    public Animator animator;
    public GameObject car_model;

    HC HANDLE_INPUT = new HC();


    //仮設置移行予定
    public int player_hp = 0;
    int max_hp;//初期体力を入れておく変数


    // Start is called before the first frame update
    void Start()
    {
        //PhotonNetwork.Instantiate(this.name,this.transform.position,this.transform.rotation);
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
        speed = 0.0f;
        direction = 1.0f;
       

        //仮設置移行予定
        max_hp = player_hp;

    }

    // Update is called once per frame
    void Update()
    {
        HANDLE_INPUT.UpdateJoyPad();

        if (this.GetComponent<PhotonView>().IsMine)
        {
        }

        // 前に移動
        if (Input.GetKey(KeyCode.UpArrow) || HANDLE_INPUT.Pedal(HC.Pedals.accelerator) > 0.1f)
        {
            if (speed >= max_speed * HANDLE_INPUT.Pedal(HC.Pedals.accelerator))
            {
                speed -= 0.5f;
                if (speed <= max_speed * HANDLE_INPUT.Pedal(HC.Pedals.accelerator) + 0.5f)
                    speed = max_speed * HANDLE_INPUT.Pedal(HC.Pedals.accelerator);
            }
            else
            {
                speed += 0.5f;
            }
            if (HANDLE_INPUT.Button(HC.Buttons.A) || Input.GetKey(KeyCode.W))
            {
                speed = max_speed * 2;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) || HANDLE_INPUT.Pedal(HC.Pedals.brake) > 0.1f)
        {
            speed -= 2.0f;
            if (speed <= -25.0f)
            {
                speed = -25.0f;
            }
        }
        else
        {
            if (speed > 0.0f)
            {
                speed -= 1.0f;
            }
            else if (speed < 0.0f)
            {
                speed += 1.0f;
            }

            if (speed <= 0.5f && speed >= -0.5f)
            {
                speed = 0.0f;
            }
        }

        if (speed >= 0.0f)
        {
            handle = HANDLE_INPUT.LimitHandle();
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                handle = -0.5f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                handle = 0.5f;
            }
            direction = 1.0f;
        }
        else if (speed < -0.1f)
        {
            handle = -HANDLE_INPUT.LimitHandle();
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                handle = 0.5f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                handle = -0.5f;
            }
            direction = -1.0f;
        }

        transform.Rotate(new Vector3(0.0f, handle * max_rotate, 0.0f));
        car_model.transform.localRotation = Quaternion.Euler(0, 0, handle * (-30.0f * direction));
        if (handle != 0.0f)
        {
            float handle_N;
            if (handle < 0.0f)
            {
                handle_N = -handle;
            }
            else
            {
                handle_N = handle;
            }
            car_model.transform.localPosition = new Vector3(0.0f, handle_N * 0.3f, 0.0f);
        }
        rb.velocity = new Vector3(transform.forward.x * speed, rb.velocity.y, transform.forward.z * speed);


        animator.SetFloat("turn", handle * 10);
        //Debug.Log(car_model.transform.localPosition.y);

        //rb.velocity = transform.forward * speed;
        //Debug.Log(input.Rz);
        //Debug.Log(Mathf.Sin(transform.rotation.y));


        //Debug.Log(handle);

        //仮設置移行予定

        //hpが0になったらポイント半減（変える部分）
        if (player_hp <= 0)
        {
            this.GetComponent<PointController>().DeathPoint();
            player_hp = max_hp;
        }

        rb.AddForce(Gravity, ForceMode.Acceleration);
    }


    //仮設置移行予定
    //エネミーと当たった時
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //体力減少
            player_hp -= 20;
            //爆発エフェクトの呼び出し
            GameObject burst_spark = GameObject.Find("eff_burst_spark");
            burst_spark.GetComponent<ExplosionController>().EffectPlay(this.transform.position);
        }
    }

    public void SetGun(int num)
    {
        gun_num = num;

        GameObject.Instantiate(gun[gun_num]);//, transform.GetChild(1).gameObject.transform);
        
        //gun[gun_num].transform.parent = transform.GetChild(1).gameObject.transform;
        
    }
}
