using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("水平動速度")]
    public float speedX;
    [Header("垂直動速度")]
    public float speedY;
    public Ball myBall;
    Rigidbody playerRigidbody;
    Transform playerTransform;
    void Start()
    {
        //連結板子的<Rigidbody2D>去操控她
        playerRigidbody = GetComponent<Rigidbody>();
        playerTransform = this.transform;
    }


    void Update()
    {
        moveLeftOrRight();
    }
    float LeftOrRight()
    {
        return Input.GetAxis("Mouse X");
    }
    float UpOrDown()
    {
        return Input.GetAxis("Mouse Y");
    }
    void moveLeftOrRight()
    {
        //玩家操控按鍵移動速度=回傳值*移動向量
        playerRigidbody.velocity = LeftOrRight() * new Vector3(speedX, 0, 0) + UpOrDown() * new Vector3(0, speedY, 0);
        if (myBall.isStop())
            myBall.transform.position = new Vector3(transform.position.x, myBall.transform.position.y, transform.position.z+1.0f );
    }
}
