using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	public Treasure win;
	static Timer instance = null;
	GUIStyle font;

	void Start ()
	{
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
		font = new GUIStyle ();
		font.fontSize = 40;
	}

	private float timer = 0;

	void Update ()
	{
		if (!win.playerWin) {
			timer += Time.deltaTime;
		}
	}

	void OnGUI ()
	{
		int minutes = Mathf.FloorToInt (timer / 60f);
		int seconds = Mathf.FloorToInt (timer - minutes * 60);
		string time = string.Format ("{0:00}:{1:00}", minutes, seconds);
		Debug.Log ("1");
		if (!win.playerWin) {
			//GUI.Label (new Rect (10, 10, 500, 200), "Game Timer :", guiStyle);
			//GUI.Label (new Rect (136, 10, 500, 200), time, guiStyle);
			GUI.Box (new Rect (10, 10, 125, 25), "Game Timer : " + time);
			Debug.Log ("2");
		} else {
			Debug.Log ("3");
			GUI.Label (new Rect (715, 338, 125, 200), time, font);
		}
	}
}
