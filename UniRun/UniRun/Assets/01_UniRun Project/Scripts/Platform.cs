using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject[] obstacles;
    public GameObject[] coins;
    public GameObject[] powerUp;
    private bool stepped = false;

    private void OnEnable()
    {
        stepped = false;

        for (int i = 0; i < obstacles.Length; i++)
        {
            if (Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }

        }

        for (int i = 0; i < coins.Length; i++)
        {
            if (Random.Range(0, 6) == 0)
            {
                coins[i].SetActive(true);
            }
            else
            {
                coins[i].SetActive(false);
            }

        }
        for (int i = 0; i < powerUp.Length; i++)
        {
            if (Random.Range(0, 3) == 0)
            {
                powerUp[i].SetActive(true);
            }
            else
            {
                powerUp[i].SetActive(false);
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player") && stepped == false)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }

  
}
