//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool. :( I'm not a tool...
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;

namespace AssemblyCSharp
{
	public class IntVector2
	{
		public int x {get; private set;}
		public int y {get; private set;}
		public IntVector2 (int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public override int GetHashCode ()
		{
			// 6571 is a "big" prime
			return x * 6571 + y;
		}

		public override bool Equals (object obj)
		{
			IntVector2 o = obj as IntVector2;
			if ( o != null && o.x == x && o.y == y ) return true;
			return base.Equals( obj );
		}
		
		public static IntVector2 operator +( IntVector2 a, IntVector2 b )
		{
			return new IntVector2( a.x + b.x, a.y + b.y );
		}
		
		public static IntVector2 operator -( IntVector2 a, IntVector2 b )
		{
			return new IntVector2( a.x - b.x, a.y - b.y );
		}
		
		public static IntVector2 operator *( int a, IntVector2 b )
		{
			return new IntVector2( b.x * a, b.y * a );
		}

		public static IntVector2 operator *(  IntVector2 b, int a )
		{
			return a * b;
		}
		
		public void Normalize( )
		{
			if ( x != 0 )
			{
				x = Math.Sign( x );
				y = 0;
			}
			else if ( y != 0 )
			{
				y = Math.Sign( y );
				x = 0;
			}
		}
		
		
		public IntVector2 Normalized( )
		{
			IntVector2 result = this.Clone();
			result.Normalize();
			return result;
		}

		public IntVector2 Clone()
		{
			return new IntVector2( x, y );
		}

		// assumes a writing stream
		public void Serialize( BitStream stream )
		{
			int x = this.x;
			int y = this.y;
			stream.Serialize( ref x );
			stream.Serialize( ref y );
		}
		
		// assumes a reading stream
		public void DeSerialize( BitStream stream )
		{
			int x = 0;
			int y = 0;
			stream.Serialize( ref x );
			stream.Serialize( ref y );
			this.x = x;
			this.y = y;
		}
		
		public string ToString() 
		{
			return "( " + x + ", " + y + " )" ;
		}
	}
}

