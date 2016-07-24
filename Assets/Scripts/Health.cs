using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

	public bool hasHealth = false;
	public Transform player;
	public GameObject healthImage;

	// Use this for initialization
	void Start ()
	{
		healthImage.SetActive (false);
	}

	// Update is called once per frame
	void Update ()
	{
		if ((player.transform.position - transform.position).magnitude <= 10f) {
			hasHealth = true;
			gameObject.SetActive (false);
		}
		if (hasHealth) {
			healthImage.SetActive (true);
		}
	}



}
