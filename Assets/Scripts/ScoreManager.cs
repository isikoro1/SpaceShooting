using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    const int BOSS_START = 30;//ボスの出現スコア
    const int BOSS_END = 60; //ボスの破壊スコア

    public EnemyManager class_EnemyManager; //EnemyManagerの関数呼び出し用
    public Text text_Score;//UIにスコアを表示するテキスト
    public GameObject gameClear; //UIにGameClearを表示するテキスト

    private int totalScore = 0;//現在のスコア
    private bool isBossMode = false;//ボスが出現したらtrue
    private bool isGameClear = false;

    // Start is called before the first frame update
    void Start()
    {
        //UIのスコアに現在のスコアを表示
        text_Score.text = totalScore.ToString();
    }

    // Update is called once per frame
    public void AddScore(int score)
    {
        //現在のスコアに引数scoreだけ追加
        totalScore += score;
        //UIのスコアに現在のスコアを表示
        text_Score.text = totalScore.ToString();

        if (totalScore >= BOSS_START)//現在のスコアがボスの出現スコアを超えている場合
        {
            if (isBossMode == false)
            {
                isBossMode = true;//ボスが出現
                //ボス出現の関数をコルーチンで呼び出す
                //（数秒まってからボスを出現させるためコルーチンを使用）
                StartCoroutine("Call_CreateBoss");
            }

            if (totalScore >= BOSS_END)
            {
                isGameClear = true; //ゲームをクリアに
                gameClear.SetActive(true); //UIにGameClearのテキストを表示
                //自動リスタートの関数をコルーチンで呼び出す
                StartCoroutine("Restart_Game");
            }

        }
    }

    //ゲームオーバー後、数秒後にゲームリスタートさせるコルーチン
    IEnumerator Restart_Game()
    {
        yield return new WaitForSeconds(9.0f);//数秒待つ

        //指定のシーンを起動
        //同じシーンなら再起動
        SceneManager.LoadScene("GameMain");
    }


    //ボスの出現スコア到達の数秒後にボスを出現させるコルーチン
    IEnumerator Call_CreateBoss()
    {
        //ボスの出現処理の前に数秒待つ
        yield return new WaitForSeconds(4.0f);
        //EnemyManagerのボス出現の関数を呼び出す
        class_EnemyManager.Create_Boss();
    }


    public bool Get_BossMode()//他のプログラムからボスが出現しているか確認する関数
    {
        return isBossMode;
    }

    public bool Get_GameClear()
    {
        return isGameClear;
    }

}
