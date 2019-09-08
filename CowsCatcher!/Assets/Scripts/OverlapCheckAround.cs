using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapCheckAround : MonoBehaviour
{
	public static Transform tr;

	public static GameObject[] tile;

	public static int deadEndCount;

    // Update is called once per frame
    void Start()
    {
		tr = GetComponent<Transform>();
		tr.localPosition = new Vector2(0, 0);
    }

	public static void AnyPossibleMove()
	{
		deadEndCount = 0;
		for (int i = 0; i < 4; i++)
		{
			if (i < 2)
			{
				if (i == 0) { CheckAlready(1,0); }
				if (i == 1) { CheckAlready(-1, 0); }
			}
			if (i >= 2)
			{
				if (i == 2) { CheckAlready(0, 1); }
				if (i == 3) { CheckAlready(0, -1); }
			}
			
		}
	}

	public static void CheckAlready(float x, float y)
	{
		tr.localPosition = new Vector2(x, y);
		Vector2 dir = new Vector2(x, y);
		RaycastHit2D ray = Physics2D.Raycast(tr.position, dir);

		if (ray.collider.tag == "Checked" || ray.collider.tag == "Wall")
		{
			deadEndCount++;
		}
		if (deadEndCount == 4)
		{
			GameControl.gameOver = true;
			Debug.Log("Game Over!");
		}
	}
}
