﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerInfo playerInfo = PlayerInfo.Instance;
	}

	void OnGUI() {

		if (GUI.Button(new Rect(100, 100, 250, 100), "Single Player")) {
			GetComponent<SinglePlayer>().enabled = true;
			this.enabled = false;
		}

		if (GUI.Button(new Rect(100, 300, 250, 100), "Online Multiplayer")) {
			GetComponent<MultiplayerLobby>().enabled = true;
			this.enabled = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
