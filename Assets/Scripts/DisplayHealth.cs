using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
	public Text healthText;
	public Killable killable;

	// Update is called once per frame
	void Update ()
	{
		healthText.text = "Health: " + killable.currentHealth;
	}
}
