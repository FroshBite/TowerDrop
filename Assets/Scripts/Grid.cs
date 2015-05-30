using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	// The Grid itself
	public static int w = 24;
	public static int h = 12;
	public static Transform[,] grid = new Transform[w, h];
}