using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverWorld_Controller : MonoBehaviour {

    GameObject OverWorld;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        OverWorld = GameObject.Find("OverWorld");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
