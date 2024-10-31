/*
* Author - @Shreyansh Anchlia 
* ©SquareDragon Games
*/

using UnityEngine;

public class BugMovement : Bug
{
	public Vector2 currentTarget;
	public float stoppingDistance;
	public float bleedSpeed = 0.4f;
	public float bleedTime = 1f;
	public float speedMultiplier = 1f;

	Vector3 rotation;
	private void Start()
	{
		calculateNewTarget();
	}
	private void Update()
	{
		//stopping distance
		if(Vector2.Distance(this.transform.position, currentTarget) < stoppingDistance)
		{
			calculateNewTarget();
		}

		//movement
		this.transform.position = Vector2.MoveTowards(this.transform.position, currentTarget, speedMultiplier * speed * Time.deltaTime);
	}

	private void FixedUpdate()
	{
		speedMultiplier = Mathf.Clamp(speedMultiplier + ((1f - bleedSpeed) * Time.fixedDeltaTime / bleedTime), bleedSpeed, 1f);
	}

	private void calculateNewTarget()
	{
		currentTarget.x = Random.Range(minBounds.x, maxBounds.x);
		currentTarget.y = Random.Range(minBounds.y, maxBounds.y);

		transform.up = (Vector3)currentTarget - transform.position;
		//transform.LookAt(currentTarget, Vector3.forward);
		//rotation = transform.rotation.eulerAngles;
		//rotation.x = 0;
		//rotation.y = 0;
		//transform.eulerAngles = rotation;
	}
	public void BugBleed()
	{
		speedMultiplier = bleedSpeed;
		print(speedMultiplier);
	}
}
