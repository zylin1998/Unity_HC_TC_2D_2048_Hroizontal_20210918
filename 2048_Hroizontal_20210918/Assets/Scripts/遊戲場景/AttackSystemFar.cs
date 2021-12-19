using UnityEngine;

public class AttackSystemFar : AttackSystem
{
	[Header("生成粒子位置")]
	public Transform positionSpawn;
	[Header("攻擊粒子")]
	public GameObject goAttackPartical;
	[Header("粒子發射速度"), Range(0, 1000)]
	public float speed = 100f;
	
	// override 覆寫：覆寫父類別
	public override void Attack(float increase = 0)
	{
		onAttackStart.Invoke();

		GameObject tempAttack =  Instantiate(goAttackPartical, positionSpawn.position, Quaternion.identity);
		tempAttack.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed,0));

		tempAttack.GetComponent<Bullet>().attack = attack * increase;
	}
}
