using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Treasure : MonoBehaviour
{

	//bool didPlayerWin = false;
	public Text textbuffer;
	public Transform PlayerObject;
	public Transform Hint1;
	public Transform Hint2;
	public Transform Hint3;
	public Transform Hint4;
	public Transform Treasure1;

	// Update is called once per frame
	void Update ()
	{

		textbuffer.text = "Treasure is waiting for you somewhere";

		if ((PlayerObject.position - Hint1.position).magnitude < 20f) {
			textbuffer.text = "Sorry, not the right place.";
		} else if ((PlayerObject.position - Hint2.position).magnitude < 20f) {
			textbuffer.text = "Haha you are fooled.";
		} else if ((PlayerObject.position - Hint3.position).magnitude < 20f) {
			textbuffer.text = "I am sure you can get there if you choose a different path....";
		} else if ((PlayerObject.position - Hint4.position).magnitude < 20f) {
			textbuffer.text = "Almost, almost!.";
		} else if ((PlayerObject.position - Treasure1.position).magnitude < 15f) {
			textbuffer.text = "Press [SPACE] to get treasure";
			if (Input.GetKeyDown (KeyCode.Space)) {
				SceneManager.LoadScene ("Win Screen");
			}
		}
	}
}
