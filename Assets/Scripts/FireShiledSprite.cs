using UnityEngine;
using System.Collections;

public class FireShiledSprite : MonoBehaviour
{

	public PlayerMove playerMove;
	private bool playOnce = true;
	// Update is called once per frame
	void Update ()
	{
		SpriteRenderer spr = GetComponent<SpriteRenderer> ();
		if (playerMove.immumeFire) {
			spr.color = new Color (spr.color.r, spr.color.g, spr.color.b, 1f);
			AudioSource audio = GetComponent<AudioSource> ();
			if (playOnce) {
				audio.PlayOneShot (audio.clip);
				playOnce = false;
			}
		} else {
			playOnce = true;
			spr.color = new Color (spr.color.r, spr.color.g, spr.color.b, 0f);
		}

	}
}
