using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject PauseScreen;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(Time.timeScale);
            if(Time.timeScale > 0.5f)
                Time.timeScale = 0.0f;

            if (Time.timeScale < 0.5f)
                Time.timeScale = 1.0f;
        }
	}
}
