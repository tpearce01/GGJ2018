using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnManager : MonoBehaviour {
	public static NPCSpawnManager instance;
	public List<GameObject> NPCRefs = new List<GameObject>();
	[SerializeField] NPC[] NPCs;
	[SerializeField] Vector2 spawnPosition;
	[SerializeField] float distanceBetweenSpawns;
	bool[] eventFlags;
	List<NPCList> livingNPCs = new List<NPCList>();
	bool NPCListUpdated;
	bool firstSpawn = true;

	void Awake(){
		instance = this;
	}

	void Start(){
		SpawnAll ();
	}

	void Update(){
		//When player passes the last spawn location, spawn a random living NPC
		if (!firstSpawn && CameraMovement.camera.transform.position.x >= spawnPosition.x) {
			SpawnLivingNPC ();
		}
		else if (firstSpawn && CameraMovement.camera.transform.position.x >= spawnPosition.x + distanceBetweenSpawns/2) {
			firstSpawn = false;
		}
	}

	/// <summary>
	/// Spawns all NPCs into the game scene
	/// </summary>
	void SpawnAll(){
		for (int i = 0; i < NPCs.Length; i++) {
			IncrementSpawnPoint ();
			livingNPCs.Add(new NPCList(Instantiate (NPCs [i].prefab, spawnPosition, Quaternion.identity) as GameObject, NPCs[i].NPCNumber));
			NPCRefs.Add (livingNPCs [i].obj);
		}
	}

	/// <summary>
	/// Spawns a random living NPC
	/// </summary>
	void SpawnLivingNPC(){
		if (!NPCListUpdated) {
			UpdateLivingNPCs();
		}

		if (livingNPCs.Count > 0) {
			int index = Random.Range (0, livingNPCs.Count - 1);
			IncrementSpawnPoint ();
			livingNPCs [index].obj.transform.position = spawnPosition;
			livingNPCs [index].obj.GetComponent<NPCInteraction> ().hasInteracted = false;
			livingNPCs.RemoveAt(index);
		}

	}

	/// <summary>
	/// Updates the living NPC list
	/// </summary>
	void UpdateLivingNPCs(){
		for (int i = livingNPCs.Count - 1; i >= 0; i--) {
			if (!EventManager.CheckEventStatus (livingNPCs [i].NPCNumber)) {
				livingNPCs.RemoveAt (i);
			}
		}
		NPCListUpdated = true;
	}

	/// <summary>
	/// Updates the spawn location
	/// </summary>
	void IncrementSpawnPoint(){
		spawnPosition += new Vector2 (distanceBetweenSpawns, 0);
	}
}

[System.Serializable]
public class NPC{
	public GameObject prefab;
	//public EventType NPCEvent;
	public int NPCNumber;
}

public class NPCList{
	public GameObject obj;
	//public EventType NPCEvent;
	public int NPCNumber;

	public NPCList(GameObject newObj, int newNPCNumber/*, EventType newNPCEvent*/){
		obj = newObj;
		//NPCEvent = newNPCEvent;
		NPCNumber = newNPCNumber;
	}
}
