using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private GameObject enemy;
    [SerializeField] private int ammount;

	void Start () {
		for(int i = 0; i < ammount; i++)
        {
            float x = Random.Range(0,10);
            float y = Random.Range(0, 10);
            Vector3 position = new Vector3(x, y);
            Instantiate(enemy, position, Quaternion.identity);
        }
	}
	
	void Update () {
		
	}
}
