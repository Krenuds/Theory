using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class Sequencer {

	MasterClock clock = Director.clock;
	List<int> straightSequence;
	List<int> swingSequence;
	Synthesizer targetSynth;
	int sequencePosition;
	bool playing;

	public Sequencer()
	{
		sequencePosition = 0;
		clock.PulseUpdated += OnPulseUpdated;
		clock.straightPulseUpdated += OnStraightUpdate;
		clock.swingPulseUpdated += OnSwingUpdate;
	}

	public Sequencer(Synthesizer owner)
	{
		targetSynth = owner;
		sequencePosition = 0;
		clock.PulseUpdated += OnPulseUpdated;
		clock.straightPulseUpdated += OnStraightUpdate;
		clock.swingPulseUpdated += OnSwingUpdate;
	}

	public Synthesizer TargetSynth
	{
		get { return targetSynth; }
		set { targetSynth = value;  }
	}

	public void AddSequence(Note[] notes)
	{
		if (straightSequence == null) {
			straightSequence = new List<int>();
			foreach (Note n in notes) {
				straightSequence.Add (n.FrequencyKey);
			}
		} else {
			foreach (Note n in notes) {
				straightSequence.Add (n.FrequencyKey);
			}
		}
	}

	public void OnPulseUpdated(object source, EventArgs args)
	{
		
	}

	public void OnStraightUpdate(object source, EventArgs args)
	{
		if (playing) {
			targetSynth.parameters.startFrequency = FrequencyManager.AllFreqs [(int)straightSequence [sequencePosition]];
			targetSynth.Play ();
			sequencePosition++;
			if (sequencePosition > 7) {
				sequencePosition = 0;
			}
		}
	}

	public void OnSwingUpdate(object source, EventArgs args)
	{
		Debug.Log ("Sequencer: Swing Message recieved.");
	}

	public void Start()
	{
		if (targetSynth != null) {
			playing = true;
		} else {
			targetSynth = new Synthesizer ();
		}
	}
}


