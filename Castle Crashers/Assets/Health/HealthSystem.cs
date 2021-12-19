using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthSystem : MonoBehaviour
{
	[Header("Health")]
	public int StartHealth = 200;
	public int PlayerHealth = 200;
	[Header("Damage")]
	public int Damage;
	public int DamageStepSize;
	[Header("Misc")]
	public Slider HealthSlider;
	public float SliderTime;
	public GameObject Player;
	public Animator animator;
	public bool Dead = false;

	void Start()
	{
		SetMaxHealth(StartHealth);
		Sethealth(StartHealth);
	}

	void Update()
	{
		GetRandomDamage();
		Sethealth(PlayerHealth);
		if (PlayerHealth <= 0)
		{
			Die();
		}
		if (Dead)
		{
			
		}
	}

	public float GetRandomDamage()
	{
		int randomDamage = Random.Range(5, 25);
		int numSteps = Mathf.FloorToInt(randomDamage / DamageStepSize);
		int AdjustedDamage = numSteps * DamageStepSize;

		Damage = AdjustedDamage;

		return Damage;
	}

	public void SetMaxHealth(int health)
	{
		HealthSlider.maxValue = health;
		HealthSlider.value = health;
	}

	public void Sethealth(int health)
	{
		HealthSlider.DOValue(health,SliderTime);
	}

	void Die()
	{
		StartCoroutine(StopGame());
		Player.SetActive(!Player.activeSelf);
		animator.SetInteger("animation", 5);
		Dead = true;
	}

	IEnumerator StopGame()
	{
		yield return new WaitForSeconds(5);
		Application.Quit();
	}
}
