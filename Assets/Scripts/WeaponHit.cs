/*
* Author - @Shreyansh Anchlia 
* ©SquareDragon Games
*/

using UnityEngine;

public class WeaponHit : MonoBehaviour
{
	public KeyCode hitKey;
	public int hitAmount;
	public float hitRadius;
	public float hitAfterTime;
	public LayerMask bugLayer;
	public ParticleSystem hitEffect;
	public Animator anim;
	private void Update()
	{
		if(Input.GetKeyDown(hitKey))
		{
			anim.SetTrigger("hit");
			Invoke(nameof(hitImpact), hitAfterTime);
		}
	}
	void hitImpact()
	{
		hitEffect.Play();
		Collider2D[] bugsInRange = Physics2D.OverlapCircleAll(this.transform.position, hitRadius, bugLayer);
		foreach (Collider2D bugs in bugsInRange)
		{
			bugs.gameObject.GetComponent<BugHealth>().loseHealth(hitAmount);
			bugs.gameObject.GetComponent<BugMovement>().BugBleed();
		}
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(this.transform.position, hitRadius);
	}
}
