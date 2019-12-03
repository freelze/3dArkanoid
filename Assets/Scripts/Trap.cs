using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    //[Header("被撞到時候的位移")]
    //public Vector3 offset;
    public int life = 3;
    public GameObject ball;
    public GameObject player;
    private void OnCollisionEnter(Collision other)
    {
        //Ball ball_1 = ball.GetComponent<Ball>();
        //Rigidbody ball_Rig = ball.GetComponent<Rigidbody>();
        if (other.gameObject.CompareTag("Ball"))
        {
            life--;
            //ball_Rig.velocity = Vector3.zero;
            //ball_1.transform.position = player.transform.position;
            //gameObject.transform.position += offset;
        }
        
        //if (life <= 0 && !GameManager.LevelClear)
        if (life <= 0 )
        {
            GameManager.ReloadThisScene();
        }

    }
}
