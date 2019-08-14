using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public int highScore;
    private Text highScoreText;
    private Text scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("highscore", highScore);
    }

    // Update is called once per frame
    void Update()
    {
        if (score > highScore)
        {
            highScore = score;
        }

        scoreTxt = GameObject.Find("ScoreText").GetComponent<Text>();
        highScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();

        scoreTxt.text = score.ToString();
        highScoreText.text = highScore.ToString();
        PlayerPrefs.SetInt("highscore", highScore);
    }

    public static void IncreaseScore()
    {
        score += 1;
    }
}
