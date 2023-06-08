using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵ボスを移動させる処理やビーム砲の発射処理、相手ビームとの衝突処理を実行
public class BossConroller : MonoBehaviour
{
    //敵ボスの移動スピード
    private float speed_X = -0.3f; //ボスのx方向の移動スピード
    private float speed_Y = -0.3f; //ｙ方向
    private GameObject gameManager; //Scene上のGameManagerゲームオブジェクト

    void Start()
    {
        //Scene上のGameManagerゲームオブジェクトを取得
        //（自機の場合Public変数で事前に関連付けをさせたが、敵機はもともとScene上に
        //ないので敵機が自動作成された際にScene上から取得する
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        // 毎フレーム、ｘ方向（横方向）とｙ方向（縦方向）に指定の距離だけ移動する
        // (ｘ方向とｙ方向にスピード×時間＝距離だけ移動)
        transform.Translate(speed_X * Time.deltaTime, speed_Y * Time.deltaTime, 0);

        // 敵ボスが左端まで行ったら、ｘ方向を右への移動に変更
        if (transform.position.x < -2) speed_X = 0.3f;
        //反対
        else if (transform.position.x > 2) speed_X = -0.3f;

        //　下端までいったら、上への移動に変更
        if (transform.position.y < 0) speed_Y = 0.3f;
        //　反対
        else if (transform.position.y > 4.5) speed_Y = -0.3f;
    }

    //ボスがビームに衝突した際に呼ばれる関数
    private void OnTriggerEnter2D(Collider2D other)
    {
        //衝突した相手のゲームオブジェクトのタグがBeam_Fighterの場合
        if (other.gameObject.tag == "Beam_Fighter")
        {
            //指定のスコアを追加する関数を呼び出す
            //→アレンジ時:ボスのHPを減らす関数に変える
            gameManager.GetComponent<ScoreManager>().AddScore(1);

            //ScoreManagerのisGameClearの値がtrueの場合
            if (gameManager.GetComponent<ScoreManager>().Get_GameClear() == true)
            {
                //敵ボスのゲームオブジェクトを削除する
                Destroy(gameObject);
            }
        }
        
        
    }

}
