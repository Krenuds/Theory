using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Every chord definition by type and interval set as an interval[].
/// 
/// </summary>

//TODO Complete these definitions.
public class ChordSpellings {
	
	public static Dictionary<chordType, interval[]> intervalsIn = new Dictionary<chordType, interval[]> //TODO is there a formula for this?
	{

		//Triads
		{chordType.majorTriad, 
			new interval[] {interval.root, interval.maj3rd, interval.perf5th}},
		
		{chordType.minorTriad, 
			new interval[] {interval.root, interval.min3rd, interval.perf5th}},

		{chordType.diminishedTriad, 
			new interval[] {interval.root, interval.min3rd, interval.dim5th}},

		//Seven Chords
		{chordType.dom7, 
			new interval[] {interval.root, interval.maj3rd, interval.perf5th, interval.min7th}},

		{chordType.major7, 
			new interval[] {interval.root, interval.maj3rd, interval.perf5th, interval.maj7th}},

		{chordType.minor7, 
			new interval[] {interval.root, interval.min3rd, interval.perf5th, interval.min7th}},

		{chordType.minor7b5, 
			new interval[] {interval.root, interval.min3rd, interval.dim5th, interval.min7th}},

		{chordType.dimished7, 
			new interval[] {interval.root, interval.min3rd, interval.dim5th, interval.maj6th}},

		//Six Chords
		{chordType.major6, 
			new interval[] {interval.root, interval.maj3rd, interval.perf5th, interval.maj6th}},

		//Tetra Chords
		{chordType.majorTetra, 
			new interval[] {interval.root, interval.maj2nd, interval.maj3rd, interval.perf4th}},
		
		{chordType.minorLowerTetra, 
			new interval[] {interval.root, interval.maj2nd, interval.min3rd, interval.perf4th}},
		
		{chordType.minorUpperTetra, 
			new interval[] {interval.root, interval.min2nd, interval.maj3rd, interval.perf4th}},
	};
}
