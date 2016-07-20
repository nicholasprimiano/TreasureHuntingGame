using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Director;

public class Killable : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth = 100;
	public CanBeShot canBeShot;

	// Use this for initialization
	void Start ()
	{
		// everyone starts with 100% health at the beginning of the game
		currentHealth = maxHealth;
	}

	//Public so death trigger can talk to it
	public void Hurt (int damage)
	{
		if (canBeShot.canBeShot) {
			currentHealth -= damage;
			currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
			if (currentHealth <= 0) {
				AudioSource audio = GetComponent<AudioSource> ();
				audio.Play ();
//				if (tag == "Enemy") {
//					damage = 0;
//					turnoff ();
//				}
				gameObject.SetActive (false);
			}
		}
	}

	//	public SpriteRenderer spredner;
	//
	//	void turnoff ()
	//	{
	//		spredner = GetComponent <SpriteRenderer> ();
	//		spredner.renderer. = false;
	//
	//	}


}