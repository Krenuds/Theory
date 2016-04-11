using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jukebox {
	public List<Song> songs { get; set;}
	public List<Synthesizer> synths = new List<Synthesizer>();

	public Jukebox () {

	}

	public void AddSong(Song newSong)
	{
		songs.Add (newSong);
	}

	public void Play(Song song)
	{
		GenerateSynthesizers (song.TotalVoices);
		//StartSong ();
	}

	public void GenerateSynthesizers(int synthsRequired)
	{
		while (synthsRequired > 0) {
			synths.Add (new Synthesizer ());
			synthsRequired--;
		}
	}
}

