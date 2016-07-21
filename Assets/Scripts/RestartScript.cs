using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class RestartScript : MonoBehaviour
{
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene ("PlayerMoving");
		}

	}
}
