using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int score;
    public Text textScore;

    public void Addscore()
    {
        score++;
        textScore.text = score.ToString();
    }
}
