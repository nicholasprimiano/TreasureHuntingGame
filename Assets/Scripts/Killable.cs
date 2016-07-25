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
	public PlayerMove player;
	public bool easyMode = false;
	private int easyMaxHealth = 25;
	// Use this for initialization
	void Start ()
	{
		// everyone starts with 100% health at the beginning of the game
		currentHealth = maxHealth;
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Q) && healthpack.hasHealth) {
			currentHealth += heathPackValue;
			if (!easyMode) { //dont clamp easy mode
				currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
			} else {
				currentHealth = Mathf.Clamp (currentHealth, 0, easyMaxHealth);
			}
			healthpack.healthImage.SetActive (false);
			healthpack.hasHealth = false;
		}
		if (Input.GetKeyDown (KeyCode.F) && !easyMode) {
			currentHealth = easyMaxHealth;
			easyMode = true;
		}

	}


	//Public so death trigger can talk to it
	public void Hurt (int damage)
	{
		
		//canBeShot.canBeShot is true only after player enters attack trigger
		//This prevents the player from shooting enemies until they attack
		//canBeShot.canBeshot is always true for the player
		//Debug.Log (player.immumeFire);
		if (canBeShot.canBeShot) {
			if (tag == "Player" && !player.immumeFire) {
				GetComponent<PlayerMove> ().hurtSound.PlayOneShot (GetComponent<PlayerMove> ().hurtSound.clip);
				currentHealth -= damage;
				//TODO fix this
			} else if (tag == "Enemy") {
				currentHealth -= damage;	
			}

			//clap health for all object between 0 and maxHealth
			if (!easyMode) { //dont clamp easy mode
				currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
			} else {
				currentHealth = Mathf.Clamp (currentHealth, 0, easyMaxHealth);
			}
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


		}
	}
		

}