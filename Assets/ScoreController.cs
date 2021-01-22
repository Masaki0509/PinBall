using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreText; //Text用変数
    private int score = 0; //スコア計算用変数

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        SetScore();   //初期スコアを代入して表示
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
    
        if (tag == "SmallStarTag")
        {
            this.score += 10;
        }
        else if (tag == "LargeStarTag")
        {
            this.score += 100;
        }
        else if (tag == "SmallCloudTag")
        {
            this.score += 50;
        }
        else if (tag == "LargeCloudTag")
        {
            this.score += 200;
        }

        SetScore();

    }

    void SetScore()
    {
        scoreText.text = string.Format("Score:{0}", score);
    }
}

