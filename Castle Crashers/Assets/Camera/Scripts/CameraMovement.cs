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

		Vector3 newPosition = CenterPoint + Offset;

		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref Velocity, SmoothTime);
	}

	void Zoom()
	{
		float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / ZoomLimiter);
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
	}

}
