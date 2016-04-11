using UnityEngine;
using System.Collections;

public class Synthesizer : SfxrSynth {

	MasterClock clock = Director.clock;
	public Sequencer seq;

	public Synthesizer()
	{
		seq = new Sequencer (this);
		clock.tempo = 120;
		parameters.SetSettingsString ("2,.348,.01,.252,,.281,.015,1400,,,,,-.56,,,,-.56,,-.501,,.5938,,,,,1,,,.1,,,");
		Play ();
	}

	public MasterClock Clock {
		get { return clock; }
		set { clock = value; }
	}
}
