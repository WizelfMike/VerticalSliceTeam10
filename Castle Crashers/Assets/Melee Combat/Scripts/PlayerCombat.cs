using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	public Animator animator;
	public Transform AttackPoint;
	public float AttackRange = 0.5f;
	public LayerMask enemyLayers;
	public LayerMask EnemyLayer2;
	public int LightAttackCombo = 0;
	public int HeavyAttackCombo = 0;
	public bool CanAttack = true;


	private void Start()
	{
		CanAttack = true;
		LightAttackCombo = 0;
		
	}

	void Update()
	{

	}


	private void OnDrawGizmosSelected()
	{
		if (AttackPoint == null)
		{
			return;
		}
		Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
	}
	
	void CollisionCheck()
	{
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayers);
		Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayer2);

		foreach (Collider2D enemy in hitEnemies)
		{
			Debug.Log("We hit" + enemy.name);
		}
		foreach (Collider2D enemy in hitEnemies2)
		{
			Debug.Log("We hit" + enemy.name);
		}
	}

	void ComboChecker()
	{
		CanAttack = false;
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && LightAttackCombo >= 2)
		{
			animator.SetInteger("animation", 3);
			CanAttack = true;
			print("3");
		}
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack3") && LightAttackCombo >= 3)
		{
			animator.SetInteger("animation", 0);
			LightAttackCombo = 0;
			CanAttack = true;
			print("3");
		}
	}

	void ReturnToIdle()
	{
		animator.SetInteger("animation", 0);
		CanAttack = true;
		LightAttackCombo = 0;
	}

	public void OnAttack()
	{
		ComboStarter();
		LightAttackCombo++;
		Mathf.Clamp(LightAttackCombo, 0, 2);
	}

	public void OnHeavyAttack()
	{
		ComboStarter();
		HeavyAttackCombo++;
		Mathf.Clamp(LightAttackCombo, 0, 2);
	}

	void ComboStarter()
	{
		if (LightAttackCombo == 1)
		{
			animator.SetInteger("animation", 2);
			print("1");

		}

		if (HeavyAttackCombo == 1)
		{
			animator.SetInteger("animation", 2);
			print("1");
		}
	}
}
 