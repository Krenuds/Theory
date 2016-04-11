using UnityEngine;
using System.Collections.Generic;

public class SfxrParams {

    Dictionary<string, float> all = new Dictionary<string, float>()
    { 
        {"_masterVolume" , 0.5f},
        {"_attackTime", 0.0f},
        {"_sustainTime", 0.0f},
        {"_sustainPunch", 0.0f},
        {"_decayTime", 0.0f},

        {"_startFrequency", 0.0f},
        {"_minFrequency", 0.0f},

        {"_slide", 0.0f},
        {"_deltaSlide", 0.0f},

        {"_vibratoDepth", 0.0f},
        {"_vibratoSpeed", 0.0f},

        {"_changeAmount", 0.0f},
        {"_changeSpeed", 0.0f},

        {"_squareDuty", 0.0f},
        {"_dutySweep", 0.0f},

        {"_repeatSpeed", 0.0f},

        {"_phaserOffset", 0.0f},
        {"_phaserSweep", 0.0f},

        {"_lpFilterCutoff", 0.0f},
        {"_lpFilterCutoffSweep", 0.0f},
        {"_lpFilterResonance", 0.0f},

        {"_hpFilterCutoff", 0.0f},
        {"_hpFilterCutoffSweep", 0.0f },

        // From BFXR
        {"_changeRepeat", 0.0f},
        {"_changeAmount2", 0.0f},
        {"_changeSpeed2", 0.0f},

        {"_compressionAmount", 0.0f},

        {"_overtones", 0.0f},
        {"_overtoneFalloff", 0.0f},

        {"_bitCrush", 0.0f},
        {"_bitCrushSweep", 0.0f}
    };

    public bool paramsDirty;                    // Whether the parameters have been changed since last time (shouldn't used cached sound)

    private uint _waveType;


    // ================================================================================================================
    // ACCESSOR INTERFACE ---------------------------------------------------------------------------------------------



    /** Shape of the wave (0:square, 1:sawtooth, 2:sin, 3:noise) */
    public uint waveType {
		get { return _waveType; }
		set { _waveType = value > 8 ? 0 : value; paramsDirty = true; }
	}

	/** Overall volume of the sound (0 to 1) */
	public float masterVolume {
		get { return all["_masterVolume"]; }
		set { all["_masterVolume"] = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Length of the volume envelope attack (0 to 1) */
	public float attackTime {
		get { return all["_attackTime"]; }
		set { all["_attackTime"] = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Length of the volume envelope sustain (0 to 1) */
	public float sustainTime {
		get { return all["_sustainTime"]; }
		set { all["_sustainTime"] = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Tilts the sustain envelope for more 'pop' (0 to 1) */
	public float sustainPunch {
		get { return all["_sustainPunch"]; }
		set { all["_sustainPunch"] = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Length of the volume envelope decay (yes, I know it's called release) (0 to 1) */
	public float decayTime {
		get { return all["_decayTime"]; }
		set { all["_decayTime"] = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Base note of the sound (0 to 1) */
	public float startFrequency {
		get { return all["_startFrequency"]; }
		set { all["_startFrequency"] = Mathf.Clamp(value, 20, 20000); paramsDirty = true; }
	}

	/** If sliding, the sound will stop at this frequency, to prevent really low notes (0 to 1) */
	public float minFrequency {
		get { return all["_minFrequency"]; }
		set { all["_minFrequency"] = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Slides the note up or down (-1 to 1) */
	public float slide {
		get { return all["_slide"]; }
		set { all["_slide"] = Mathf.Clamp(value, -1, 1); paramsDirty = true; }
	}

	/** Accelerates the slide (-1 to 1) */
	public float deltaSlide {
		get { return all["_deltaSlide"]; }
		set { all["_deltaSlide"] = Mathf.Clamp(value, -1, 1); paramsDirty = true; }
	}

	/** Strength of the vibrato effect (0 to 1) */
	public float vibratoDepth {
		get { return all["_vibratoDepth"]; }
		set { all["_vibratoDepth"] = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Speed of the vibrato effect (i.e. frequency) (0 to 1) */
	public float vibratoSpeed {
		get { return all["_vibratoSpeed"]; }
		set { all["_vibratoSpeed"] = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Shift in note, either up or down (-1 to 1) */
	public float changeAmount {
		get { return all["_vibratoSpeed"]; }
		set { all["_vibratoSpeed"] = Mathf.Clamp(value, -1, 1); paramsDirty = true; }
	}

	/** How fast the note shift happens (only happens once) (0 to 1) */
	public float changeSpeed {
		get { return all["_changeSpeed"]; }
		set { all["_changeSpeed"] = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Controls the ratio between the up and down states of the square wave, changing the tibre (0 to 1) */
	public float squareDuty {
		get { return all["_squareDuty"] ; }
		set { all["_squareDuty"]  = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Sweeps the duty up or down (-1 to 1) */
	public float dutySweep {
		get { return all["_dutySweep"]; }
		set { all["_dutySweep"] = Mathf.Clamp(value, -1, 1); paramsDirty = true; }
	}

	/** Speed of the note repeating - certain variables are reset each time (0 to 1) */
	public float repeatSpeed {
		get { return all["_repeatSpeed"]; }
		set { all["_repeatSpeed"] = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Offsets a second copy of the wave by a small phase, changing the tibre (-1 to 1) */
	public float phaserOffset {
		get { return all["_phaserOffset"]; }
		set { all["_phaserOffset"] = Mathf.Clamp(value, -1, 1); paramsDirty = true; }
	}

	/** Sweeps the phase up or down (-1 to 1) */
	public float phaserSweep {
		get { return all["_phaserSweep"]; }
		set { all["_phaserSweep"] = Mathf.Clamp(value, -1, 1); paramsDirty = true; }
	}

	/** Frequency at which the low-pass filter starts attenuating higher frequencies (0 to 1) */
	public float lpFilterCutoff {
		get { return all["_lpFilterCutoff"]; }
		set { all["_lpFilterCutoff"] = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Sweeps the low-pass cutoff up or down (-1 to 1) */
	public float lpFilterCutoffSweep {
		get { return all["_lpFilterCutoffSweep"] ; }
		set { all["_lpFilterCutoffSweep"]  = Mathf.Clamp(value, -1, 1); paramsDirty = true; }
	}

	/** Changes the attenuation rate for the low-pass filter, changing the timbre (0 to 1) */
	public float lpFilterResonance {
		get { return all["_lpFilterResonance"] ; }
		set { all["_lpFilterResonance"]  = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Frequency at which the high-pass filter starts attenuating lower frequencies (0 to 1) */
	public float hpFilterCutoff {
		get { return all["_hpFilterCutoff"] ; }
		set { all["_hpFilterCutoff"]  = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Sweeps the high-pass cutoff up or down (-1 to 1) */
	public float hpFilterCutoffSweep {
		get { return all["_hpFilterCutoffSweep"] ; }
		set { all["_hpFilterCutoffSweep"]  = Mathf.Clamp(value, -1, 1); paramsDirty = true; }
	}

	// From BFXR

	/** Pitch Jump Repeat Speed: larger Values means more pitch jumps, which can be useful for arpeggiation (0 to 1) */
	public float changeRepeat {
		get { return all["_changeRepeat"] ; }
		set { all["_changeRepeat"]  = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Shift in note, either up or down (-1 to 1) */
	public float changeAmount2 {
		get { return all["_changeAmount2"] ; }
		set { all["_changeAmount2"]  = Mathf.Clamp(value, -1, 1); paramsDirty = true; }
	}

	/** How fast the note shift happens (only happens once) (0 to 1) */
	public float changeSpeed2 {
		get { return all["_changeSpeed2"]; }
		set { all["_changeSpeed2"] = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Pushes amplitudes together into a narrower range to make them stand out more. Very good for sound effects, where you want them to stick out against background music (0 to 1) */
	public float compressionAmount {
		get { return all["_compressionAmount"] ; }
		set { all["_compressionAmount"]  = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Harmonics: overlays copies of the waveform with copies and multiples of its frequency. Good for bulking out or otherwise enriching the texture of the sounds (warning: this is the number 1 cause of bfxr slowdown!) (0 to 1) */
	public float overtones {
		get { return all["_overtones"] ; }
		set { all["_overtones"]  = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Harmonics falloff: The rate at which higher overtones should decay (0 to 1) */
	public float overtoneFalloff {
		get { return all["_overtoneFalloff"] ; }
		set { all["_overtoneFalloff"]  = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Bit crush: resamples the audio at a lower frequency (0 to 1) */
	public float bitCrush {
		get { return all["_bitCrush"] ; }
		set { all["_bitCrush"]  = Mathf.Clamp(value, 0, 1); paramsDirty = true; }
	}

	/** Bit crush sweep: sweeps the Bit Crush filter up or down (-1 to 1) */
	public float bitCrushSweep {
		get { return all["_bitCrushSweep"] ; }
		set { all["_bitCrushSweep"]  = Mathf.Clamp(value, -1, 1); paramsDirty = true; }
	}

    public Dictionary<string, float> ALL {
        get { return all; }

        set { all = value; }
    }


    // ================================================================================================================
    // PUBLIC INTERFACE -----------------------------------------------------------------------------------------------

    // Generator methods

    /**
	 * Sets the parameters to generate a pickup/coin sound
	 */
    public void GeneratePickupCoin() {
		resetParams();

		all["_startFrequency"] = 0.4f + GetRandom() * 0.5f;

		all["_sustainTime"] = GetRandom() * 0.1f;
		all["_decayTime"] = 0.1f + GetRandom() * 0.4f;
		all["_sustainPunch"] = 0.3f + GetRandom() * 0.3f;

		if (GetRandomBool()) {
			all["_changeSpeed"] = 0.5f + GetRandom() * 0.2f;
			int cnum = (int)(GetRandom()*7f) + 1;
			int cden = cnum + (int)(GetRandom()*7f) + 2;
			all["_vibratoSpeed"] = (float)cnum / (float)cden;
		}
	}

	/**
	 * Sets the parameters to generate a laser/shoot sound
	 */
	public void GenerateLaserShoot() {
		resetParams();

		_waveType = (uint)(GetRandom() * 3);
		if (_waveType == 2 && GetRandomBool()) _waveType = (uint)(GetRandom() * 2f);

		all["_startFrequency"] = 0.5f + GetRandom() * 0.5f;
		all["_minFrequency"] = all["_startFrequency"] - 0.2f - GetRandom() * 0.6f;
		if (all["_minFrequency"] < 0.2f) all["_minFrequency"] = 0.2f;

		all["_slide"] = -0.15f - GetRandom() * 0.2f;

		if (GetRandom() < 0.33f) {
			all["_startFrequency"] = 0.3f + GetRandom() * 0.6f;
			all["_minFrequency"] = GetRandom() * 0.1f;
			all["_slide"] = -0.35f - GetRandom() * 0.3f;
		}

		if (GetRandomBool()) {
			all["_squareDuty"]  = GetRandom() * 0.5f;
			all["_dutySweep"] = GetRandom() * 0.2f;
		} else {
			all["_squareDuty"]  = 0.4f + GetRandom() * 0.5f;
			all["_dutySweep"] = -GetRandom() * 0.7f;
		}

		all["_sustainTime"] = 0.1f + GetRandom() * 0.2f;
		all["_decayTime"] = GetRandom() * 0.4f;
		if (GetRandomBool()) all["_sustainPunch"] = GetRandom() * 0.3f;

		if (GetRandom() < 0.33f) {
			all["_phaserOffset"] = GetRandom() * 0.2f;
			all["_phaserSweep"] = -GetRandom() * 0.2f;
		}

		if (GetRandomBool()) all["_hpFilterCutoff"]  = GetRandom() * 0.3f;
	}

	/**
	 * Sets the parameters to generate an explosion sound
	 */
	public void GenerateExplosion() {
		resetParams();

		_waveType = 3;

		if (GetRandomBool()) {
			all["_startFrequency"] = 0.1f + GetRandom() * 0.4f;
			all["_slide"] = -0.1f + GetRandom() * 0.4f;
		} else {
			all["_startFrequency"] = 0.2f + GetRandom() * 0.7f;
			all["_slide"] = -0.2f - GetRandom() * 0.2f;
		}

		all["_startFrequency"] *= all["_startFrequency"];

		if (GetRandom() < 0.2f) all["_slide"] = 0.0f;
		if (GetRandom() < 0.33f) all["_repeatSpeed"] = 0.3f + GetRandom() * 0.5f;

		all["_sustainTime"] = 0.1f + GetRandom() * 0.3f;
		all["_decayTime"] = GetRandom() * 0.5f;
		all["_sustainPunch"] = 0.2f + GetRandom() * 0.6f;

		if (GetRandomBool()) {
			all["_phaserOffset"] = -0.3f + GetRandom() * 0.9f;
			all["_phaserSweep"] = -GetRandom() * 0.3f;
		}

		if (GetRandom() < 0.33f) {
			all["_changeSpeed"] = 0.6f + GetRandom() * 0.3f;
			all["_vibratoSpeed"] = 0.8f - GetRandom() * 1.6f;
		}
	}

	/**
	 * Sets the parameters to generate a powerup sound
	 */
	public void GeneratePowerup() {
		resetParams();

		if (GetRandomBool()) {
			_waveType = 1;
		} else {
			all["_squareDuty"]  = GetRandom() * 0.6f;
		}

		if (GetRandomBool()) {
			all["_startFrequency"] = 0.2f + GetRandom() * 0.3f;
			all["_slide"] = 0.1f + GetRandom() * 0.4f;
			all["_repeatSpeed"] = 0.4f + GetRandom() * 0.4f;
		} else {
			all["_startFrequency"] = 0.2f + GetRandom() * 0.3f;
			all["_slide"] = 0.05f + GetRandom() * 0.2f;

			if (GetRandomBool()) {
				all["_vibratoDepth"] = GetRandom() * 0.7f;
				all["_vibratoSpeed"] = GetRandom() * 0.6f;
			}
		}

		all["_sustainTime"] = GetRandom() * 0.4f;
		all["_decayTime"] = 0.1f + GetRandom() * 0.4f;
	}

	/**
	 * Sets the parameters to generate a hit/hurt sound
	 */
	public void GenerateHitHurt() {
		resetParams();

		_waveType = (uint)(GetRandom() * 3f);
		if (_waveType == 2) {
			_waveType = 3;
		} else if (_waveType == 0) {
			all["_squareDuty"]  = GetRandom() * 0.6f;
		}

		all["_startFrequency"] = 0.2f + GetRandom() * 0.6f;
		all["_slide"] = -0.3f - GetRandom() * 0.4f;

		all["_sustainTime"] = GetRandom() * 0.1f;
		all["_decayTime"] = 0.1f + GetRandom() * 0.2f;

		if (GetRandomBool()) all["_hpFilterCutoff"]  = GetRandom() * 0.3f;
	}

	/**
	 * Sets the parameters to generate a jump sound
	 */
	public void GenerateJump() {
		resetParams();

		_waveType = 0;
		all["_squareDuty"]  = GetRandom() * 0.6f;
		all["_startFrequency"] = 0.3f + GetRandom() * 0.3f;
		all["_slide"] = 0.1f + GetRandom() * 0.2f;

		all["_sustainTime"] = 0.1f + GetRandom() * 0.3f;
		all["_decayTime"] = 0.1f + GetRandom() * 0.2f;

		if (GetRandomBool()) all["_hpFilterCutoff"]  = GetRandom() * 0.3f;
		if (GetRandomBool()) all["_lpFilterCutoff"] = 1.0f - GetRandom() * 0.6f;
	}

	/**
	 * Sets the parameters to generate a blip/select sound
	 */
	public void GenerateBlipSelect() {
		resetParams();

		_waveType = (uint)(GetRandom() * 2f);
		if (_waveType == 0) all["_squareDuty"]  = GetRandom() * 0.6f;

		all["_startFrequency"] = 0.2f + GetRandom() * 0.4f;

		all["_sustainTime"] = 0.1f + GetRandom() * 0.1f;
		all["_decayTime"] = GetRandom() * 0.2f;
		all["_hpFilterCutoff"]  = 0.1f;
	}

	/**
	 * Resets the parameters, used at the start of each generate function
	 */
	public void resetParams() {
		paramsDirty = true;

		_waveType = 0;
		all["_startFrequency"]			= 0.3f;
		all["_minFrequency"]			= 0.0f;
		all["_slide"]					= 0.0f;
		all["_deltaSlide"]				= 0.0f;
		all["_squareDuty"] 				= 0.0f;
		all["_dutySweep"]				= 0.0f;

		all["_vibratoDepth"]			= 0.0f;
		all["_vibratoSpeed"]			= 0.0f;

		all["_attackTime"]				= 0.0f;
		all["_sustainTime"]			= 0.3f;
		all["_decayTime"]				= 0.4f;
		all["_sustainPunch"]			= 0.0f;

		all["_lpFilterResonance"] 		= 0.0f;
		all["_lpFilterCutoff"]		= 1.0f;
		all["_lpFilterCutoffSweep"] 	= 0.0f;
		all["_hpFilterCutoff"] 			= 0.0f;
		all["_hpFilterCutoffSweep"] 	= 0.0f;

		all["_phaserOffset"]			= 0.0f;
		all["_phaserSweep"]			= 0.0f;

		all["_repeatSpeed"]			= 0.0f;

		all["_changeSpeed"]			= 0.0f;
		all["_vibratoSpeed"]			= 0.0f;

		// From BFXR
		all["_changeRepeat"] 			= 0.0f;
		all["_changeAmount2"] 			= 0.0f;
		all["_changeSpeed2"]			= 0.0f;

		all["_compressionAmount"] 		= 0.3f;

		all["_overtones"] 				= 0.0f;
		all["_overtoneFalloff"] 		= 0.0f;

		all["_bitCrush"] 				= 0.0f;
		all["_bitCrushSweep"] 			= 0.0f;
	}


	// Randomization methods

	/**
	 * Randomly adjusts the parameters ever so slightly
	 */
	public void Mutate(float __mutation = 0.05f) {
		if (GetRandomBool()) startFrequency			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) minFrequency			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) slide					+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) deltaSlide				+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) squareDuty				+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) dutySweep				+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) vibratoDepth			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) vibratoSpeed			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) attackTime				+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) sustainTime			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) decayTime				+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) sustainPunch			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) lpFilterCutoff			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) lpFilterCutoffSweep	+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) lpFilterResonance		+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) hpFilterCutoff			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) hpFilterCutoffSweep	+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) phaserOffset			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) phaserSweep			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) repeatSpeed			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) changeSpeed			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) changeAmount			+= GetRandom() * __mutation * 2f - __mutation;

		// From BFXR
		if (GetRandomBool()) changeRepeat			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) changeAmount2			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) changeSpeed2			+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) compressionAmount		+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) overtones				+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) overtoneFalloff		+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) bitCrush				+= GetRandom() * __mutation * 2f - __mutation;
		if (GetRandomBool()) bitCrushSweep			+= GetRandom() * __mutation * 2f - __mutation;
	}

	/**
	 * Sets all parameters to random values
	 */
	public void Randomize() {
		resetParams();

		_waveType = (uint)(GetRandom() * 9f);

		all["_attackTime"]				= Pow(GetRandom() * 2f - 1f, 4);
		all["_sustainTime"]			= Pow(GetRandom() * 2f - 1f, 2);
		all["_sustainPunch"]			= Pow(GetRandom() * 0.8f, 2);
		all["_decayTime"]				= GetRandom();

		all["_startFrequency"]			= (GetRandomBool()) ? Pow(GetRandom() * 2f - 1f, 2) : (Pow(GetRandom() * 0.5f, 3) + 0.5f);
		all["_minFrequency"]			= 0.0f;

		all["_slide"]					= Pow(GetRandom() * 2f - 1f, 3);
		all["_deltaSlide"]				= Pow(GetRandom() * 2f - 1f, 3);

		all["_vibratoDepth"]			= Pow(GetRandom() * 2f - 1f, 3);
		all["_vibratoSpeed"]			= GetRandom() * 2f - 1f;

		all["_vibratoSpeed"]			= GetRandom() * 2f - 1f;
		all["_changeSpeed"]			= GetRandom() * 2f - 1f;

		all["_squareDuty"] 				= GetRandom() * 2f - 1f;
		all["_dutySweep"]				= Pow(GetRandom() * 2f - 1f, 3);

		all["_repeatSpeed"]			= GetRandom() * 2f - 1f;

		all["_phaserOffset"]			= Pow(GetRandom() * 2f - 1f, 3);
		all["_phaserSweep"]			= Pow(GetRandom() * 2f - 1f, 3);

		all["_lpFilterCutoff"]			= 1f - Pow(GetRandom(), 3);
		all["_lpFilterCutoffSweep"] 	= Pow(GetRandom() * 2f - 1f, 3);
		all["_lpFilterResonance"] 		= GetRandom() * 2f - 1f;

		all["_hpFilterCutoff"] 			= Pow(GetRandom(), 5);
		all["_hpFilterCutoffSweep"] 	= Pow(GetRandom() * 2f - 1f, 5);

		if (all["_attackTime"] + all["_sustainTime"] + all["_decayTime"] < 0.2f) {
			all["_sustainTime"]		= 0.2f + GetRandom() * 0.3f;
			all["_decayTime"]			= 0.2f + GetRandom() * 0.3f;
		}

		if ((all["_startFrequency"] > 0.7f && all["_slide"] > 0.2) || (all["_startFrequency"] < 0.2 && all["_slide"] < -0.05)) {
			all["_slide"]				= -all["_slide"];
		}

		if (all["_lpFilterCutoff"] < 0.1f && all["_lpFilterCutoffSweep"]  < -0.05f) {
			all["_lpFilterCutoffSweep"]  = -all["_lpFilterCutoffSweep"] ;
		}

		// From BFXR
		all["_changeRepeat"] 			= GetRandom();
		all["_changeAmount2"] 			= GetRandom() * 2f - 1f;
		all["_changeSpeed2"] 			= GetRandom();

		all["_compressionAmount"] 		= GetRandom();

		all["_overtones"] 				= GetRandom();
		all["_overtoneFalloff"] 		= GetRandom();

		all["_bitCrush"] 				= GetRandom();
		all["_bitCrushSweep"] 			= GetRandom() * 2f - 1f;
	}


	// Setting string methods

	/**
	 * Returns a string representation of the parameters for copy/paste sharing in the old format (24 parameters, SFXR/AS3SFXR compatible)
	 * @return	A comma-delimited list of parameter values
	 */
	public string GetSettingsStringLegacy() {
		string str = "";

		// 24 params

		str += waveType.ToString() + ",";
		str += To4DP(all["_attackTime"]) + ",";
		str += To4DP(all["_sustainTime"]) + ",";
		str += To4DP(all["_sustainPunch"]) + ",";
		str += To4DP(all["_decayTime"]) + ",";
		str += To4DP(all["_startFrequency"]) + ",";
		str += To4DP(all["_minFrequency"]) + ",";
		str += To4DP(all["_slide"]) + ",";
		str += To4DP(all["_deltaSlide"]) + ",";
		str += To4DP(all["_vibratoDepth"]) + ",";
		str += To4DP(all["_vibratoSpeed"]) + ",";
		str += To4DP(all["_vibratoSpeed"]) + ",";
		str += To4DP(all["_changeSpeed"]) + ",";
		str += To4DP(all["_squareDuty"] ) + ",";
		str += To4DP(all["_dutySweep"]) + ",";
		str += To4DP(all["_repeatSpeed"]) + ",";
		str += To4DP(all["_phaserOffset"]) + ",";
		str += To4DP(all["_phaserSweep"]) + ",";
		str += To4DP(all["_lpFilterCutoff"] ) + ",";
		str += To4DP(all["_lpFilterCutoffSweep"] ) + ",";
		str += To4DP(all["_lpFilterResonance"] ) + ",";
		str += To4DP(all["_hpFilterCutoff"] ) + ",";
		str += To4DP(all["_hpFilterCutoffSweep"] ) + ",";
		str += To4DP(all["_masterVolume"]);

		return str;
	}

	/**
	 * Returns a string representation of the parameters for copy/paste sharing in the new format (32 parameters, BFXR compatible)
	 * @return	A comma-delimited list of parameter values
	 */
	public string GetSettingsString() {
		string str = "";

		// 32 params

		str += waveType.ToString() + ",";
		str += To4DP(all["_masterVolume"]) + ",";
		str += To4DP(all["_attackTime"]) + ",";
		str += To4DP(all["_sustainTime"]) + ",";
		str += To4DP(all["_sustainPunch"]) + ",";
		str += To4DP(all["_decayTime"]) + ",";
		str += To4DP(all["_compressionAmount"] ) + ",";
		str += To4DP(all["_startFrequency"]) + ",";
		str += To4DP(all["_minFrequency"]) + ",";
		str += To4DP(all["_slide"]) + ",";
		str += To4DP(all["_deltaSlide"]) + ",";
		str += To4DP(all["_vibratoDepth"]) + ",";
		str += To4DP(all["_vibratoSpeed"]) + ",";
		str += To4DP(all["_overtones"] ) + ",";
		str += To4DP(all["_overtoneFalloff"] ) + ",";
		str += To4DP(all["_changeRepeat"] ) + ","; // all["_changeRepeat"] ?
		str += To4DP(all["_vibratoSpeed"]) + ",";
		str += To4DP(all["_changeSpeed"]) + ",";
		str += To4DP(all["_changeAmount2"] ) + ","; // changeamount2
		str += To4DP(all["_changeSpeed2"] ) + ","; // changespeed2
		str += To4DP(all["_squareDuty"] ) + ",";
		str += To4DP(all["_dutySweep"]) + ",";
		str += To4DP(all["_repeatSpeed"]) + ",";
		str += To4DP(all["_phaserOffset"]) + ",";
		str += To4DP(all["_phaserSweep"]) + ",";
		str += To4DP(all["_lpFilterCutoff"] ) + ",";
		str += To4DP(all["_lpFilterCutoffSweep"] ) + ",";
		str += To4DP(all["_lpFilterResonance"] ) + ",";
		str += To4DP(all["_hpFilterCutoff"] ) + ",";
		str += To4DP(all["_hpFilterCutoffSweep"] ) + ",";
		str += To4DP(all["_bitCrush"] ) + ",";
		str += To4DP(all["_bitCrushSweep"] );

		return str;
	}

	/**
	 * Parses a settings string into the parameters
	 * @param	string	Settings string to parse
	 * @return			If the string successfully parsed
	 */
	public bool SetSettingsString(string __string) {
		string[] values = __string.Split(new char[] { ',' });

		if (values.Length == 24) {
			// Old format (SFXR): 24 parameters
			resetParams();

			waveType = 				ParseUint(values[0]);
			attackTime =  			ParseFloat(values[1]);
			sustainTime =  			ParseFloat(values[2]);
			sustainPunch =  		ParseFloat(values[3]);
			decayTime =  			ParseFloat(values[4]);
			startFrequency =  		ParseFloat(values[5]);
			minFrequency =  		ParseFloat(values[6]);
			slide =  				ParseFloat(values[7]);
			deltaSlide =  			ParseFloat(values[8]);
			vibratoDepth =  		ParseFloat(values[9]);
			vibratoSpeed =  		ParseFloat(values[10]);
			changeAmount =  		ParseFloat(values[11]);
			changeSpeed =  			ParseFloat(values[12]);
			squareDuty =  			ParseFloat(values[13]);
			dutySweep =  			ParseFloat(values[14]);
			repeatSpeed =  			ParseFloat(values[15]);
			phaserOffset =  		ParseFloat(values[16]);
			phaserSweep =  			ParseFloat(values[17]);
			lpFilterCutoff =  		ParseFloat(values[18]);
			lpFilterCutoffSweep =	ParseFloat(values[19]);
			lpFilterResonance =  	ParseFloat(values[20]);
			hpFilterCutoff =  		ParseFloat(values[21]);
			hpFilterCutoffSweep =	ParseFloat(values[22]);
			masterVolume = 			ParseFloat(values[23]);
		} else if (values.Length >= 32) {
			// New format (BFXR): 32 parameters (or more, but locked parameters are ignored)
			resetParams();

			waveType				= ParseUint(values[0]);
			masterVolume			= ParseFloat(values[1]);
			attackTime				= ParseFloat(values[2]);
			sustainTime				= ParseFloat(values[3]);
			sustainPunch			= ParseFloat(values[4]);
			decayTime				= ParseFloat(values[5]);
			compressionAmount		= ParseFloat(values[6]);
			startFrequency			= ParseFloat(values[7]);
			minFrequency			= ParseFloat(values[8]);
			slide					= ParseFloat(values[9]);
			deltaSlide				= ParseFloat(values[10]);
			vibratoDepth			= ParseFloat(values[11]);
			vibratoSpeed			= ParseFloat(values[12]);
			overtones				= ParseFloat(values[13]);
			overtoneFalloff			= ParseFloat(values[14]);
			changeRepeat			= ParseFloat(values[15]);
			changeAmount			= ParseFloat(values[16]);
			changeSpeed				= ParseFloat(values[17]);
			changeAmount2			= ParseFloat(values[18]);
			changeSpeed2			= ParseFloat(values[19]);
			squareDuty				= ParseFloat(values[20]);
			dutySweep				= ParseFloat(values[21]);
			repeatSpeed				= ParseFloat(values[22]);
			phaserOffset			= ParseFloat(values[23]);
			phaserSweep				= ParseFloat(values[24]);
			lpFilterCutoff			= ParseFloat(values[25]);
			lpFilterCutoffSweep		= ParseFloat(values[26]);
			lpFilterResonance		= ParseFloat(values[27]);
			hpFilterCutoff			= ParseFloat(values[28]);
			hpFilterCutoffSweep		= ParseFloat(values[29]);
			bitCrush				= ParseFloat(values[30]);
			bitCrushSweep			= ParseFloat(values[31]);
		} else {
			Debug.LogError("Could not paste settings string: parameters contain " + values.Length + " values (was expecting 24 or >32)");
			return false;
		}

		return true;
	}


	// Copying methods

	/**
	 * Returns a copy of this SfxrParams with all settings duplicated
	 * @return	A copy of this SfxrParams
	 */
	public SfxrParams Clone() {
		SfxrParams outp = new SfxrParams();
		outp.CopyFrom(this);

		return outp;
	}

	/**
	 * Copies parameters from another instance
	 * @param	params	Instance to copy parameters from
	 */
	public void CopyFrom(SfxrParams __params, bool __makeDirty = false) {
		bool wasDirty = paramsDirty;
		SetSettingsString(GetSettingsString());
		paramsDirty = wasDirty || __makeDirty;
	}


	// Utility methods

	/**
	 * Faster power function; this function takes about 36% of the time Mathf.Pow() would take in our use cases
	 * @param	base		Base to raise to power
	 * @param	power		Power to raise base by
	 * @return				The calculated power
	 */
	private float Pow(float __pbase, int __power) {
		switch(__power) {
			case 2: return __pbase * __pbase;
			case 3: return __pbase * __pbase * __pbase;
			case 4: return __pbase * __pbase * __pbase * __pbase;
			case 5: return __pbase * __pbase * __pbase * __pbase * __pbase;
		}

		return 1f;
	}


	// ================================================================================================================
	// INTERNAL INTERFACE ---------------------------------------------------------------------------------------------

	/**
	 * Returns the number as a string to 4 decimal places
	 * @param	value	Number to convert
	 * @return			Number to 4dp as a string
	 */
	public string To4DP(float __value) {
		if (__value < 0.0001f && __value > -0.0001f) return "";
		return __value.ToString("#.####");
	}

	/**
	 * Parses a string into an uint value; also returns 0 if the string is empty, rather than an error
	 */
	public uint ParseUint(string __value) {
		if (__value.Length == 0) return 0;
		return uint.Parse(__value);
	}

	/**
	 * Parses a string into a float value; also returns 0 if the string is empty, rather than an error
	 */
	public float ParseFloat(string __value) {
		if (__value.Length == 0) return 0;
		return float.Parse(__value);
	}

	/**
	 * Returns a random value: 0 <= n < 1
	 * This function is needed so we can follow the original code more strictly; Unity's Random.value returns 0 <= n <= 1
	 */
	private float GetRandom() {
		return UnityEngine.Random.value % 1;
	}

	/**
	 * Returns a boolean value
	 */
	private bool GetRandomBool() {
		return UnityEngine.Random.value > 0.5f;
	}
}