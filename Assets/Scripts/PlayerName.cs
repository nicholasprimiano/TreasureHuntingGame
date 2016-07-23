using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{

	static PlayerName instance = null;
	public Text playerName;
	public string nameReferance;
	public GameObject startButton;

	// Use this for initialization
	void Start ()
	{
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
		startButton.SetActive (false);
	}


	public void getText ()
	{
		nameReferance = playerName.text;
		Debug.Log (nameReferance);
		startButton.SetActive (true);
	}

}
