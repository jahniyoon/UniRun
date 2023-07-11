using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag.Equals("Player"))
    //    {
    //        Debug.Log("파워업을 먹었나?");

    //        gameObject.SetActive(false);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
        {
            Debug.Log("파워업을 먹었나?");

            gameObject.SetActive(false);
        }
    }
}
