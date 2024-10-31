/*
* Author - @Shreyansh Anchlia 
* ©SquareDragon Games
*/

using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject bug1, bug2;
	public Vector2 currentTarget;
	public Vector2 minBounds, maxBounds;
	public void spawn()
	{
		int level = GameManager.instance.level;

		for (int i = 0; i < level * 2; i++)
		{
			newPos();
			Instantiate(bug1, transform.position, Quaternion.identity);
			GameManager.instance.currentBugs++;
		}
		for (int i = 2; i < level; i++)
		{
			Instantiate(bug2, transform.position, Quaternion.identity);
			GameManager.instance.currentBugs++;
		}
	}
	void newPos()
	{
		currentTarget.x = Random.Range(minBounds.x, maxBounds.x);
		currentTarget.y = Random.Range(minBounds.y, maxBounds.y);
	}
}
