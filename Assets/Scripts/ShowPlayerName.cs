using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowPlayerName : MonoBehaviour
{
	public Text playerNameUIText;
	public PlayerName temp;

	// Use this for initialization
	void Start ()
	{
		PlayerName playerName = FindObjectOfType<PlayerName> ();
		if (playerName == null) {
			playerName = Instantiate (temp);
		}
		playerNameUIText.text = playerName.nameReferance;
	}
}
