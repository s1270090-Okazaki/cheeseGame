using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreResult : MonoBehaviour
{
    private GameObject ScoreMaster;
    private ScoreData Sd;

    public Text tx;
    public Text tx_H;

    int Score;
    int High;

    void Start()
    {
        ScoreMaster = GameObject.Find("ScoreData");
        Sd = ScoreMaster.GetComponent<ScoreData>();

        Score = Sd.GetScore();
        High = Sd.GetHigh();
        tx.text = string.Format("Score {0}", Score);
        tx_H.text = string.Format("High Score {0}", High);
    }

}
