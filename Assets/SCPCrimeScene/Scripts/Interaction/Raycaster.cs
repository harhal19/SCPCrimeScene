﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HitInfo
{
	public bool HasHit;
	public Vector3 Location;
	public Vector3 Normal;
	public Vector3 HitDirection;
	public GameObject Victim;

	public HitInfo(bool hasHit = false)
	{
		HasHit = hasHit;
		Location = new Vector3();
		Normal = new Vector3();
		HitDirection = new Vector3();
		Victim = null;
	}

	public HitInfo(Vector3 location, Vector3 normal, Vector3 hitDirection, GameObject victim)
	{
		HasHit = true;
		Location = location;
		Normal = normal;
		HitDirection = hitDirection;
		Victim = victim;
	}
}

public class Raycaster : MonoBehaviour
{
	private static Camera CameraComponent;
	
	// Use this for initialization
	void Start ()
	{
		CameraComponent = GetComponent<Camera>();
	}

	public static HitInfo RaycastFromScreenPoint(Vector3 screenPoint)
	{
		if (CameraComponent == null)
		{
			return new HitInfo();
		}
		
		Ray ray = CameraComponent.ScreenPointToRay(screenPoint);
		
		RaycastHit hit;
		
		if (Physics.Raycast(ray, out hit))
		{
			return new HitInfo(hit.point, hit.normal, ray.direction, hit.transform.gameObject);
		}
		
		return new HitInfo();
	}
}
