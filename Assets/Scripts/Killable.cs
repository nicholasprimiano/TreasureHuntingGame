using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Director;
using UnityEngine.SceneManagement;

public class Killable : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth = 100;
	public CanBeShot canBeShot;
	public int heathPackValue = 5;
	public Health healthpack;

	// Use this for initialization
	void Start ()
	{
		// everyone starts with 100% health at the beginning of the game
		currentHealth = maxHealth;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Q) && healthpack.hasHealth){
			currentHealth += heathPackValue;
			currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
			healthpack.healthImage.SetActive (false);
			healthpack.hasHealth = false;
		}
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
					GameObject spikeHitSound = GameObject.Find ("SpikeHit");  //ugly hack
					AudioSource hitSound = spikeHitSound.GetComponent<AudioSource> ();
					hitSound.Play ();
					Destroy (gameObject);
				} else if (tag == "Player") {  // if player dies go to death screen
					SceneManager.LoadScene ("Death Screen");
				}
			}
			//player takes damage but doesn't die
			if (tag == "Player") {
				GetComponent<PlayerMove> ().hurtSound.PlayOneShot (GetComponent<PlayerMove> ().hurtSound.clip);
			}

		}
	}

//	private SpriteRenderer spredner;
//
//	void turnoff ()  //make enemy sprite invisible
//	{
//		spredner = GetComponent <SpriteRenderer> ();
//		spredner.color = new Color (0, 0, 0, 0);
//	}
//

}