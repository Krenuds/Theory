using UnityEngine;
using System.Collections;

public class SongWriter : MonoBehaviour {
	
	public int measures = 4;
	public int chordsPerMeasure = 2;
	public int tempo = 120;
	public note key;
	public scaleType feeling;
	Song newSong;

	Measure workingMeasure;

	TheoryManager theoryMan;

	void Start () {
		workingMeasure = new Measure ();
		newSong = new Song ();
		GenerateSong (); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenerateSong()
	{
		theoryMan = new TheoryManager ();
		theoryMan.AddScale (key, feeling);
		Scale theoryScale = theoryMan.ManagedScale [0];
		theoryMan.CreateDiatonicChords (theoryScale);
		for (int i = 0; i < measures; i++) {
			GenerateChords (theoryScale);
			GenerateNotes (theoryScale);
			newSong.AddMeasure (workingMeasure);
			workingMeasure = null;
		}

	}

	void GenerateChords(Scale scale)
	{
		
		for (int i = 0 ; i < chordsPerMeasure ; i ++) {
			workingMeasure.chords.Add (scale.DiatonicChords[Random.Range(0,scale.DiatonicChords.Length - 1)]);
		}
	}

	void GenerateNotes(Scale scale)
	{
		for (int i = 0 ; i < chordsPerMeasure ; i ++) {
			workingMeasure.melody.Add (scale.Notes[Random.Range(0, scale.Notes.Length - 1)]);
		}
	}
}
