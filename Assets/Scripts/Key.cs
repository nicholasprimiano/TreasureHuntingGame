using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	public bool hasKey = false;
	public Transform player;
	public GameObject keyImage;
	// Use this for initialization
	void Start () {
		keyImage.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if((player.transform.position - transform.position).magnitude <= 20f ){
			hasKey = true;
			gameObject.SetActive (false);
		}
		if(hasKey){
			keyImage.SetActive (true);
		}
	}
}
