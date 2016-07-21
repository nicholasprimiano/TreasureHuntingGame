using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Director;
using UnityEngine.SceneManagement;

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
		//canBeShot.canBeShot is true only after player enters attack trigger
		//This prevents the player from shooting enemies until they attack
		//canBeShot.canBeshot is always true for the player
		if (canBeShot.canBeShot) {
			currentHealth -= damage;
			//clap health for all object between 0 and maxHealth
			currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
			//TODO add damage sound
			if (currentHealth <= 0) {  // object death
				if (tag == "Enemy") {  // if the object is an enemy play enemy death sound
					AudioSource audio = GetComponent<AudioSource> ();
					audio.Play ();
					damage = 0;  // enemy will not damage player
					turnoff ();  // enemy will dissappear
				} else if (tag == "Player") {  // if player dies go to death screen
					SceneManager.LoadScene ("Death Screen");
				}
			}
			//player takes damage but doesn't die
			if (tag == "Player") {
				GetComponent<PlayerMove> ().hurtSound.Play ();
			}

		}
	}

	private SpriteRenderer spredner;

	void turnoff ()  //make enemy sprite invisible
	{
		spredner = GetComponent <SpriteRenderer> ();
		spredner.color = new Color (0, 0, 0, 0);
	}


}