using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public float Height, Width;
    public GameObject[] Enemies;
    public List<GameObject> ActiveEnemies;
    public int EnemyMax;
    public GameObject Overworld;

	// Use this for initialization
	void OnEnable ()
    {
        int EnemyNum = Random.Range(1, EnemyMax);

        for (int i = 0; i < EnemyNum; i++)
        {
            int n = Random.Range(0, Enemies.Length);
            GameObject Enemy = Instantiate(Enemies[n],
                               transform.position + new Vector3(Width / 2, -Height / 2 + i),
                               Quaternion.identity);

            ActiveEnemies.Add(Enemy);
        }
        
	}
	
    void LoadWorld()
    {
        Overworld.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
		if(ActiveEnemies.Count == 0)
        {
            Invoke("LoadWorld", 2);
        }
	}
}
