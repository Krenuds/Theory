using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Measure {

	int numberOfVoices;
	Note[,]voicings;

	public int NumberOfVoices
	{
		get { return numberOfVoices; }
	}
	
	public List<Chord> chords;
	public List<Note> melody;

	public Measure()
	{
		
	}
	public Measure(List<Chord> newChords, List<Note> newMelody)
	{
		chords = newChords;
		melody = newMelody;
		SetNumberOfVoices ();
		voicings = new Note[numberOfVoices, newChords.Count];
	}

	void SetNumberOfVoices()
	{
		foreach (Chord c in chords) {
			if (c.Intervals.Length > numberOfVoices) {
				numberOfVoices = c.Intervals.Length;
			}
		}
		numberOfVoices++;
	}
		
}
