using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class Util
{
	public static float GetAngle(Vector3 vStart, Vector3 vEnd)
	{
		Vector3 v = vEnd - vStart;

		return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
	}

	public static float GetAngleByDirectionVector(Vector3 v)
	{
		return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
	}

	public static void ShuffleList<T>(this List<T> list)
	{
		for (int i = 0; i < list.Count; i++)
		{
			int RandomIndex = Random.Range(0, list.Count);
			T temp = list[RandomIndex];
			list[RandomIndex] = list[i];
			list[i] = temp;
		}
	}

	public static T[] ReverseArray<T>(this T[] array)
	{
		var newArray = new T[array.Length];
		int idx = array.Length - 1;
		for (int i = 0; i < array.Length; i++)
		{
			newArray[idx--] = array[i];
		}
		return newArray;
	}

	/// <summary>
	/// list에서 count개를 랜덤하게 뽑는다(중복없이)
	/// </summary>
	public static List<T> SampleList<T>(List<T> list, int count)
	{
		List<T> result = new List<T>(list);
		ShuffleList(result);
		result.RemoveRange(count, result.Count - count);
		return result;
	}

	public static void Swap<T>(ref T a, ref T b)
	{
		T temp = a;
		a = b;
		b = temp;
	}

	public static T GetRandomValue<T>() where T : Enum
	{
		Array AllValues = Enum.GetValues(typeof(T));
		return (T)AllValues.GetValue(Random.Range(0, AllValues.Length));
	}
}