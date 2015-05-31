using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	// 24 x 12 dimension grid
	public static int w = 24;
	public static int h = 50;
	public static Transform[,] grid = new Transform[w, h];
	public static Transform[,] staticGrid = new Transform[w,h];

	public static Vector2 roundVec2(Vector2 v) { // rounding
		return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
	}

	public static bool insideBorder(Vector2 pos) { // detecting if something is in the grid or not
		return ((int)pos.x >= 0 && (int)pos.x < w && (int)pos.y >= 0);
	}

	public static void deleteRow(int y) { // block destroy loop in a row
		for (int x = 0; x < w; ++x) {
			if (grid [x, y] != null){
				Destroy(grid[x, y].gameObject);
				grid[x, y] = null;
			}
		}
	}

	public static void decreaseRow(int y) { // loop on row to move down
		for (int x = 0; x < w; ++x) {
			if (grid[x, y] != null) {
				// Move one towards bottom
				grid[x, y-1] = grid[x, y];
				grid[x, y] = null;
				// Update Block position
				grid[x, y-1].position += new Vector3(0, -1, 0);
			}
		}
	}

	public static void decreaseRowsAbove(int y) { // loop decreaseRow on all rows
		for (int i = y; i < h; ++i) {
			decreaseRow (i);
		}
	}

	public static bool isRowFull(int y) { // check if row is full and should be deleted
		for (int x = 0; x < w; ++x)
			if (grid [x, y] == null) { // if blank then the row definitely isn't full
				return false;
			}
		return true;
	}

	public static void deleteFullRows() { // ALL TOGETHER NOW
		for (int y = 0; y < h; ++y) {
			if (isRowFull(y)) {
				deleteRow(y);
				decreaseRowsAbove(y+1);
				--y;
			}
		}
	}
}