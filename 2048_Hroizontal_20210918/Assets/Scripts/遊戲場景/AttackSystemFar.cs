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

		tempAttack.GetComponent<Bullet>().attack = attack * increase;
	}
}
