using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRL : MonoBehaviour
{
    
    public float Speed;
    public bool dirRight = true;
    private float timer;
    public float moveTime;

    // Update is called once per frame
    void Update()
    {
        if(dirRight) {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        else {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if(timer >= moveTime) {
            dirRight = !dirRight;
            timer = 0f;
        }
    }

}