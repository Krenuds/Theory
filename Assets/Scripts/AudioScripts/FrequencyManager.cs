using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class FrequencyManager {
    static double baseAlg = 1.059463094359;
    static int numOctaves = 9;
	static float A1 = 55;
	static float[] allFreqs;

	public static void GenerateFrequencies()
    {
		allFreqs = new float[Theory.TOTAL_NOTES * numOctaves];
        allFreqs[0] = A1;
        for (int i = 1; i < allFreqs.Length; i++)
        {
            allFreqs[i] = Mathf.Round(A1 * Mathf.Pow((float)baseAlg, (float)i + 1.0f));
        }
    }

	public static void GenerateFrequencies(int octaves)
	{
		allFreqs = new float[Theory.TOTAL_NOTES * octaves];
		allFreqs[0] = A1;
		for (int i = 1; i < allFreqs.Length; i++)
		{
			allFreqs[i] = Mathf.Round(A1 * Mathf.Pow((float)baseAlg, (float)i + 1.0f));
		}
	}

	public static void AssignFrequencyKeys(CollectionOfNotes structure, int offset)
	{
		foreach (Note n in structure.Notes) {
			n.FrequencyKey += offset;
		}
	}

	public static float[] AllFreqs
	{
		get {return allFreqs; }
	}
}
