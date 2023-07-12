using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilledTypeTest : MonoBehaviour
{
    public Image filledTypeImg;
    private void Awake()
    {
        filledTypeImg.fillAmount = 1.0f;


    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PassedCoolTime(1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //if (0 < filledTypeImg.fillAount)
        //{
        //    filledTypeImg.fillAmount -= (Time.deltaTime * 0.5f);
        //}
    }

    private IEnumerator PassedCoolTime(float cooltimeDelay)
    {
        float cooltimePercent = 1f / 10f;
        while (0 < filledTypeImg.fillAmount)
        {
            // �̸�ŭ �ð��� �ɸ���.
            yield return new WaitForSeconds(cooltimeDelay);

            //�ð��� ������ ������ ó���Ѵ�.
            filledTypeImg.fillAmount -= cooltimePercent;
        }
    }
}
