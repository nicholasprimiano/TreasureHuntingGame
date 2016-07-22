﻿using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {







	private float timer = 0;
	void Update(){
		timer += Time.deltaTime;
	}

	private GUIStyle guiStyle = new GUIStyle();

	void OnGUI(){
		int minutes = Mathf.FloorToInt (timer / 60f);
		int seconds = Mathf.FloorToInt (timer - minutes * 60);
		string time = string.Format ("{0:00}:{1:00}", minutes, seconds);
		GUI.color = Color.black;
		guiStyle.fontSize = 20;
		GUI.Label (new Rect (10, 10, 500, 200), "Game Timer :", guiStyle);
		GUI.Label (new Rect (136, 10, 500, 200), time, guiStyle);
	}



			
}
