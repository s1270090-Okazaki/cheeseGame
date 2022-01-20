using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーンの切り替えに使用するライブラリ(メモ)
using UnityEditor;

public class ReturnTitle : MonoBehaviour
{
    GameObject ReturnB_1;
    GameObject ReturnB_2;

    // Start is called before the first frame update
    void Start()
    {
        ReturnB_1 = GameObject.Find("ReturnButton_1");
        ReturnB_2 = GameObject.Find("ReturnButton_2");
        ReturnB_2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {
        ReturnB_1.SetActive(false);
        ReturnB_2.SetActive(true);
        //StartCoroutine("Wait");
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
