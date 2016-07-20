using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
	
	public int damage;
	// A function that is automatically called when
	// as long as a Rigidibody2D is in the tirgger, each fame
	void OnTriggerEnter2D (Collider2D activator)
	{
		// Does the activating thing have a killable script on it
		if (activator.GetComponent<Killable> () != null) {          
			activator.GetComponent<Killable> ().Hurt (damage);
		}   
	}
		


}

