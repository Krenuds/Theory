using System.Collections;
using System.Collections.Generic;

/// Copyright 2016 On The Fringe Studios.
/// Author: Donald Perry
/// <summary>
/// A collection of notes that help define a scale.
/// </summary>
/// All major scales are comprised of two parts; an upper and lower tetrachord.

public class Tetrachord : CollectionOfNotes {
	
	chordType currentChordType;

	interval offset;

	/// <summary>
	/// Initializes a new major <see cref="Tetrachord"/>.
	/// </summary>
	public Tetrachord()
	{
		Name = chordType.majorTetra.ToString ();
		currentChordType = chordType.majorTetra;
		offset = interval.maj2nd;
		Intervals = ChordSpellings.intervalsIn[currentChordType];
	}

	/// <summary>
	/// Initializes a new <see cref="Tetrachord"/>.
	/// </summary>
	/// <param name="_chord">Desired Chord Type.</param>
	/// <param name="_offset">Desired offset if upper.</param>
	public Tetrachord(chordType desiredChordType, interval desiredOffset)
	{
		Name = desiredChordType.ToString ();
		currentChordType = desiredChordType;
		offset = desiredOffset;
		Intervals = ChordSpellings.intervalsIn[currentChordType];
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Tetrachord"/> class.
	/// </summary>
	/// <param name="desiredChordType">Desired chord type.</param>
	public Tetrachord(chordType desiredChordType)
	{
		//Debug.Log ("Lower Tetra ininialized");
		offset = interval.root;
		currentChordType = desiredChordType;
		//upper or lower
		Intervals = ChordSpellings.intervalsIn[desiredChordType];
	}

	public interval Offset
	{
		get{ return offset; }
		set{ offset = value; }
	}
}
