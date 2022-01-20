using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーンの切り替えに使用するライブラリ(メモ)
using UnityEditor;

public class SceneChange : MonoBehaviour
{
    GameObject StartB_1;
    GameObject StartB_2;

    // Start is called before the first frame update
    void Start()
    {
        StartB_1 = GameObject.Find("StartButton_1");
        StartB_2 = GameObject.Find("StartButton_2");
        StartB_2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClick()
    {
        StartCoroutine(WaitStart());
        //StartB_1.SetActive(false);
        //StartB_2.SetActive(true);
        //SceneManager.LoadScene("GameWait", LoadSceneMode.Single);
    }

    IEnumerator WaitStart()
    {
        StartB_2.SetActive(true);

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameWait", LoadSceneMode.Single);
    }
}
