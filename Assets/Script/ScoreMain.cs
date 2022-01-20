using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMain : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    public ScoreData Sd;

    void Start()
    {
        Score = 0;
        Sd = GameObject.Find("ScoreData").GetComponent<ScoreData>();
    }

    void Update()
    {
        if (PlaneScript.moving)
        {
            Score += 1;
            ScoreText.text = string.Format("Score {0}", Score);
            Sd.Score = Score;
            if (Sd.High < Score) Sd.High = Score;
        }
    }
}
