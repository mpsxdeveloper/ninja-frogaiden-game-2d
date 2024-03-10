using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.DeleteAll();
    }

}