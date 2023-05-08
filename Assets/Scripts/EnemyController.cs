using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemy_Type;

    private float speed_x;


    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x >= 0)
        {
            speed_x = Random.Range(-1.5f, -0.1f);
        }
        else
        {
            speed_x = Random.Range(0.1f, 1.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemy_Type)
        {
            case 1:
                transform.Translate(speed_x * Time.deltaTime, -2.0f * Time.deltaTime, 0);
                break;
        }
    }
}
