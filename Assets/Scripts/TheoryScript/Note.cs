using System.Collections;

/// Copyright 2016 On The Fringe Studios.
/// Author: Donald Perry
/// <summary>
/// The basic unit of music. A note is the product of tone & duration.
/// </summary>
/// Each note has a 

public class Note  {
	
	string name;
	note key;
	interval diatonicInterval;
	public bool isOctave;

	float frequency;
	int frequencyKey;
	int octave;

	Beat duration;

	private Theory theory = new Theory();

	/// <summary>
	/// Initializes a C note.
	/// </summary>
	public Note()
	{
		duration = Beat.quarter;
		name = note.C.ToString();
		key = note.C;
		octave = 2;
		frequencyKey = GetFrequencyKey (note.C, octave);
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Note"/> class.
	/// </summary>
	/// <param name="newNote">Desired Note</param>
	public Note(note newNote)
	{
		duration = Beat.quarter;
		key = newNote;
		octave = 0;
		name = newNote.ToString() + octave.ToString();
		frequencyKey = GetFrequencyKey (newNote, octave);
	}

	/// <summary>
	/// Initializes a new diatonic <see cref="Note"/>.
	/// </summary>
	/// <param name="newNote">Desired Note</param>
	/// <param name="currentDiatonicInterval">Position in scale</param>
	public Note(note newNote, interval currentDiatonicInterval)
	{
		duration = Beat.quarter;
		key = theory.AdjustForScale (key - (int)currentDiatonicInterval);
		octave = 0;
		name = newNote.ToString() + octave.ToString();

		diatonicInterval = currentDiatonicInterval;
		frequencyKey = GetFrequencyKey (currentDiatonicInterval);
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Note"/> class.
	/// </summary>
	/// <param name="newNote">New note.</param>
	/// <param name="newOctave">Desired Octave</param>
	public Note(note newNote, int newOctave)
	{
		duration = Beat.quarter;
		name = newNote.ToString() + newOctave.ToString();
		key = newNote;
		octave = newOctave;
		frequencyKey = GetFrequencyKey (newNote, octave);
	}


	public Beat Duration
	{
		get { return duration; }
		set { duration = value; }
	}

	public int Octave
	{
		get{ return octave; }
		set{ octave = value; }
	}

	public string Name
	{
		get { return name; }
		set { name = value; }
	}

	public note Val
	{
		get { return key ; }
		set { key = value; }
	}

	public int FrequencyKey
	{
		get { return frequencyKey ;}
		set { frequencyKey = value ;}
	}

	/// <summary>
	/// Gets the frequency key.
	/// </summary>
	/// <returns>The frequency key.</returns>
	/// <param name="newNote">The note.</param>
	/// <param name="newOctave">Octave offset.</param>
	int GetFrequencyKey(note newNote, int newOctave)
	{
		return (int) newNote + (octave * Theory.TOTAL_NOTES);
	}

	int GetFrequencyKey(interval intervalToGrab)
	{
		return (int) intervalToGrab + (octave * Theory.TOTAL_NOTES);
	}

	/// <summary>
	/// Flags the note as an octave.
	/// </summary>
	public void MakeOctave()
	{
		isOctave = true;
		frequencyKey += Theory.TOTAL_NOTES;
	}
}
