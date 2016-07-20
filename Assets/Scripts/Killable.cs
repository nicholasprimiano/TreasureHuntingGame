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
		if (canBeShot.canBeShot) {
			//Debug.Log ("Taking Damage");
			currentHealth -= damage;
			currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
			//TODO add damge sound
			if (currentHealth <= 0) {
				if (tag == "Enemy") {
					AudioSource audio = GetComponent<AudioSource> ();
					audio.Play ();
					damage = 0;
					turnoff ();
				} else if (tag == "Player") {
					SceneManager.LoadScene ("Death Screen");
				}
			}
		}
	}

	private SpriteRenderer spredner;

	void turnoff ()
	{
		spredner = GetComponent <SpriteRenderer> ();
		spredner.color = new Color (0, 0, 0, 0);
	}


}