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
namespace AssemblyCSharp
{
	public class BoardLocation
	{
		public static readonly int cellRadius = 1000;
		
		public IntVector2 location {get; private set;}
		public IntVector2 offset {get; private set;}

		public BoardLocation( IntVector2 location, IntVector2 offset )
		{
			this.location = new IntVector2( location.x + offset.x / cellRadius, location.y + offset.y / cellRadius);
			this.offset = new IntVector2( offset.x % cellRadius, offset.y % cellRadius );
		}

		public BoardLocation Clone()
		{
			return new BoardLocation( location, offset );
		}


		public static int SqrDistance( BoardLocation a, BoardLocation b )
		{
			int xdiff = ( a.location.x * cellRadius + a.offset.x - b.location.x * cellRadius - b.offset.x );
			int ydiff = ( a.location.y * cellRadius + a.offset.y - b.location.y * cellRadius - b.offset.y );

			return xdiff * xdiff + ydiff * ydiff;
		}


	}
}

