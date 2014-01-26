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
			int xdiff = ( a.location.x * Constants.BoardCellRadius + a.offset.x - b.location.x * Constants.BoardCellRadius - b.offset.x );
			int ydiff = ( a.location.y * Constants.BoardCellRadius + a.offset.y - b.location.y * Constants.BoardCellRadius - b.offset.y );

			return xdiff * xdiff + ydiff * ydiff;
		}


	}
}

