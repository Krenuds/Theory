using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Song {
	int totalVoices = 0;

	public int TotalVoices { 
		get{ return totalVoices; }
		set{ totalVoices = value; }
	}

	public LinkedList<Measure> measures;

	public Song()
	{
		measures = new LinkedList<Measure> ();
	}

	public void AddMeasure(Measure newMeasure)
	{
		measures.AddLast (newMeasure);
		foreach (Chord c in newMeasure.chords) {
			if (c.Intervals.Length > totalVoices) {
				totalVoices = c.Intervals.Length;
			}
			totalVoices++; //TODO add one for the melody.
		}
	}
}
