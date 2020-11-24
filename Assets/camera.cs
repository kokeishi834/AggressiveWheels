using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;

    private const float distance = 4.2f;
    //targetからの距離
    [SerializeField]private Vector3 viewpos;
    //targetに対する注視点の差
    [SerializeField]private Vector3 viewplus;
    //ゴムひもの強さ(値が低いほど伸びる)
    [SerializeField]float rubber_str;
    //カメラの向き
    [SerializeField]private Vector3 lookDown;

    void Start()
    {
        //デフォルト設定
        viewpos = new Vector3(0.0f, 0.5f, -distance);
        viewplus = new Vector3(0.0f, 1.5f, 0.0f);
        rubber_str = 0.1f;
        lookDown = new Vector3(10.0f, 1.0f, 0.0f);
        //


        transform.position = target.TransformPoint(viewpos);
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.TransformPoint(viewpos);
        Vector3 lerp = Vector3.Lerp(transform.position, desiredPosition, rubber_str);
        Vector3 toTarget = target.position - lerp;

        toTarget.Normalize();
        toTarget *= distance;
        transform.position = target.position - toTarget;
        transform.LookAt(target.position + viewplus, Vector3.up);
        transform.Rotate(lookDown);
    }
}
