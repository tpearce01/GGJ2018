using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSwapper : MonoBehaviour {

    [SerializeField] GameObject camera;
    [SerializeField] Transform NPCLocation1;
    [SerializeField] GameObject NPC1;
    [SerializeField] GameObject NPC2;
    [SerializeField] GameObject NPC3;

    List<GameObject> NPCList = new List<GameObject>();
    
    // Use this for initialization
    void Start () {
        buildNPCList();
	}
	
	// Update is called once per frame
	void Update () {
        if (camera.transform.position.x * 2 >= NPCLocation1.position.x) {
            NPCLocation1.GetComponent<SpriteRenderer>().color = Color.blue;
        }

    }

    void buildNPCList () {
        NPCList.Add(NPC1);
        NPCList.Add(NPC2);
        NPCList.Add(NPC3);
    }
}
