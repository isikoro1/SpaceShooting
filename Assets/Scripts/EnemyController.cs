using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemy_Type;

    private float speed_X;


    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x >= 0)
        {
            speed_X = Random.Range(-1.5f, -0.1f);
        }
        else
        {
            speed_X = Random.Range(0.1f, 1.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemy_Type)
        {
            case 1:
                transform.Translate(speed_X * Time.deltaTime, -2.0f * Time.deltaTime, 0);
                break;

            case 2:
                transform.Translate(speed_X * Time.deltaTime, -1.0f * Time.deltaTime, 0);
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
            // 敵機のゲームオブジェクトを削除する
            Destroy(gameObject);
        }
    }

}
