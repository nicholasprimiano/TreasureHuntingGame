using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowPlayerName : MonoBehaviour
{
	public Text playerNameUIText;

	// Use this for initialization
	void Start ()
	{
		PlayerName playerName = FindObjectOfType<PlayerName> ();
		playerNameUIText.text = playerName.nameReferance;
	}
}
