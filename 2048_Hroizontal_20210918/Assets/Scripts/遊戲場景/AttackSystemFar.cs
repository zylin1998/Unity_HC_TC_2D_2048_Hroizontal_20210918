using UnityEngine;

public class AttackSystemFar : AttackSystem
{
	[Header("�ͦ��ɤl��m")]
	public Transform positionSpawn;
	[Header("�����ɤl")]
	public GameObject goAttackPartical;
	[Header("�ɤl�o�g�t��"), Range(0, 1000)]
	public float speed = 100f;
	
	// override �мg�G�мg�����O
	public override void Attack(float increase = 0)
	{
		onAttackStart.Invoke();

		GameObject tempAttack =  Instantiate(goAttackPartical, positionSpawn.position, Quaternion.identity);
		tempAttack.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed,0));

		tempAttack.GetComponent<Bullet>().attack = FinalDemage(increase);
	}

	#region ���O�@��k

	protected float FinalDemage(float increase)
	{
		float demage = 0;

		float randomFloatDemage = Random.Range(-floatDemage, floatDemage);

		int randomCritical = Random.Range(1, 100);

		float isCritical = 1;

		if (randomCritical <= critical) { isCritical = 1.5f; }
		else { isCritical = 1; }

		demage = attack * increase * (1 + randomFloatDemage) * isCritical;

		return demage;
	}

	#endregion
}
