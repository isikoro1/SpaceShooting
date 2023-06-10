using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ビームを移動させる処理や自機・適期との衝突処理を実行
public class BeamController : MonoBehaviour
{
    const float SPEED_Y = 6.0f;//ビーム縦方向のスピード

    public int beam_Type;//ビームのタイプは３種類(1,2,3)

    private float speed_X;//ビームのｘ方向のスピード
    private ScoreManager class_ScoreManager;//ScoreManagerの関数呼び出し用
    private SpriteRenderer targetRenderer;// SpriteRendererコンポーネント取得用

    void Start()
    {
        //Scene上のGameManagerゲームオブジェクトにつけられたScoreManagerを取得
        //（自機の場合Public変数で事前に関連付けをさせたが、ビームは元々Scene上に
        //ないのでビームが自動作成された際にScene上から取得する）
        class_ScoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        // ビームのゲームオブジェクトに付けられたSpriteRendererコンポーネントを取得
        targetRenderer = GetComponent<SpriteRenderer>();

        //斜めに飛ぶビームのｘ方向のスピードをランダムに設定
        speed_X = Random.Range(-1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //ビームのゲームオブジェクトが画面外に出た場合かゲームクリアした場合
        if (!targetRenderer.isVisible || class_ScoreManager.Get_GameClear())
        {
            Destroy(gameObject);
        }

        //ビームのタイプ(beam_Type)によって処理を変える
        switch (beam_Type)
        {
            case 1:
                transform.Translate(0, SPEED_Y * Time.deltaTime, 0);
                break;
            case 2:
                transform.Translate(0, -SPEED_Y * Time.deltaTime, 0);
                break;

            case 3:
                transform.Translate(speed_X * Time.deltaTime, -SPEED_Y * Time.deltaTime, 0);
                break;

        }
    }

    //ビームが、敵か自機に衝突した際に呼ばれる関数
    private void OnTriggerEnter2D(Collider2D other)
    {
        //衝突した相手のゲームオブジェクトのタグがEnemyの場合
        if (other.gameObject.tag == "Enemy")
        {

            //ビームのタイプbeam_Typeが1の場合
            if (beam_Type == 1)
            {
                //ビームのゲームオブジェクトを削除する
                Destroy(gameObject);
            }
        }

        if (other.gameObject.tag == "Player")
        {
            if (beam_Type == 2 || beam_Type == 3)
            {
                Destroy(gameObject);
            }
        }
    }

}
