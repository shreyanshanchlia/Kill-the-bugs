using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class MoveX : PlayerMovement
{
    public float speed = 10;
	public float minX, maxX;

	#region cached variables
	Vector3 newPos;
	float x;
	#endregion
	private void Update()
	{
		x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
		newPos = this.transform.position + Vector3.right * x;
		newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
		this.transform.position = newPos;
	}
}
