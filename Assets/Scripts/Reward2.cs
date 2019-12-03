using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward2 : MonoBehaviour
{
    //public GameObject dupBall2;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            //Debug.Log("Trap collider");
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Reward2 time");
            player.GetComponent<Transform>().localScale += new Vector3(0.05f, 0.05f, 0.05f);
            Destroy(gameObject);
        }


    }
}
