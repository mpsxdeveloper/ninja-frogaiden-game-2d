using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    
    public float Speed;
    public bool dirBottom = true;
    private float timer;
    public float moveTime;

    // Update is called once per frame
    void Update()
    {
        if(dirBottom) {
            transform.Translate(Vector2.down * Speed * Time.deltaTime);
        }
        else {
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if(timer >= moveTime) {
            dirBottom = !dirBottom;
            timer = 0f;
        }
    }

}