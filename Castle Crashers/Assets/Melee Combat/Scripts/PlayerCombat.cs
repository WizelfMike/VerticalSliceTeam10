using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	public Animator animator;
	public Transform AttackPoint;
	public float AttackRange = 0.5f;
	public LayerMask enemyLayers;
	private bool Attacking = false;
	private bool FollowUp1 = false;
	public int AttackCombo = 0;
	ComboHit Combo = ComboHit.Attack1;


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.J))
		{
			AttackCombo++;
		}

		

		switch (Combo)
		{
			case ComboHit.Attack1:
				if (Input.GetKeyDown(KeyCode.J))
				{
					LightAttack();
				}
				break;
			case ComboHit.Attack2:
				LightAttackFollow();
				break;
			default:
				break;
		}
	}


	void LightAttack()
	{
		Attacking = true;
		animator.SetInteger("animation", 1);
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayers);

		foreach (Collider2D enemy in hitEnemies)
		{
			Debug.Log("We hit" + enemy.name);
		}
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack") && AttackCombo == 2)
		{
			Combo = ComboHit.Attack2;
		}
		else if (animator.GetCurrentAnimatorStateInfo(0).IsName("LightAttack") && AttackCombo == 1)
		{
			Combo = ComboHit.Attack1;
			AttackCombo = 0;
			animator.SetInteger("animation", 0);
		}


	}

	void LightAttackFollow()
	{	
		Attacking = true;
		animator.SetInteger("animation",2);
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayers);

		foreach (Collider2D enemy in hitEnemies)
		{
			Debug.Log("We hit" + enemy.name);
		}
		
	
	}

	void DoingFollowUp()
	{
		FollowUp1 = true;
	}

	private void OnDrawGizmosSelected()
	{
		if (AttackPoint == null)
		{
			return;
		}
		Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
	}

	void AttackingFalse()
	{
		Attacking = false;
		FollowUp1 = false;
	}

	enum ComboHit
	{
		Attack1,Attack2
	}

}
 