using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
	
	public int damage = 1;

	//	void OnCollisionEnter2D (Collision coll){
	//		if (coll.gameObject.tag == "Enemy") {
	//			coll.GetComponent < Killable>().Hurt
	//		}
	//	}
	//



	// A function that is automatically called when
	// as long as a Rigidibody2D is in the tirgger, each fame
	void OnTriggerStay2D (Collider2D activator)
	{
		// Does the activating thing have a killable script on it
		if (activator.GetComponent<Killable> () != null) {          
			activator.GetComponent<Killable> ().Hurt (damage);
			// Destroy this object
			// Destroy (activator.gameObject);
		}    
	}
		


}

