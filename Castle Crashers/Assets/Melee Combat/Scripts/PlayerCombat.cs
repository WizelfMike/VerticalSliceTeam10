using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
		HeavyAttackCombo = 0;
		
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
		Collider[] hitEnemies = Physics.OverlapSphere(AttackPoint.position, AttackRange, enemyLayers);
		Collider[] hitEnemies2 = Physics.OverlapSphere(AttackPoint.position, AttackRange, EnemyLayer2);

		foreach (Collider enemy in hitEnemies)
		{
			Debug.Log("We hit" + enemy.name);
		}
		foreach (Collider enemy in hitEnemies2)
		{
			Debug.Log("We hit" + enemy.name);
		}
	}

	void ComboChecker()
	{
		CollisionCheck();
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
		HeavyAttackCombo = 0;
	}

	public void OnAttack()
	{
		LightAttackCombo++;
		ComboStarter();
		Mathf.Clamp(LightAttackCombo, 0, 2);
	}

	public void OnHeavyAttack()
	{
		HeavyAttackCombo++;
		ComboStarter();
		Mathf.Clamp(LightAttackCombo, 0, 2);
	}

	void ComboStarter()
	{
		if (LightAttackCombo == 1)
		{
			animator.SetInteger("animation", 2);
			print("Light Attack");

		}

		if (HeavyAttackCombo == 1)
		{
			animator.SetInteger("animation", 1);
			print("Heavy Attack");
		}
	}
}
 