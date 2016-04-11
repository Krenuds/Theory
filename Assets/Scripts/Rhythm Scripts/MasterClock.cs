using UnityEngine;
using System.Collections;
using System;
using System.Threading;
/// <summary>
/// Master clock.
/// Author: Don Perry
/// </summary>
public class MasterClock
 {
	Thread updateThread;

	public delegate void MasterPulseEventHandler (object source, EventArgs e);
	public event MasterPulseEventHandler PulseUpdated;

	protected virtual void OnPulseUpdated()
	{
		if (PulseUpdated != null) {
			PulseUpdated (this, EventArgs.Empty);
		}
	}

	public delegate void StraightPulseEventHandler (object source, EventArgs e);
	public event StraightPulseEventHandler straightPulseUpdated;

	protected virtual void OnStraightUpdated()
	{
		if (straightPulseUpdated != null) {
			straightPulseUpdated (this, EventArgs.Empty);
		}
	}

	public delegate void SwingPulseEventHandler (object source, EventArgs e);
	public event SwingPulseEventHandler swingPulseUpdated;

	protected virtual void OnSwingUpdated()
	{
		if (swingPulseUpdated != null) {
			swingPulseUpdated (this, EventArgs.Empty);
		}
	}

	[System.NonSerialized]
	public int tempo = 60; //Integer generally added as a measure / 4
	
	private float _tickTime = 0.0f;
	private float _lastTick = 0.0f;
	
	private float _masterPulse;
	private float _minute = 60;
	
	private float _time = 0.000f; //Our composite time. The Unity clock stops for no man! But _time does.
	private float _stopTimeStamp = 0;
	private float _startTimeStamp;
	public static bool clockIsRunning;

	private byte _straightTick = 0;
	private byte _swingTick = 0;
	

	/// <summary>
	/// The measure triggers. These fuckers will fire off when they are supposed to.
	/// All sequencers in the game will look to some point in this array.
	/// </summary>
	public bool[] measureTriggers = new bool[10];
	public int[] measureCounter = new int[10]; 

	
	public float _Time
	{
		get{return _time;}
	}


	public void Update () //Boiler Plate
	{
		if(clockIsRunning) 
		{
			CalculateTime();
			ShutDownAllTriggers();
			GeneratePulses(_masterPulse);
		}			
	}
	/// <summary>
	/// Calculates the composite time.
	/// </summary>
	private void CalculateTime()
	{
		_time = (Time.time - _startTimeStamp) + _stopTimeStamp;
	}
	
	void GeneratePulses(float _pulse)
	{
		_tickTime = (_time - _lastTick);
		if(_tickTime >= _pulse)
		{
			UpdateMeasure();
			_tickTime = 0.0f;
			_lastTick = _time;
		}
	}
	
	void UpdateMeasure()
	{
		_swingTick++;
		_straightTick++;

		
		
		if(_swingTick == 2)
		{
			_swingTick = 0;
			UpdateSwingTicks();
			OnSwingUpdated ();
		}
			
		if(_straightTick  == 3)
		{
			_straightTick = 0;
			UpdateStraightTicks();
			OnStraightUpdated ();
		}
			
	}
	void ShutDownAllTriggers()
	{
		for (int _note = 0; _note < measureTriggers.Length; _note++)
		{
			measureTriggers[_note] = false;
		}
	}
	
	void UpdateSwingTicks()
	{
		measureCounter[(int)TypeOfNote.sixteenthTriplet] ++;
		measureTriggers[(int)TypeOfNote.sixteenthTriplet] = true;

		if (measureCounter[(int)TypeOfNote.sixteenthTriplet] == 2) 
			UpdateNextNote(TypeOfNote.eighthTriplet);
		
		if (measureCounter[(int)TypeOfNote.eighthTriplet] == 2)	
			UpdateNextNote(TypeOfNote.quarterTriplet);
		
		if (measureCounter[(int)TypeOfNote.quarterTriplet] == 2)
			UpdateNextNote(TypeOfNote.halfTriplet);
		
		if (measureCounter[(int)TypeOfNote.halfTriplet] == 2)
			UpdateNextNote(TypeOfNote.wholeTriplet);		
	}	
		
	void UpdateStraightTicks()
	{		
		measureCounter[(int)TypeOfNote.sixteenth] ++;
		measureTriggers[(int)TypeOfNote.sixteenth] = true;
		
		if(measureCounter[(int)TypeOfNote.sixteenth] == 2)
			UpdateNextNote(TypeOfNote.eighth);
		
		if (measureCounter[(int)TypeOfNote.eighth] == 2)
			UpdateNextNote(TypeOfNote.quarter);
		
		if (measureCounter[(int)TypeOfNote.quarter] == 2)
			UpdateNextNote(TypeOfNote.half);
		
		if (measureCounter[(int)TypeOfNote.half] == 2)
			UpdateNextNote(TypeOfNote.whole);

	}	
	
	void UpdateNextNote(TypeOfNote note)
	{
			measureTriggers[(int)note] = true;
			measureCounter[(int)note]++;
			measureCounter[(int)note - 2] = 0;
	}

	public void StartTime()
	{
		if(!clockIsRunning)
		{
			_masterPulse = _minute / ((float) tempo * 12);
			_startTimeStamp = Time.time;
			clockIsRunning = true;
			Debug.Log ("Clock started");
		}		
	}
	
	public void StopTime()
	{
		_stopTimeStamp = _time;
		clockIsRunning = false;		
	}
	
	public void ResetTime()
	{
		_time = 0.0000f;
		_stopTimeStamp = 0;
		clockIsRunning = false;		
	}
}