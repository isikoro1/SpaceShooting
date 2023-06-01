using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//敵機の自動作成に使用するクラス
//敵機１，２の自動作成とボスの作成処理を実行
public class EnemyManager : MonoBehaviour
{

    //Unity Editorから設定するPublic変数
    public GameObject prefab_Enemy1;
    public GameObject prefab_Enemy2;

    void Start()
    {
        //敵機１を繰り返し発生させるコルーチンを呼ぶ
        StartCoroutine("Create_Enemy1");
        //敵機２を繰り返し発生させるコルーチンを呼ぶ
        StartCoroutine("Create_Enemy2");
    }

    //敵機１を発生させるコルーチン
    IEnumerator Create_Enemy1()
    {
        //このコルーチン内だけで使用する変数
        //敵機１の発生させるｘ座標をランダムに設定
        float pos_Spoon_X = Random.Range(-2.5f, 2.5f);
        //次の敵機１を発生させるまでの間隔をランダムに設定
        float time_Wait = Random.Range(1.5f, 2.0f);

        // 敵機１を指定の場所に発生させる
        GameObject instance = (GameObject)Instantiate(prefab_Enemy1,
                                                      new Vector3(pos_Spoon_X, 5.5f, 0.0f),
                                                      Quaternion.identity);
        // プログラムを指定秒停止させる
        yield return new WaitForSeconds(time_Wait);

        //　再度敵機１を発生させるコルーチンを呼ぶ
        StartCoroutine("Create_Enemy1");

    }

    //敵機２
    IEnumerator Create_Enemy2()
    {
        float pos_Spoon_X = Random.Range(-2.5f, 2.5f);
        float time_Wait = Random.Range(4f, 6f);

        GameObject instance = (GameObject)Instantiate(prefab_Enemy2,
                                                      new Vector3(pos_Spoon_X, 5.5f, 0.0f),
                                                      Quaternion.identity);
        yield return new WaitForSeconds(time_Wait);

        StartCoroutine("Create_Enemy2");
    }

}
