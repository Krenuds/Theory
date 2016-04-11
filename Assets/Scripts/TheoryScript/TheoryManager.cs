using System.Collections;
using System.Collections.Generic;

/// Copyright 2016 On The Fringe Studios.
/// Author: Donald Perry
/// <summary>
/// Manages all things theory.
/// </summary>
/// Other than handling theoretical operations, this class links scales and chords together with the 
/// frequency manager. This is crucial because scales and cords can only iterate about themselves.
/// TheoryManager uses a base offset and preformes operations to keep track of where all notes belong
/// in terms of their octave, or base offset from any starting point.

public class TheoryManager {
	int baseNoteOffset = 24;
	int transposeOffset;
	int scaleID;

	Theory theory;
	List<Scale> managedScales;

	public TheoryManager()
	{
		FrequencyManager.GenerateFrequencies(12);
		transposeOffset = baseNoteOffset;
		theory = new Theory ();
	}

	public List<Scale> ManagedScale
	{
		get { return managedScales; }
	}

	public int BaseNoteOffset
	{
		get{ return baseNoteOffset; }
		set { baseNoteOffset = value; }
	}

	public void AddScale (note key, scaleType type)
	{
		if (managedScales == null) {
			scaleID = 0;
			managedScales = new List<Scale>();
			managedScales.Add (new Scale (key, type, scaleID));
		} else {
			scaleID++;
			managedScales.Add (new Scale (key, type, scaleID));
		}

		foreach (Note n in managedScales[managedScales.Count - 1].Notes) {
			n.FrequencyKey += BaseNoteOffset;
		}
	}

	public void CreateDiatonicChords(Scale managedScale)
	{
		int size = managedScale.ScaleSize;
		managedScale.DiatonicChords = new Chord[size - 1];
		modes currentMode = modes.ionian;
		for (int i = 0; i < size - 1; i++) {
			managedScale.ChangeMode (currentMode);
			managedScale.DiatonicChords [i] = new Chord (managedScale.ModalKey, managedScale.ParseRootChord());
			currentMode++;
		}
	}

	public void TransposeInPlace(CollectionOfNotes originalSet ,interval interval, direction direction)
	{
		note key = originalSet.Key;
		//Note[] notes = originalSet.Notes;
		//interval[] intervals = originalSet.Intervals;

		if (direction == direction.sharp) {
			key += theory.AdjustForScale ((int)interval);
		} else {
			key -= theory.AdjustForScale ((int)interval);
		}
		//notes = originalSet.GenerateNotes (key, intervals);
		originalSet.ModalKey = key;
	}
		
	public void Transpose(Scale managedScale, interval transVal, direction dir )
	{
		transposeOffset +=  (int)transVal;
		TransposeInPlace (managedScale, transVal, dir);
		FrequencyManager.AssignFrequencyKeys (managedScale, transposeOffset);

	}

	public void ChangeScaleMode(Scale managedScale, modes newMode)
	{
		if (newMode > modes.locrian) {
			newMode = modes.ionian;
		}
		managedScale.ChangeMode (newMode);

		foreach (Note n in managedScale.Notes) {
			n.FrequencyKey += baseNoteOffset;
		}
	}
}
