using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
	// PLayer Health
	public float HealthP = 200;
	public float Damage;
	public float DamageStepSize;

	void Update()
	{
		GetRandomDamage();
		//Debug.Log(Damage);
	}

	float GetRandomDamage()
	{
		float randomDamage = Random.Range(5, 25);
		float numSteps = Mathf.Floor(randomDamage / DamageStepSize);
		float AdjustedDamage = numSteps * DamageStepSize;

		Damage = AdjustedDamage;

		return Damage;
	}
}
