using UnityEngine;
using System.Collections.Generic;
using System;

/// Copyright 2016 On The Fringe Studios.
/// Author: Donald Perry
/// <summary>
/// A collection of notes representing a diatonic scale.
/// </summary>

public class Scale : CollectionOfNotes {
	int scaleSize;
	modes currentMode;
	interval upperTetraOffset;

	Tetrachord upperTetra;
	Tetrachord lowerTetra;

	Chord[] diatonicChords;
	Theory theory = new Theory();

	/// <summary>
	/// Initializes an A Major scale.
	/// </summary>
	public Scale() //TODO do something about these constructors dude.
	{
		Key = note.A;
		ModalKey = note.A;
		currentMode = modes.ionian;
		Name = note.A.ToString() + " " + scaleType.major.ToString ();
		AssignUpperAndLower (ScaleBook.allScales [scaleType.major]);
		upperTetraOffset = upperTetra.Offset;
		Intervals = CombineTetrachords(lowerTetra, upperTetra, upperTetraOffset);
		Notes = GenerateNotes (ModalKey, Intervals);
		scaleSize = Intervals.Length;
	}

	/// <summary>
	/// Initializes a scale by key and type.
	/// </summary>
	/// <param name="inKey">Desired Key</param>
	/// <param name="type">Desired Scale Type</param>
	public Scale(note inKey, scaleType type)
	{
		Key = inKey;
		ModalKey = inKey;
		currentMode = modes.ionian;
		Name = inKey.ToString() + " " + type.ToString ();
		AssignUpperAndLower (ScaleBook.allScales [type]);
		upperTetraOffset = upperTetra.Offset;
		Intervals = CombineTetrachords(lowerTetra, upperTetra, upperTetraOffset);
		Notes = GenerateNotes (Key, Intervals);
		scaleSize = Intervals.Length;
	}

	/// <summary>
	/// Initializes a scale by key and type, adds the id to name.
	/// </summary>
	/// <param name="inKey">Desired Key.</param>
	/// <param name="type">Desired Scale Type.</param>
	/// <param name="id">Identifier.</param>
	public Scale(note inKey, scaleType type, int id)
	{
		Key = inKey;
		ModalKey = inKey;
		currentMode = modes.ionian;
		Name = inKey.ToString () + " " + type.ToString () + " _" + id.ToString ();
		AssignUpperAndLower (ScaleBook.allScales [type]);
		upperTetraOffset = upperTetra.Offset;
		Intervals = CombineTetrachords(lowerTetra, upperTetra, upperTetraOffset);
		Notes = GenerateNotes (Key, Intervals);
		scaleSize = Intervals.Length;
	}

	public int ScaleSize
	{
		get{ return scaleSize; }
		set{ scaleSize = value;}
	}

	public Chord[] DiatonicChords
	{
		get { return diatonicChords; }
		set { diatonicChords = value; }
	}

	public modes CurrentMode
	{
		get { return currentMode; }
	}

	/// <summary>
	/// Changes the mode in place; does not transpose.
	/// </summary>
	/// <param name="newMode">DesiredMode</param>
	public void ChangeMode(modes newMode){ //TODO this should be in TheoryManager
		currentMode = newMode;
		Intervals = CombineTetrachords (lowerTetra, upperTetra, upperTetraOffset); //Reset the scale!!
		ModalKey = Key + (int)Intervals[(int)newMode];
		interval[] newIntervals = new interval[scaleSize];

		int offset;
		for (int i = 0; i < scaleSize; i++) {
			offset = i + (int) newMode;
			if (offset >= scaleSize) {
				offset -= scaleSize - 1;
			}
			newIntervals [i] = theory.AdjustForScale( Intervals [offset] - (int)Intervals[(int) newMode]);
		}

		newIntervals [newIntervals.Length - 1] = interval.octave; 

		Intervals = newIntervals;
		Notes = GenerateNotes (ModalKey, Intervals);
	}

	/// <summary>
	/// Parses the root intervals.
	/// </summary>
	/// <returns>The root chord.</returns>
	public interval[] ParseRootChord() //TODO make this generic?
	{
		int chordSize = 0;
		for (int i = 0; i < scaleSize; i++) {
			if (i % 2 == 0) {
				chordSize++;
			}
		}

		interval[] tempIntervals = new interval[chordSize];
		int intervalPosition = 0;
		for (int i = 0; i < scaleSize - 1; i++) {
			if (i % 2 == 0) {
				tempIntervals [intervalPosition] = Intervals [i];
				intervalPosition++;
			}
		}

		return tempIntervals;
	}

	/// <summary>
	/// Combines tetrachords into a fully qualified scale
	/// </summary>
	/// <returns>The tetrachords.</returns>
	/// <param name="lower">Lower.</param>
	/// <param name="upper">Upper.</param>
	/// <param name="upperOffset">The distance between lower.notes[0] and upper.notes[0]</param>
	interval[] CombineTetrachords(Tetrachord lower, Tetrachord upper, interval upperOffset)
	{
		interval[] tempIntervals = new interval[lowerTetra.Intervals.Length + upperTetra.Intervals.Length];

		for (int i = 0; i < tempIntervals.Length; i++) {
			int offset = i;
			if (offset < lowerTetra.Intervals.Length) {
				tempIntervals [offset] = lowerTetra.Intervals [offset];
			} else {
				offset = i - lowerTetra.Intervals.Length;
				tempIntervals [i] = theory.AdjustForScale (upperTetra.Intervals [offset] + (int)upperOffset);
			}
		}
		Debug.Log ("New Scale Size: " + tempIntervals.Length);
		return tempIntervals;
	}

	void AssignUpperAndLower(Tetrachord[] upperAndLower)
	{
		lowerTetra = upperAndLower [0];
		upperTetra = upperAndLower [1];
	}


	public void ListDiatonicChords()
	{
		foreach (Chord chord in diatonicChords) {
			Debug.Log (chord.ToString () + " " + chord.Type.ToString());
		}
	}

}