using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth = 0;

	// Use this for initialization
	void Start ()
	{
		// everyone starts with 100% health at the beginning of the game
		currentHealth = maxHealth;
	}

	//Public so death trigger can talk to it
	public void Hurt (int damage)
	{
		currentHealth -= damage;
		currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);

		if (currentHealth <= 0) {
			Destroy (gameObject);
		}

		Debug.Log (currentHealth);
	}
}