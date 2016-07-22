using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
	public int damage;
	private bool canDamageMore = true;
	private float fireTick = .5f;
	private float tickPrevious = 0;

	void OnTriggerStay2D (Collider2D activator)
	{
		float deltaTime = Time.time - tickPrevious;
		if (tag == "Fire" && deltaTime >= fireTick) {
			canDamageMore = true;
		}

		if (activator.GetComponent<Killable> () != null && canDamageMore) {          
			activator.GetComponent<Killable> ().Hurt (damage);
			canDamageMore = false;
			tickPrevious = Time.time;
		}
		if (tag == "Bullet" && activator.tag == "Enemy")  { // Destroy Bullet on contact with spike prevent hitting two spikes
			Destroy (gameObject);
		}
			if (tag == "Enemy" && activator.tag == "Player")  { // Destroy Enemy on contact with player
			Destroy (gameObject);
		}


	}
}

