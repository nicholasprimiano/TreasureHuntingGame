using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	
	public Key playerKey;
	public Transform player;
	public Treasure textbuffer;
	public bool nearDoor = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		nearDoor = false;
		if((player.transform.position - transform.position).magnitude <= 20f && playerKey.hasKey){
			gameObject.SetActive (false);

		}
		if((player.transform.position - transform.position).magnitude <= 20f){
			textbuffer.textbuffer.text = "The door is locked. Find the key";
			nearDoor = true;
		}
	}
}
