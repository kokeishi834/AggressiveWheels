using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using HandleC;
using UnityEngine.UI;

public class CarSecond : MonoBehaviourPunCallbacks
{
    public int player_num;
    public Vector3 Gravity;
    int gun_num = -1;
    public GameObject[] gun;

    Rigidbody rb;

    float speed;
    float energy;
    float handle;

    float direction;

    HC HANDLE_INPUT = new HC();

    public float max_speed = 100.0f;
    public float accelerator = 0.5f;
    public float max_rotate = 4.0f;
    public float max_energy = 1.0f;

    public Animator animator;
    public GameObject car_model;

    //仮設置移行予定
    public int player_hp = 0;
    int max_hp;//初期体力を入れておく変数

    GameObject speed_meter = null;
    GameObject energy_meter = null;
    GameObject speed_num = null;

    Vector3 last_velocity;

    bool drift;

    // Start is called before the first frame update
    void Start()
    {
        //PhotonNetwork.Instantiate(this.name,this.transform.position,this.transform.rotation);
        rb = this.GetComponent<Rigidbody>();
        //rb.useGravity = false;
        speed = 0.0f;
        direction = 1.0f;
        energy = max_energy;

        speed_meter = GameObject.Find("speed");
        energy_meter = GameObject.Find("energy");
        speed_num = GameObject.Find("numspeed");

        rb.centerOfMass = new Vector3(0.0f, -1.0f, 0.0f);

        //仮設置移行予定
        max_hp = player_hp;
        drift = false;
    }

    // Update is called once per frame
    void Update()
    {
        HANDLE_INPUT.UpdateJoyPad(player_num);

        //if (!this.GetComponent<PhotonView>().IsMine)
        //{
        //    return;
        //}
        //ハンドル制御
        {
            last_velocity = rb.velocity;
            if (speed >= 0.0f)
            {
                handle = HANDLE_INPUT.LimitHandle(player_num);
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
                handle = -HANDLE_INPUT.LimitHandle(player_num);
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
            animator.SetFloat("turn", handle * 10);

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
        }

        //アクセル&ブレーキの処理
        {
            if (Input.GetKey(KeyCode.UpArrow) || HANDLE_INPUT.Pedal(HC.Pedals.accelerator,player_num) > 0.1f)
            {
                if ((HANDLE_INPUT.Button(HC.Buttons.A,player_num) ||
                   HANDLE_INPUT.Button(HC.Buttons.B, player_num) ||
                   HANDLE_INPUT.Button(HC.Buttons.C, player_num) ||
                   Input.GetKey(KeyCode.W))
                   && energy >= 0.0f)
                {
                    if (speed <= max_speed * 1.3f)
                    {
                        speed += accelerator * 2.0f;
                        if (speed >= max_speed * 1.3f)
                        {
                            speed = max_speed * 1.3f;
                        }
                    }
                    energy -= 0.1f;
                }
                else if (speed >= max_speed * HANDLE_INPUT.Pedal(HC.Pedals.accelerator, player_num))
                {
                    speed -= 0.5f;
                    if (speed <= max_speed * HANDLE_INPUT.Pedal(HC.Pedals.accelerator, player_num) + 0.5f)
                        speed = max_speed * HANDLE_INPUT.Pedal(HC.Pedals.accelerator, player_num);
                }
                else
                {
                    speed += accelerator;
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow) || HANDLE_INPUT.Pedal(HC.Pedals.brake, player_num) > 0.1f)
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

            speed_meter.GetComponent<Image>().fillAmount = (float)(speed / max_speed);
            speed_num.GetComponent<Text>().text = ((int)speed).ToString();
            rb.velocity = new Vector3(transform.forward.x * speed, rb.velocity.y, transform.forward.z * speed);
        }

        if (Input.GetKey(KeyCode.P))
        {
            energy += 0.1f;
            if (energy >= max_energy)
            {
                energy = max_energy;
            }
        }
        energy_meter.GetComponent<Image>().fillAmount = (float)(energy / max_energy);


        //仮設置移行予定

        //hpが0になったらポイント半減（変える部分）
        if (player_hp <= 0)
        {
            this.GetComponent<PointController>().DeathPoint();
            player_hp = max_hp;
        }

        //rb.AddForce(Gravity, ForceMode.Acceleration);
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

    public void PlayerDamage(int damage, GameObject owner)
    {
        if (owner.gameObject.tag == "Enemy")
        {
            //体力減少
            player_hp -= damage;
        }
    }

    public void SetGun(int num)
    {
        gun_num = num;

        GameObject.Instantiate(gun[gun_num]);//, transform.GetChild(1).gameObject.transform);

        //gun[gun_num].transform.parent = transform.GetChild(1).gameObject.transform;

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * new Vector3(0.0f, -1.0f, 0.0f), 0.1f);
    }
}