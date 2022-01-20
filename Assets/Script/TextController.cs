using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    public float speed = 1.0f;
    public bool OnClick = false;
    public AudioClip sound1;
    public AudioClip sound2;

    AudioSource audioSource;

    private Text text;
    private float time;

    private enum ObjType
    {
        TEXT
    };
    private ObjType thisObjType = ObjType.TEXT;

    void Start()
    {
        if (this.gameObject.GetComponent<Text>())
        {
            thisObjType = ObjType.TEXT;
            text = this.gameObject.GetComponent<Text>();
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(thisObjType == ObjType.TEXT && OnClick == false)
        {
            text.color = GetAlphaColor(text.color);
        }

        if(Input.GetMouseButtonDown(0))
        {
            OnClick = true;
            StartCoroutine(CountDown());
            //text.text = "sucusses change";
        }


    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }

    IEnumerator CountDown()
    {
        text.color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
        text.fontSize = 220;
        audioSource.PlayOneShot(sound1);
        text.text = "3";
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(sound1);
        text.text = "2";
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(sound1);
        text.text = "1";
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(sound2);
        text.text = "GO!!";
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);

    }
}
