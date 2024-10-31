using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class MoveY : PlayerMovement
{
    public float speed = 10;
	public float minY, maxY;


	#region cached variables
	Vector3 newPos;
	float y;
	#endregion
	private void Update()
	{
		y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
		newPos = this.transform.position + Vector3.up * y;
		newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
		this.transform.position = newPos;
	}
}
