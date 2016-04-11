/// Copyright 2016 On The Fringe Studios.
/// Author: Donald Perry

public enum tetraChordPosition
{
	lower,
	upper
}

/// <summary>
/// Scales are either major or minor
/// </summary>
public enum scaleType
{
	major,
	minor
}


public enum direction
{
	sharp,
	flat
}


public enum chordType
{
	majorTriad,
	minorTriad,
	diminishedTriad,

	dom7,
	major7,
	minor7,
	minor7b5,
	dimished7,

	major6,

	majorTetra,
	minorLowerTetra,
	minorUpperTetra
}

/// <summary>
/// Base movement unit
/// </summary>
public enum steps 
{
	half = 1,
	whole = 2
}

/// <summary>
/// Diatonic modes
/// </summary>
public enum modes
{
	ionian,
	dorian,
	phrygian,
	lydian,
	mixolydian,
	aeolian,
	locrian
}

/// <summary>
/// The distance between two notes
/// </summary>
public enum interval
{
	root,
	min2nd,
	maj2nd,
	min3rd,
	maj3rd,
	perf4th,
	dim5th,
	perf5th,
	min6th,
	maj6th,
	min7th,
	maj7th,
	octave
}


/// <summary>
/// Diatonic scale positions as roman numerals
/// </summary>
public enum diatonic{
	I,
	II,
	III,
	IV,
	v,
	VI,
	VII,
	VIII
}

public enum TypeOfNote // Just to help keep track of our next two arrays. 0 = sixteenthTrip etc...
{
	sixteenthTriplet,
	sixteenth,
	eighthTriplet,
	eighth,
	quarterTriplet,
	quarter,
	halfTriplet,
	half,
	wholeTriplet,
	whole
}

public enum Beat{
	whole,
	half,
	quarter,
	eighth,
	sixteenth,
	thirtysecond,
	sixtyfourth
}

public enum note 
{
	A,
	Bb,
	B,
	C,
	Db,
	D,
	Eb,
	E,
	F,
	Fs,
	G,
	Ab,
} 
