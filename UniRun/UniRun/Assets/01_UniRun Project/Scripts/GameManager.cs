using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Text mesh pro 컴포넌트
using UnityEngine.UI; // Legacy Text 컴포넌트트
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //static을 써서 여기저기 쓸 수 있다. instance는 제작자가 만든 이름으로 바꿔 쓸 수 있다.

    public bool isGameOver = false;
    public TMP_Text scoreText;  // Text mesh pro 컴포넌트
    public Text scoreText_; // Legacy Text 컴포넌트
    public GameObject gameOverUi;

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            GlobalFunc.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);

        }

        //// List 쓰고있는지 체크
        //List<int> intList = null;
        //Debug.LogFormat("intList가 유효한지? (존재하는지?) : {0}", intList.IsValid());

    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true && Input.GetMouseButtonDown(0))
        {
            //GlobalFunc.LoadScene("PlayerScene");
            GlobalFunc.LoadScene(GlobalFunc.GetActiveSceneName());
        }

    }

    public void AddScore(int newScore)
    {
        // 게임오버가 아니라면
        if (isGameOver == false)
        {
            //점수 증가
            score += newScore;
            scoreText.text = string.Format("Score : {0}", score);
        }
    }
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);
    }
}
