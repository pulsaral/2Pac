//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System;
using System.Collections;
using AssemblyCSharp;
namespace AssemblyCSharp
{
	public class BoardLocation 
	{
		
		public IntVector2 location {get; private set;}
		public IntVector2 offset {get; private set;}

		public BoardLocation( IntVector2 location, IntVector2 offset )
		{
			this.location = location.Clone();
			int offx = offset.x;
			int offy = offset.y;
			int locx = location.x;
			int locy = location.y;
			while ( offx > 1000 )
			{
				locx++;
				offx -= Constants.BoardCellDiameter;
			}
			while ( offx <= -1000 )
			{
				locx--;
				offx += Constants.BoardCellDiameter;
			}
			while ( offy > 1000 )
			{
				locy++;
				offy -= Constants.BoardCellDiameter;
			}
			while ( offy <= -1000 )
			{
				locy--;
				offy += Constants.BoardCellDiameter;
			}
			this.location = new IntVector2( locx, locy );
			this.offset = new IntVector2( offx, offy );
		}

		public BoardLocation Clone()
		{
			return new BoardLocation( location, offset );
		}


		public static int SqrDistance( BoardLocation a, BoardLocation b )
		{
			int xdiff = ( a.location.x * Constants.BoardCellDiameter + a.offset.x - b.location.x * Constants.BoardCellDiameter - b.offset.x );
			int ydiff = ( a.location.y * Constants.BoardCellDiameter + a.offset.y - b.location.y * Constants.BoardCellDiameter - b.offset.y );

			return xdiff * xdiff + ydiff * ydiff;
		}
		public static int OrthogonalDistance( BoardLocation a, BoardLocation b )
		{
			int xdiff = Math.Abs( a.location.x * Constants.BoardCellDiameter + a.offset.x - b.location.x * Constants.BoardCellDiameter - b.offset.x );
			int ydiff = Math.Abs( a.location.y * Constants.BoardCellDiameter + a.offset.y - b.location.y * Constants.BoardCellDiameter - b.offset.y );

			return xdiff + ydiff;
		}

		public static IntVector2 operator -( BoardLocation a, BoardLocation b )
		{
			int xdiff = ( a.location.x - b.location.x ) * Constants.BoardCellDiameter;
			int ydiff = ( a.location.y - b.location.y ) * Constants.BoardCellDiameter;
			
			xdiff += ( a.offset.x - b.offset.x );
			ydiff += ( a.offset.y - b.offset.y );

			return new IntVector2( xdiff, ydiff );
		}

		// assumes a writing stream
		public void Serialize( BitStream stream )
		{
			location.Serialize( stream );
			offset.Serialize( stream );
		}
		
		// assumes a reading stream
		public void DeSerialize( BitStream stream )
		{
			location.DeSerialize( stream );
			offset.DeSerialize( stream );
		}

		public override string ToString() 
		{
			return "" + location.ToString() + " " + offset.ToString();
		}

		public override int GetHashCode ()
		{
			return location.GetHashCode() * offset.GetHashCode();
		}

		public override bool Equals (object obj)
		{
			BoardLocation o = obj as BoardLocation;
			if (o == null) return base.Equals( o );

			return location.Equals(o.location) && offset.Equals(o.offset);
		}
	}
}

