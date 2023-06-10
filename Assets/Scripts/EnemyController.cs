using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemy_Type;//このプログラムをつけた敵の種類(１か２)
    public GameObject prefab_Beam;//このプログラムをつけた敵が使用するビーム

    private float speed_X;//敵機のx方向(横方向)の移動スピード
    private GameObject gameManager;//Scene上のGameManagerゲームオブジェクト


    // Start is called before the first frame update
    void Start()
    {
        //Scene上のGameManagerゲームオブジェクトを取得
        //（自機の場合Public変数で事前に関連付けをさせたが、敵機はもともとScene上に
        //ないので敵機が自動作成された際にScene上から取得する
        gameManager = GameObject.Find("GameManager");

        //敵機のｘ方向（横方向）の移動スピードをランダムに設定
        //敵機の出現位置が画面中心からみて右側の場合
        if (transform.position.x >= 0)
        {
            //斜め左に向けて移動するようにスピードを設定
            speed_X = Random.Range(-1.9f, -0.1f);
        }
        else
        {
            speed_X = Random.Range(0.1f, 1.9f);
        }

        StartCoroutine("Create_Beam"); //ビームを繰り返し発生させるコルーチンを呼ぶ
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemy_Type)
        {
            case 1:
                transform.Translate(speed_X * Time.deltaTime, -2.5f * Time.deltaTime, 0);
                break;

            case 2:
                transform.Translate(speed_X * Time.deltaTime, -1.5f * Time.deltaTime, 0);
                if (transform.position.x < -2)
                    speed_X = Mathf.Abs(speed_X);
                else if (transform.position.x > 2)
                    speed_X = -1.0f * Mathf.Abs(speed_X);
                break;
        }
    }

    //敵がビームか境界に衝突した際に呼ばれる関数
    private void OnTriggerEnter2D(Collider2D other)
    {
        //衝突した相手のゲームオブジェクトのタグがBeam_Figherの場合
        if (other.gameObject.tag == "Beam_Fighter")
        {
            switch (enemy_Type)
            {
                case 1:
                    gameManager.GetComponent<ScoreManager>().AddScore(1);
                    break;

                case 2:
                    gameManager.GetComponent<ScoreManager>().AddScore(2);
                    break;
            }

            // 敵機のゲームオブジェクトを削除する
            Destroy(gameObject);
        }
    }

    IEnumerator Create_Beam()
    {
        Instantiate(prefab_Beam, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f); //プログラムを指定秒停止させる

        StartCoroutine("Create_Beam"); //再度ビームを発生させるコルーチンを呼ぶ
    }

}
