using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	public Animator animator;
	public Transform AttackPoint;
	public float AttackRange = 0.5f;
	public LayerMask enemyLayers;
	public int LightAttackCombo = 0;
	public bool CanAttack = true;


	private void Start()
	{
		CanAttack = true;
		LightAttackCombo = 0;
		
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			ComboStarter();
			Mathf.Clamp(LightAttackCombo, 0, 2);
		}
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

		foreach (Collider2D enemy in hitEnemies)
		{
			Debug.Log("We hit" + enemy.name);
		}
	}

	void ComboChecker()
	{
		CanAttack = false;
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack") && LightAttackCombo >= 2)
		{
			animator.SetInteger("animation", 2);
			CanAttack = true;
			LightAttackCombo = 0;

		}
		else
		{
			animator.SetInteger("animation", 0);
			CanAttack = true;
			LightAttackCombo = 0;
			print("Kanker Progamma");
		}
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttackFollow") && LightAttackCombo >= 3)
		{
			animator.SetInteger("animation", 0);
			LightAttackCombo = 0;
			CanAttack = true;
			
		}
	}

	void ComboStarter()
	{
		if (CanAttack)
		{
			LightAttackCombo++;
		}
		if (LightAttackCombo == 1)
		{
			animator.SetInteger("animation", 1);

		}
	}
}
 