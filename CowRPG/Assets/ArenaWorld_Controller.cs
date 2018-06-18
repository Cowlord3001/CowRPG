using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaWorld_Controller : MonoBehaviour
{

    public static GameObject Arena;

    // Use this for initialization
    void Start()
    {
        GameObject.Find("Arena");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            LoadArena();
        }
    }

    void LoadArena()
    {
        OverWorld_Controller.OverWorld.SetActive(true);
        Arena.SetActive(false);
    }
}
