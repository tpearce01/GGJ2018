using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
	[SerializeField] Spawnable[] toSpawn;

	void Start(){
		SpawnAll ();
	}

	void SpawnAll(){
		for (int i = 0; i < toSpawn.Length; i++) {
			Instantiate (toSpawn [i].prefab, toSpawn[i].spawnLocation, Quaternion.identity);
		}
	}

}

[System.Serializable]
public class Spawnable{
	public GameObject prefab;
	public Vector2 spawnLocation;
}
