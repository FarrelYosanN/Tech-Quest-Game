using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSelesai : MonoBehaviour
{
    public Text Teks_Score, Teks_TotalScore;

    public void Start()
    {
        if(Data.DataScore >= PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", Data.DataScore);
        }


        Teks_Score.text = Data.DataScore.ToString();
        Teks_TotalScore.text = PlayerPrefs.GetInt("score").ToString();
    }
}
