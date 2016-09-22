using UnityEngine;
using System.Collections;

public class ViewController : MonoBehaviour {

    public int startImg { get; set; }
    public bool isStereo { get; set; }
	
    void Awake()
    {
        startImg = 0;     // temp
        isStereo = false; // temp

        DontDestroyOnLoad(gameObject);
    }
}
