//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections.Generic;
namespace AssemblyCSharp
{
	public class InkyAI : GhostAI
	{
		private GhostMover _Blinky ;
		private GhostMover Blinky 
		{
			get
			{
				if ( _Blinky == null )
				{
					foreach ( GhostMover ghost in GameObject.FindObjectsOfType<GhostMover>() )
					{
						if ( ghost.Data.ghostNumber == 0 )
						{
							// that's blinky
							_Blinky = ghost;
							return _Blinky;
						}
					}
				}
				return _Blinky;
			}

		}

		public InkyAI ( PacmanData[] players, BoardAccessor Accessor, GhostData Data ) 
			: base( players, Accessor, Data )
		{


		}
		
		public override IntVector2 ComputeDirection( List<IntVector2> legalTurns, int maxSpeed )
		{
			if ( Blinky == null )
			{
				Debug.LogError( "Inky needs Blinky to work" );
				return new IntVector2( 0, 0 );
			}
			HashSet<IntVector2> targets = new HashSet<IntVector2>();
			foreach ( PacmanData player in Players )
			{
				IntVector2 pacFront = player.direction.Normalized() * 2 + player.boardLocation.location;
				IntVector2 blinkyLocation = Blinky.Data.boardLocation.location;

				IntVector2 fromBlinky = pacFront - blinkyLocation;
				fromBlinky *= 2;

				targets.Add( blinkyLocation + fromBlinky );
			}
			
			return base.ComputeDirectionToTargets( targets, legalTurns, maxSpeed );
		}
	}
}

