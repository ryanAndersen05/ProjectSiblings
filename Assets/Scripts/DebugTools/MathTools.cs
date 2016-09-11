using UnityEngine;
using System.Collections;

public class MathTools {
    public static float[] NormalizeArray(float[] vector)
    {
        if (vector == null)
        {
            return null;
        }
        if (vector.Length <= 0)
        {
            return vector;
        }
        float sum = 0;
        foreach (float n in vector)
        {
            sum += Mathf.Pow(n, 2);
        }
        float mag = Mathf.Sqrt(sum);
        if (mag == 0)
        {
            Debug.Log("Vector sum equal to zero");
            return vector;
        }
        float[] normalizedVector = new float[vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            normalizedVector[i] = vector[i] / mag;
        }
        return normalizedVector;
    }

    public static float[] GetVectorOnes(int length)
    {
        if (length < 0)
        {
            return null;
        }
        float[] vector = new float[length];
        for (int i = 0; i < vector.Length; i++)
        {
            vector[i] = 1;
        }
        return vector;
    }
}
