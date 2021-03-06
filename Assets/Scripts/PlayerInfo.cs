﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInfo : Singleton<PlayerInfo> {

	public List<Player> players = new List<Player>();

	// Use this for initialization
	void Start () {
		
	}

	void Awake() {
		Messenger<NetworkPlayer, int>.AddListener(Events.PLAYER_CONNECTED, EventPlayerConnected);
		Messenger<int>.AddListener(Events.PLAYER_ID_SET, EventPlayerIDSet);
		Messenger<NetworkPlayer>.AddListener(Events.PLAYER_DISCONNECTED, EventPlayerDisconnected);
		Messenger<int, bool>.AddListener(Events.PLAYER_READY_CHANGED, EventPlayerReadyChanged);
	}

	int getConnectedPlayerCount() {
		return players.Count;
	}

	public void toggleCurrentPlayerReady() {
		Player myPlayer = GameProperties.myPlayer;
		myPlayer.ready = !myPlayer.ready;
		ServerComms.Instance.networkView.RPC("setPlayerReadyChanged", RPCMode.OthersBuffered, myPlayer.id, myPlayer.ready);
	}

	public Player getPlayerByID(int id) {
		foreach (Player player in players) {
			if (player.id == id) {
				return player;
			}
		}
		return null;
	}

	public int getNextPlayerID() {
		
		SortedList<int, int> ids = new SortedList<int,int>();
		for (int i = 1; i <= GameProperties.maxPlayers; i++) {
			ids.Add(i, i);
		}
		
		foreach (Player player in players) {
			ids.Remove(player.id);
		}
		return ids.Values[0];
	}

	public bool allPlayersReady() {

		foreach (Player player in players) {
			if (!player.ready) {
				return false;
			}
		}
		return true;
	}

	public Player getPlayerByNetworkPlayer(NetworkPlayer player) {
		foreach (Player p in players) {
			if (player.guid == p.networkPlayer.guid) {
				return p;
			}
		}
		return null;
	}

	public void setPlayerStatusToLoading() {
		foreach (Player player in players) {
			player.loading = true;
		}
	}

	public void setPlayerLoaded(int id) {
		getPlayerByID(id).loading = false;
	}

	public bool allPlayersLoaded() {
		foreach (Player player in players) {
			if (player.loading) {
				return false;
			}
		}
		return true;
	}

	public int numPlayersLoading() {
		int count = 0;
		foreach (Player player in players) {
			if (player.loading) {
				count++;
			}
		}
		return count;
	}

	public void clear() {
		players.Clear();
	}

	// ================================
	// ============ Events ============
	// ================================


	void EventPlayerConnected(NetworkPlayer player, int id) {
		Debug.Log("new player with id: " + id);
		players.Add(new Player(id, player));
	}
	
	void EventPlayerIDSet(int id) {
		Debug.Log("my id is: " + id);
		if (GameProperties.myPlayer == null) {
			GameProperties.myPlayer = new Player(id, Network.player);
			players.Add(GameProperties.myPlayer);
		} else {
			GameProperties.myPlayer.id = id;
			GameProperties.myPlayer.networkPlayer = Network.player;
		}
	}
	
	void EventPlayerDisconnected(NetworkPlayer player) {
		for (int i = 0; i < players.Count; i++) {
			if (players[i].networkPlayer.guid == player.guid) {
				players.RemoveAt(i);
			}
		}
	}
	
	private void EventPlayerReadyChanged(int id, bool ready) {
		Debug.Log("player [" + id + "] has set ready to: " + ready);
		for (int i = 0; i < players.Count; i++) {
			if (players[i].id == id) {
				players[i].ready = ready;
			}
		}
	}

	public class Player {
		public int id = -1;
		public NetworkPlayer networkPlayer;
		public bool ready = false;
		public bool loading = false;
		
		public Player(int id, NetworkPlayer networkPlayer) {
			this.id = id;
			this.networkPlayer = networkPlayer;
		}
	}
}
