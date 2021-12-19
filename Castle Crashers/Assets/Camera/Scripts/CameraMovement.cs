using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public List<Transform> targets;
	public Vector3 Offset;
	public float SmoothTime = .5f;
	public float minZoom = 40f;
	public float maxZoom = 10f;
	public float ZoomLimiter = 50f;
	public Vector3 Movement;

	private Vector3 Velocity;
	private Camera cam;

	private void Start()
	{
		cam = GetComponent<Camera>();
	}

	private void LateUpdate()
	{

		if (targets.Count == 0)
		{
			return;
		}
		Move();
		Zoom();

	}

	Vector3 GetCenterPoint()
	{
		if (targets.Count == 1)
		{
			return targets[0].position;
		}

		var bounds = new Bounds(targets[0].position, Vector3.zero);
		for (int i = 0; i < targets.Count; i++)
		{
			bounds.Encapsulate(targets[i].position);
		}

		return bounds.center;
	}

	float GetGreatestDistance()
	{
		var bounds = new Bounds(targets[0].position, Vector3.zero);
		
		for (int i = 0; i < targets.Count; i++)
		{
			bounds.Encapsulate(targets[i].position);
		}

		return bounds.size.x;

	}

	void Move()
	{
		Vector3 CenterPoint = GetCenterPoint();

		Movement = CenterPoint + Offset;

		Movement.z = transform.position.z;

		Movement.x = Mathf.Clamp(Movement.x, -3.211144f, 2.952339f);

		transform.position = Vector3.SmoothDamp(transform.position, Movement, ref Velocity, SmoothTime);
	}

	void Zoom()
	{
		float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / ZoomLimiter);
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
	}

}
