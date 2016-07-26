using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{

	public GameObject playerWin;
	static Timer instance = null;
	GUIStyle font;
	GUIStyle fontSmall;
	public float timer = 0;
	private Treasure win;
	private Scene scene;
	private bool failUITime = false;

	void Start ()
	{



		win = playerWin.GetComponent<Treasure> ();
		scene = SceneManager.GetActiveScene ();


		if (instance != null) {
			Destroy (gameObject);

		} else {
			instance = this;

			GameObject.DontDestroyOnLoad (gameObject);

		}

		font = new GUIStyle ();
		font.fontSize = 36;
		fontSmall = new GUIStyle ();
		fontSmall.fontSize = 20;
		fontSmall.normal.textColor = Color.white;
	}

	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.F)) {
			failUITime = true;

		}

		if (!win.playerWin) {
			timer += Time.deltaTime;
		}

	}

	void OnGUI ()
	{
		int minutes = Mathf.FloorToInt (timer / 60f);
		int seconds = Mathf.FloorToInt (timer - minutes * 60);
		string time = string.Format ("{0:00}:{1:00}", minutes, seconds);

		if (!win.playerWin && scene.name == "PlayerMoving") {
			//GUI.Label (new Rect (10, 10, 500, 200), "Game Timer :", guiStyle);
			//GUI.Label (new Rect (136, 10, 500, 200), time, guiStyle);
			GUI.Box (new Rect (10, 10, 125, 25), "Game Timer : " + time, fontSmall);
		} else if (win.playerWin && !failUITime) {
			GUI.Label (new Rect (709, 341, 125, 200), time, font);
			//Debug.Log (failUITime);
		} else if (win.playerWin && failUITime) {
			GUI.Label (new Rect (709, 341, 125, 200), time + " (Fail Mode)", font);

		}
	}
}
