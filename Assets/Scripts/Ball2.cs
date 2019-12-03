using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball2 : MonoBehaviour
{
    //public GameObject player;
    public GameObject reward;
    public GameObject reward2;
    public Material GreenMaterial;
    public Text scoreText;
    int score;

    Rigidbody ballRigidbody;
    SphereCollider ballCircleCollider;

    [Header("初始水平速度")]
    public float speedX;

    [Header("初始垂直速度")]
    public float speedY;
    [Header("初始垂直速度")]
    public float speedZ;
    public float randomXf;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        ballRigidbody = GetComponent<Rigidbody>();
        ballCircleCollider = GetComponent<SphereCollider>();
        Invoke("ballStart", 0);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ballStart();
        }
    }

    void ballStart()
    {
        if (isStop())
        {
            int randomZ = Random.Range(10, 18);
            //Debug.Log("randomZ:"+ randomZ);
            int randomPN = Random.Range(0, 2);
            //Debug.Log("randomPN:" + randomPN);
            if (randomPN == 0)
            {
                //Debug.Log("randomPN == 0");
                randomZ = -randomZ;
            }
            randomXf = (float)randomZ;
            ballCircleCollider.enabled = true;
            transform.SetParent(null);
            ballRigidbody.velocity = new Vector3(speedX, speedY, speedZ);
        }
    }
    public bool isStop()
    {
        return ballRigidbody.velocity == Vector3.zero;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            //this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1.0f);
            ballRigidbody.velocity = Vector3.zero;
            Destroy(gameObject);
        }
        else
        {
            lockSpeed(); //維持速度
            if (other.gameObject.CompareTag("Cube"))//if (other.gameObject.CompareTag(tags.磚塊.ToString()))
            {
                int randomReward = Random.Range(1, 7);
                if (randomReward == 5)
                {
                    Instantiate(reward, this.transform.position, new Quaternion(0, 0, 0, 0));
                }
                else if (randomReward == 6)
                {
                    Instantiate(reward2, this.transform.position, new Quaternion(0, 0, 0, 0));
                }
                GameManager.brickCount--;
                Debug.Log("目前磚塊數量: " + GameManager.brickCount);
                GameManager.CheckLevelClearOrNot();
                other.gameObject.SetActive(false);
                score += 10;
                //scoreText.text = "目前分數: " + score;
            }
            if (other.gameObject.CompareTag("IronCube"))//if (other.gameObject.CompareTag(tags.磚塊.ToString()))
            {
                other.gameObject.tag = "Cube";
                other.gameObject.GetComponent<MeshRenderer>().material = GreenMaterial;
                //scoreText.text = "目前分數: " + score;
            }
        }
    }
    void lockSpeed()
    {
        ballRigidbody.velocity = new Vector3(resetSpeedX(), resetSpeedY(), resetSpeedZ());
    }

    float resetSpeedX()
    {
        float currentSpeedX = ballRigidbody.velocity.x;
        if (currentSpeedX < 0)
            return -speedX;
        else
            return speedX;
    }

    float resetSpeedY()
    {
        float currentSpeedY = ballRigidbody.velocity.y;
        if (currentSpeedY < 0)
            return -speedY;
        else
            return speedY;
    }
    float resetSpeedZ()
    {
        float currentSpeedZ = ballRigidbody.velocity.z;
        if (currentSpeedZ < 0)
            return -speedZ;
        else
            return speedZ;
    }
}
