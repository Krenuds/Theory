using System.Collections.Generic;

/// Copyright 2016 On The Fringe Studios.
/// Author: Donald Perry
/// <summary>
/// The main helper class. Theory provides many useful tools for constructing musical structures.
/// </summary>

public class Theory {

	/// <summary>
	/// Western 12 tone system. Base 12 maths.
	/// </summary>
	public const int TOTAL_NOTES = 12;

	/// <summary>
	/// A list of note names and enharmonic equivalents if applicable.
	/// </summary>
	public List<string> listNoteNames = new List<string> { "A", "A#Bb", "B", "C", "C#Db", "D", "D#Eb", "E", "F", "F#Gb", "G", "G#Ab" }; //TODO how to tell?

	/// <summary>
	/// Adjusts for scale.
	/// </summary>
	/// <returns>The for scale.</returns>
	/// <param name="scalePosition">Scale position.</param>
	public int AdjustForScale(int scalePosition)
	{
		while (scalePosition > TOTAL_NOTES) {
			scalePosition -= TOTAL_NOTES;
		}
		while (scalePosition < 0) {
			scalePosition += TOTAL_NOTES;
		}
		return scalePosition;
	}

	/// <summary>
	/// Adjusts for scale.
	/// </summary>
	/// <returns>The for scale.</returns>
	/// <param name="scalePosition">Scale position.</param>
	/// <param name="size">Size.</param>
	public int AdjustForScale(int scalePosition, int size)
	{
		while (scalePosition > size) {
			scalePosition -= size;
		}
		while (scalePosition < 0) {
			scalePosition += size;
		}
		return scalePosition;
	}

	/// <summary>
	/// Adjusts for scale.
	/// </summary>
	/// <returns>The for scale.</returns>
	/// <param name="scalePosition">Scale position.</param>
	public note AdjustForScale(note scalePosition)
	{
		while (scalePosition >= (note)TOTAL_NOTES) {
			scalePosition -= TOTAL_NOTES;
		}
		while (scalePosition < 0) {
			scalePosition += TOTAL_NOTES;
		}
		return scalePosition;
	}

	/// <summary>
	/// Adjusts for scale.
	/// </summary>
	/// <returns>The for scale.</returns>
	/// <param name="scalePosition">Scale position.</param>
	public interval AdjustForScale(interval scalePosition)
	{
		while (scalePosition > (interval)TOTAL_NOTES) {
			scalePosition -= TOTAL_NOTES ;
		}
		while (scalePosition < 0) {
			scalePosition += TOTAL_NOTES;
		}
		return scalePosition;
	}
}