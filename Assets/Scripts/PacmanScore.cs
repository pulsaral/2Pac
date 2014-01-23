﻿using UnityEngine;
using System.Collections;

public class PacmanScore : MonoBehaviour {

	public float score = 0;
	public GameObject textPrefab;
	private GUIText text;

	// Use this for initialization
	void Start () {
		// players score
		GameObject playerText = (GameObject) Instantiate( textPrefab, new Vector3(0,0,0) , Quaternion.identity );
		text = (GUIText) playerText.GetComponent("GUIText");
	}

	public void decrementScore(int num) {
		score -= num;
	}

	public void incrementScore(int num) {
		score += num;
	}

	void PacmanHit() {
		decrementScore(10);
	}

	// Update is called once per frame
	void Update () {
		score += (.1f * Time.deltaTime );
		updateScoreText();
	}

	private void updateScoreText() {
		int playerNum = ((PacmanAnimate)GetComponent("PacmanAnimate")).playerNum;
		text.transform.position = new Vector3( 0, 1 - .1f * playerNum, 0 ); 
		text.text = "Player " + playerNum + ": " + (int)score;
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		float syncScore = 0;
		if (stream.isWriting)
		{
			syncScore = score;
			stream.Serialize(ref syncScore);
		}
		else
		{
			stream.Serialize(ref syncScore);
			score = syncScore;
		}
	}
}