using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DxLibDLL;

public class car_prot : MonoBehaviour
{
    DX.DINPUT_JOYSTATE input;

    public List<AxleInfo> axleInfos; // 個々の車軸の情報
    public float maxMotorTorque; //ホイールに適用可能な最大トルク
    public float maxSteeringAngle; // 適用可能な最大ハンドル角度

    public Vector3 center = new Vector3(0f, 0f, 0f);

    Rigidbody rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.centerOfMass = this.transform.localPosition;
    }

    public void Update()
    {
        DX.GetJoypadDirectInputState(DX.DX_INPUT_PAD1, out input);

        //float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float motor = maxMotorTorque * -(input.Y / 1000.0f);
        //float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        float steering = maxSteeringAngle * (input.X /1000.0f);
        Debug.DrawLine(transform.position, transform.position + transform.rotation * center);

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position + transform.rotation * center, 0.1f);
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; //このホイールがエンジンにアタッチされているかどうか
    public bool steering; // このホイールがハンドルの角度を反映しているかどうか
}
