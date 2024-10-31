/*
* Author - @Shreyansh Anchlia 
* ©SquareDragon Games
*/

using UnityEngine;

public class BugHealth : MonoBehaviour
{
	[SerializeField] int Health = 100;
	public GameObject bleedEffect;

	public void loseHealth(int amount = 100)
	{
		Health -= amount;
		bleedEffect.SetActive(true);
		bleedEffect.GetComponent<ParticleSystem>().startSize *= 1.25f;
		DieCheck();
	}
	public void gainHealth(int amount = 100)
	{
		Health += amount;
	}
	void DieCheck()
	{
		if(Health<= 0)
		{
			BugDie();
		}
	}
	private void OnDestroy()
	{
		GameManager.instance.currentBugs--;
	}
	void BugDie()
	{
		Destroy(this.gameObject, 0.25f);
	}
}
