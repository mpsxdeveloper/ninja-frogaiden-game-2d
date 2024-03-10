using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melon : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player") {
            sr.enabled = false;
            circle.enabled = false;            
            GameController.instance.UpdateScore(Score);
            GameController.instance.UpdateScoreText();
            GameController.instance.PlayItemSound();
            Destroy(gameObject);
        }
    }

}