/*
* Author - @Shreyansh Anchlia 
* ©SquareDragon Games
*/

using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public int currentBugs = 0;
	public int level = 0;
	public Spawner spawner;
	public GameObject winText;

	private void Start()
	{
		instance = this;
	}
	private void Update()
	{
		if(currentBugs == 0)
		{
			level++;
			if(level < 10)
			{
				spawner.spawn();
			}
			else
			{
				winText.SetActive(true);
			}
		}
	}
}
