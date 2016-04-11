	using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A unique definition of each scale type by type and tetrachord set as a <see cref="Tetrachord"/>[].
/// 
/// </summary>

public class ScaleBook 
{
	//TODO what about trichords?
	//TODO better way to factor in the interval.offset? Should be whole step, right?
	public static Dictionary<scaleType, Tetrachord[]> allScales = new Dictionary<scaleType, Tetrachord[]> { 
		{scaleType.major, new Tetrachord[] 
			{
				new Tetrachord (chordType.majorTetra),
				//Upper chord requires an offset interval major is perfect 5th (ie.. C --> G == perf5th)
				new Tetrachord (chordType.majorTetra, interval.perf5th)
			}
		},
		{scaleType.minor, new Tetrachord[] 
			{
				new Tetrachord (chordType.minorLowerTetra),
				//Upper chord requires an offset interval major is perfect 5th (ie.. C --> G == perf5th)
				new Tetrachord (chordType.minorUpperTetra, interval.perf5th)
			}
		}
	};
}
