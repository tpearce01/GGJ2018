using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
	[SerializeField] Spawnable[] toSpawn;
	[SerializeField] NPCMover[] moveNPCs;

	void Start(){
		SpawnAll ();
	}

	void Update(){
		CheckSpawn ();
	}

	void SpawnAll(){
		for (int i = 0; i < toSpawn.Length; i++) {
			Instantiate (toSpawn [i].prefab, toSpawn[i].spawnLocation, Quaternion.identity);
		}
	}


	void CheckSpawn(){
		for (int i = 0; i < moveNPCs.Length; i++) {
			if (CameraMovement.xPosition() >= moveNPCs [i].targetPosition.x - 10) {
				NPCSpawnManager.instance.NPCRefs [moveNPCs [i].NPCNumber].transform.position = (Vector3)moveNPCs [i].targetPosition;
				NPCSpawnManager.instance.NPCRefs[moveNPCs [i].NPCNumber].GetComponent<NPCInteraction> ().hasInteracted = false;
			}
		}
	}
}

[System.Serializable]
public class Spawnable{
	public GameObject prefab;
	public Vector2 spawnLocation;
}

[System.Serializable]
public class NPCMover{
	public int NPCNumber;
	public Vector2 targetPosition;
}
