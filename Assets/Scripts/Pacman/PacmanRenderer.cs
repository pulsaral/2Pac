﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;

public class PacmanRenderer : MonoBehaviour {

	private PacmanData _Data;
	public PacmanData Data
	{
		get
		{
			if ( _Data == null )
			{
				_Data = GetComponent<PacmanData>();
			}
			return _Data;
		}
		private set { throw new NotImplementedException(); }
	}
	
	public BoardAccessor _Board;
	public BoardAccessor Board
	{
		get
		{
			if ( _Board == null )
			{
				_Board = GameObject.FindObjectOfType<BoardAccessor>();
			}
			return _Board;
		}
		private set {}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Board.convertToRenderPos( Data.boardLocation );
		this.transform.position = transform.position + new Vector3( 0, 0, -this.transform.localScale.x / 2 );
		IntVector2 direction = Data.direction;
		// rotate to face direction traveling 
		bool[] point = new bool[]{direction.x > 0, direction.y > 0, direction.x < 0, direction.y < 0 };
		for ( int i = 0; i < 4; i++ )
		{
			if ( point[i] )
			{
				transform.rotation = Quaternion.Euler( new Vector3(0, 0, i * 90 ));
			}
		}
		
		Animator a = (Animator) GetComponent( "Animator" );
		
		// if not moving turn off the animation
		// todo, animation does not exist anymore
		//a.enabled = BoardLocation.SqrDistance( Data.boardLocation, Data.lastBoardLocation ) > 0;
	}
}
