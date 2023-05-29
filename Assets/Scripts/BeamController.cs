using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ビームを移動させる処理や自機・適期との衝突処理を実行
public class BeamController : MonoBehaviour
{
    const float SPEED_Y = 3.0f;//ビーム縦方向のスピード

    public int beam_Type;//ビームのタイプは３種類(1,2,3)

    private SpriteRenderer targetRenderer;// SpriteRendererコンポーネント取得用

    void Start()
    {
        // ビームのゲームオブジェクトに付けられたSpriteRendererコンポーネントを取得
        targetRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetRenderer.isVisible)
        {
            Destroy(gameObject);
        }

        //ビームのタイプ(beam_Type)によって処理を変える
        switch (beam_Type)
        {
            case 1:
                transform.Translate(0, SPEED_Y * Time.deltaTime, 0);
                break;
        }
    }
}
