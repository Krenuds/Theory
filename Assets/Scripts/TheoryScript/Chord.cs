using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// Copyright 2016 On The Fringe Studios.
/// Author: Donald Perry
/// <summary>
/// A collection of notes representing chords, trichords and tetrachords.
/// </summary>

public class Chord : CollectionOfNotes {

	diatonic scaleWisePosition;
	chordType type;


	/// <summary>
	/// Initializes a new instance of the <see cref="Chord"/> class.
	/// </summary>
	public Chord()
	{
		Key = note.C;
		Name = note.C.ToString() + " " + chordType.majorTriad.ToString ();
		Intervals = ChordSpellings.intervalsIn[chordType.majorTriad];
		Notes = GenerateNotes (Key, Intervals);
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Chord"/> class.
	/// </summary>
	/// <param name="newKey">Desired Key</param>
	/// <param name="newType">Desired Scale Type</param>
	public Chord(note newKey, chordType newType)
	{
		Key = newKey;
		Name = newKey.ToString() + " " + type.ToString ();
		Intervals = ChordSpellings.intervalsIn[type];
		Notes = GenerateNotes (newKey, Intervals);
	}

	/// <summary>
	/// Builds a chord from intervals.
	/// </summary>
	/// <param name="newKey">Desired Key</param>
	/// <param name="newIntervals">Predefined intervals</param>
	public Chord(note newKey, interval[] newIntervals)
	{
		foreach ( KeyValuePair<chordType, interval[]> kvp in ChordSpellings.intervalsIn) {
			if (Enumerable.SequenceEqual(kvp.Value, newIntervals)) {
				type = kvp.Key;
				break;
			}
		}
		Intervals = newIntervals;
		Key = newKey;
		Notes = GenerateNotes (Key, Intervals);

	}

	/// <summary>
	/// Gets the chord type
	public chordType Type 
	{
		get{ return type; }
	}

	/// <summary>
	/// A list of chord type names. Probably bullshit.
	public List<string> typeNames = new List<string>{
		"Major Triad",
		"Minor Triad",
		"Diminished Triad",

		"Dominant 7th",
		"Major 7th",
		"Minor 7th",
		"Minor 7th b5",
		"Diminished 7th",

		"Major 6th",

		"Major Tetra-Chord"
	};
}