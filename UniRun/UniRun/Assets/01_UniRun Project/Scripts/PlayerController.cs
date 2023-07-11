using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float jumpForce = 300;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;
    private bool isPowerUp = false;


    private Rigidbody2D playerRigid = default;
    private Animator animator = default;
    private BoxCollider2D colider = default;

    public float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
       
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        colider = GetComponent<BoxCollider2D>();

        GlobalFunc.Assert(playerRigid != null);
        GlobalFunc.Assert(animator != null);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false)
        { 
        float xInput = Input.GetAxis("Horizontal");
  
        float xSpeed = xInput * speed;
        Vector2 newVelocity = new Vector2(xSpeed, playerRigid.velocity.y);
        playerRigid.velocity = newVelocity;
        }

        if (isDead) { return; }

        if (Input.GetMouseButtonDown(0) && jumpCount < 3 || Input.GetKeyDown(KeyCode.Space) && jumpCount < 3)       // 점프가 한번만 가능하도록
        {
            Debug.Log("점프하나?");

            jumpCount += 1;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));


            Audio audio = FindObjectOfType<Audio>();
            audio.JumpSound();

        }

        else if (Input.GetMouseButtonDown(0) && 0 < playerRigid.velocity.y || Input.GetKeyDown(KeyCode.Space) && 0 < playerRigid.velocity.y) //  2단점프 제약주는 로직
        {
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }

        animator.SetBool("Grounded", isGrounded); //Ground 는 꼭 복사 붙여넣기로 하는 습관 하기.
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        playerRigid.velocity = Vector2.zero;
        playerRigid.AddForce(new Vector2(0, 300f));

        Audio audio = FindObjectOfType<Audio>();
        audio.DieSound();

        playerRigid.velocity = Vector2.zero;
        isDead = true;

        GameManager.instance.OnPlayerDead(); // 게임매니저의 OnPlayerDead 불러오기
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && isDead == false && isPowerUp == false || other.tag == "DeadOut" && isDead == false)
        {
            Debug.Log("죽었나?");

            Die();

        }
        else if (other.tag == "Dead" && isDead == false && isPowerUp == true)
        {
            Debug.Log("파워업 해제");
            isPowerUp = false;
            animator.SetBool("isPowerUp", isPowerUp); //Ground 는 꼭 복사 붙여넣기로 하는 습관 하기.


            Audio audio = FindObjectOfType<Audio>();
            audio.HitSound();

        }

        else if (other.tag == "PowerUp" && isDead == false && isPowerUp == false)
        {
            Debug.Log("파워업 한다.");
            //this.transform.localScale += new Vector3(1.5f, 1.5f, 0f);

            isPowerUp = true;
            animator.SetBool("isPowerUp", isPowerUp); //Ground 는 꼭 복사 붙여넣기로 하는 습관 하기.

            Audio audio = FindObjectOfType<Audio>();
            audio.PowerupSound();

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0.7f < collision.contacts[0].normal.y)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;

    }


}
