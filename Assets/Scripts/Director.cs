using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

	public static MasterClock clock;
	Synthesizer synth;
	TheoryManager manager;

	void Awake()
	{	
		manager = new TheoryManager ();
		FrequencyManager.GenerateFrequencies (12);
		clock = new MasterClock ();
		synth = new Synthesizer ();
	}

	void Start () {
		
	}
	void FixedUpdate()
	{
		//clock.Update ();
		if (Input.GetButtonDown ("Jump")) {
			
		}
	}

	void PlayScale()
	{
		manager.AddScale (note.A, scaleType.minor);
		synth.seq.AddSequence (manager.ManagedScale[0].Notes);
		synth.seq.Start ();
		clock.StartTime ();
	}
}