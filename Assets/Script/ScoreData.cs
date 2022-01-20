using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public int Score;
    public int High;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Score = 0;
        if(High<1)High = 0;
    }

    public int GetScore()
    {
        return Score;
    }

    public int GetHigh()
    {
        return High;
    }
}
