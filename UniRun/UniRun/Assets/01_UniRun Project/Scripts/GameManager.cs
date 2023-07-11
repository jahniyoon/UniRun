using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Text mesh pro ������Ʈ
using UnityEngine.UI; // Legacy Text ������ƮƮ
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //static�� �Ἥ �������� �� �� �ִ�. instance�� �����ڰ� ���� �̸����� �ٲ� �� �� �ִ�.

    public bool isGameOver = false;
    public TMP_Text scoreText;  // Text mesh pro ������Ʈ
    public Text scoreText_; // Legacy Text ������Ʈ
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
            GlobalFunc.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);

        }

        //// List �����ִ��� üũ
        //List<int> intList = null;
        //Debug.LogFormat("intList�� ��ȿ����? (�����ϴ���?) : {0}", intList.IsValid());

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
        // ���ӿ����� �ƴ϶��
        if (isGameOver == false)
        {
            //���� ����
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
