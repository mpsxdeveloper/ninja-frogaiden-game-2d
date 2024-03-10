using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    
    public string lvlName;
    public AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            audioSource.Play();
            StartCoroutine(LoadNextLevel(lvlName, 1.5f));            
        }
    }
    
    IEnumerator LoadNextLevel(string l, float d) {
        yield return new WaitForSeconds(d); 
        SceneManager.LoadScene(l);
    }

}