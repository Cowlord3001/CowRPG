using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverWorld_Controller : MonoBehaviour
{

    public static GameObject OverWorld;
    public static GameObject Arena;

    // Use this for initialization
    void Start ()
    {
        OverWorld = GameObject.Find("OverWorld");
        Arena = GameObject.Find("Arena");

        Arena.SetActive(false);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            LoadWorld();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            LoadArena();
        }
    }

    public static void LoadWorld()
    {
        Arena.SetActive(false);
        OverWorld.SetActive(true);
    }

    public static void LoadArena()
    {
        Arena.SetActive(true);
        OverWorld.SetActive(false);
    }
}
