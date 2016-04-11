/// Copyright 2016 On The Fringe Studios.
/// Author: Donald Perry
/// <summary>
/// The base class for all scales, chords and tonal sets.
/// </summary>
/// 
/// Both Scale and Chord derive from this class. CollectionOfNotes serves two key purposes:
/// 1. It holds critical information about the tone set (ie name, spelling, intervals etc...)
/// 2. I generates the appropriate notes for the set with offsets appropriate for the 
/// 12 tone scale system.
/// 

public class CollectionOfNotes {
	string name;
	string spelling;

	note key;
	note modalKey;

	interval[] intervals;
	Note[] notes;



	int baseTonalOffset = 0;

	Theory theory = new Theory();

	//PUBLIC INTERFACE==============

	public int BaseTonalOffset
	{
		get { return baseTonalOffset; }
		set { baseTonalOffset = value; }
	}

	public string Name
	{
		get{ return name; }
		set{ name = value; }
	}

	public note ModalKey
	{
		get{ return modalKey; }
		set{ modalKey = value; }
	}

	public string Spelling
	{
		get{ return spelling; }
		set{ spelling = value; }
	}

	public interval[] Intervals
	{
		get{ return intervals; }
		set{ intervals = value; }
	}

	public Note[] Notes
	{
		get{ return notes;}
		set{ notes = value; }
	}

	public note Key
	{
		get{ return key; }
		set{ key = value; }
	}

	//Public member functions==============

	/// <summary>
	/// Generates note array adjusting for max range of intervals.
	/// </summary>
	/// <returns>Adjusted Notes</returns>
	/// <param name="_key">Base offset</param>
	/// <param name="_buildIntervals">Intervals to consier</param>
	public Note[] GenerateNotes(note _key, interval[] _buildIntervals) //TODO what really is an octave?
	{
		Note[] tempNotes = new Note[_buildIntervals.Length];
		for (int i = 0; i < _buildIntervals.Length; i++) {
			note adjustedForScale = theory.AdjustForScale (_key + (int)_buildIntervals [i]);
			tempNotes [i] = new Note(adjustedForScale, _buildIntervals[i] );
		}
		return tempNotes;
	}

	/// <summary>
	/// Returns a <see cref="System.String"/> that represents the current <see cref="CollectionOfNotes"/>.
	/// </summary>
	/// <returns>A <see cref="System.String"/> that represents the current <see cref="CollectionOfNotes"/>.</returns>
	public override string ToString ()
	{
		string tempNotes = "";
		for (int i = 0; i < notes.Length; i++) {
			tempNotes += notes [i].Val.ToString() + " ";
		}
		return tempNotes;
	}


	/// <summary>
	/// Returns a <see cref="System.String"/> of intervals
	/// </summary>
	/// <returns>String of intervals</returns>
	public string IntervalsToString ()
	{
		string tempIntervals = "";
		for (int i = 0; i < intervals.Length; i++) {
			tempIntervals += intervals [i].ToString () + " ";
		}
		return tempIntervals;
	}
}
