using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour
{
    public GameObject prefab_Beam;

    private Vector3 startPos; // 前フレームのマウスの位置
    private Vector3 endPos; // 現フレームのマウスの位置
    private Vector3 difPos; // 前フレームと現フレームのマウスの移動量

    void Start()
    {
        StartCoroutine("Create_Beam");   
    }

    // Update is called once per frame
    void Update()
    {
        //【自機の移動の概要】
        // 1.マウスボタンを押した位置をスタート位置として取得
        // 2.マウスボタンを押したまま移動させた場合、その位置をエンド位置として取得
        // （エンド位置といってもまだマウスボタンは離していない
        // 3.マウスのスタート位置からエンド位置の移動距離と方向を取得
        // 4.それを自機の位置に反映させる
        // 5.今のエンド位置を次のフレームのマウスのスタート位置として上記の2.に戻る

        // マウスボタンを押した場合実行
        if (Input.GetMouseButtonDown(0))
        {
            // マウスボタンを押した時のマウスの位置をスタート位置として取得
            // (スマホの場合、タップした位置を取得)
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        // マウスボタンを押し続けている場合実行
        if (Input.GetMouseButton(0))
        {
            //マウスボタンを押し続けている場合、現在のマウスの位置を取得
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // マウスボタンを押したスタート位置から押し続けている現在の位置までの差分（方向・距離）を計算
            difPos = endPos - startPos;

            // 自機の現在位置にマウスの移動方向・距離を加えた位置が画面の大きさの範囲内にいる場合
            if (2.4f > transform.position.x + difPos.x && transform.position.x + difPos.x > -2.4f && 4.5f > transform.position.y + difPos.y && transform.position.y + difPos.y > -4.5f)
            {
                // 自機をその位置に移動させる
                transform.Translate(difPos);
            }

            // 移動後の自機の位置を次のフレームのマウスの移動方向・距離の計算するスタート位置として使用
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    //ビームを発生させるコルーチン
    IEnumerator Create_Beam()
    {
        //ビームのプレハブをシーン上に作成する
        Instantiate(prefab_Beam, transform.position, Quaternion.identity);
        //プログラムを指定秒停止させる
        yield return new WaitForSeconds(0.3f);

        //再度ビームを発生させるコルーチンを呼ぶ
        StartCoroutine("Create_Beam");
    }
}
