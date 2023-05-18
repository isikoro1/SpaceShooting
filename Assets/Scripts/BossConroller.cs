using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵ボスを移動させる処理やビーム砲の発射処理、相手ビームとの衝突処理を実行
public class BossConroller : MonoBehaviour
{
    //敵ボスの移動スピード
    private float speed_X = -0.3f;
    private float speed_Y = -0.3f;

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
}
