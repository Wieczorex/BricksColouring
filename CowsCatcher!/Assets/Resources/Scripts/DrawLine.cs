using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
	private Transform tr;

	private bool clicked;

	public GameObject ray;

    // Start is called before the first frame update
    void Start()
    {
		tr = GetComponent<Transform>();
		clicked = false;
    }

	// Update is called once per frame
	void Update()
	{
		if (!clicked)
		{
			if (Input.GetAxisRaw("Horizontal") > 0)
			{ Move(0.5f, 0); }
			if (Input.GetAxisRaw("Horizontal") < 0)
			{ Move(-0.5f, 0); }
			if (Input.GetAxisRaw("Vertical") > 0)
			{ Move(0, 0.5f); }
			if (Input.GetAxisRaw("Vertical") < 0)
			{ Move(0, -0.5f); }
		}
	}

	public void Move(float x, float y)
	{
		clicked = true;

		ray.transform.localPosition = new Vector2(x*2, y*2);

		Vector2 hitVector = new Vector2(x*2, y*2);
		RaycastHit2D hit = Physics2D.Raycast(ray.transform.position,hitVector);
		if (hit.collider.tag == "NotChecked" || hit.collider.tag == "Teleport" || hit.collider.tag == "Cleaner")
		{
			if (clicked)
			{
				tr.position = new Vector3(tr.position.x + x, tr.position.y + y, 0);
			}
			if (hit.collider.tag == "Teleport")
			{
				TeleportScript.TeleportPlayer();
			}
			if (hit.collider.tag == "Cleaner")
			{
				LeftNotCheckedTiles.CleanAllChildren();
			}
			LeftNotCheckedTiles.CheckAllChildren();
		}
		StartCoroutine("Czas");
	}

	IEnumerator Czas()
	{
		yield return new WaitForSeconds(0.15f);
		clicked = false;
	}
}
