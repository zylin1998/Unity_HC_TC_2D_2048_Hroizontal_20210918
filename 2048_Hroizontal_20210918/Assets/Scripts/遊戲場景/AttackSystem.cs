using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AttackSystem : MonoBehaviour
{
	#region ���G���}

	[Header("�����O��")]
	public float attack = 10;
    public float critical = 30;
    [Range(0.5f, 1.0f)]
    public float floatDemage = 0.5f;
	[Header("�����ؼ�")]
	public GameObject goTarget;
	[Header("�����O����")]
	public Text _atkText;
	[Header("�������"), Range(0, 10)]
    public float delayAttack = 1.5f;
    [Header("����ǰe�ˮ`"), Range(0, 5)]
    public float delaySendDamage = 0.5f;
    [Header("�ʵe�Ѽ�")]
    public string parameterAttack = "����Ĳ�o";

    #endregion

	#region ���G�O�@ Protected

    protected HealthSystem targetHealthSystem;
    protected Animator ani;

    #endregion

    #region

    private void Awake()
    {
		_atkText.text = "Atk " + attack;
        ani = GetComponent<Animator>();
        targetHealthSystem = goTarget.GetComponent<HealthSystem>();
    }

    #endregion

    [Header("�����}�l�ƥ�")]
    public UnityEvent onAttackStart;
    [Header("���������ƥ�")]
    public UnityEvent onAttackFinish;

    private bool isStop;

    #region ��k�G���}

    public void StopAttack()
    {
        isStop = true;
        StopAllCoroutines();
        enabled = false;
    }

    public virtual void Attack(float increase = 0)
	{
        if (isStop) { return; }

		StartCoroutine(DelayAttack());
	}

    #endregion

    #region �p�H��k

    private IEnumerator DelayAttack()
    {
        // ���� 3.5 ��
        yield return new WaitForSeconds(delayAttack);
        // �����ʵe
        ani.SetTrigger(parameterAttack);
        // ���� 0.5 ��
        yield return new WaitForSeconds(delaySendDamage);
        onAttackStart.Invoke();
        // �ǰe�ˮ`
        targetHealthSystem.Hurt(attack);
        onAttackFinish.Invoke();
    }

    #endregion

}
