using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject scoreText; 

    //スコアのカウント用
    private int score; 

    void Scorepoint(int score)
    {
        this.scoreText.GetComponent<Text>().text = "Score" + this.score;
    }

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        this.scoreText = GameObject.Find("ScoreText");

        score = 0;
        Scorepoint(score);   //初期スコアを代入して表示
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    void OnCollisionEnter(Collision collision)
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

        Scorepoint(score);
    }
}

