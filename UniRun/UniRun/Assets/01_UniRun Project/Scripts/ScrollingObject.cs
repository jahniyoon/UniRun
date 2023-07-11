using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 게임매니저의 isGameOver가 false인 경우에만 살아있도록 하겠다.
        if (GameManager.instance.isGameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
