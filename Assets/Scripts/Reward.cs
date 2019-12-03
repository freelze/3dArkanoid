using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public GameObject dupBall2;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(transform.localPosition.z, -10.0f, Time.deltaTime * 0.5f));
    }
    private void InstantBall()
    {
        Instantiate(dupBall2, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1.0f), new Quaternion(0, 0, 0, 0));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            //Debug.Log("Trap collider");
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Reward time");
            Invoke("InstantBall", 0f);
            Invoke("InstantBall", 0.5f);
            Invoke("InstantBall", 1.0f);
            //Instantiate(dupBall2,player.transform.position,new Quaternion(0,0,0,0));
            //Instantiate(dupBall2,new Vector3( player.transform.position.x-0.8f, player.transform.position.y, player.transform.position.z), new Quaternion(0, 0, 0, 0));
            //Instantiate(dupBall2, new Vector3(player.transform.position.x + 0.8f, player.transform.position.y, player.transform.position.z), new Quaternion(0, 0, 0, 0));

            //Destroy(gameObject,3.0f);
        }


    }
}
