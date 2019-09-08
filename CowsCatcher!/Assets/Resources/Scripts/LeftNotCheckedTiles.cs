using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftNotCheckedTiles : MonoBehaviour
{
	public static Sprite notCheckedSprite;

	public static GameObject[] tiles;
	public static int children;

	public static int endCount = 1;

	// Start is called before the first frame update
	void Start()
	{
		notCheckedSprite = Resources.Load<Sprite>("Graphics/Floor");

		children = transform.childCount;
		tiles = new GameObject[children];
		for (int i = 0; i < children; ++i)
		{
			tiles[i] = transform.GetChild(i).gameObject;
		}
		//CheckAllChildren();
    }

	public static void CheckAllChildren()
	{
		endCount = 1;
		foreach (GameObject child in tiles)
		{
			if (child.transform.tag == "Checked")
			{
				endCount++;
			}
		}
		if (endCount == children)
		{
			GameControl.gameWon = true;
		}
		if (!GameControl.gameWon)
		{
			OverlapCheckAround.AnyPossibleMove();
		}
	}

	public static void CleanAllChildren()
	{
		foreach (GameObject child in tiles)
		{
			child.transform.tag = "NotChecked";
			child.GetComponent<SpriteRenderer>().sprite = notCheckedSprite;
			child.GetComponent<BoxCollider2D>().isTrigger = true;
		}
	}
}
