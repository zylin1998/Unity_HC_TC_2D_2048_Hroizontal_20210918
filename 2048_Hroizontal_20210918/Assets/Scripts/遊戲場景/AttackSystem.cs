using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AttackSystem : MonoBehaviour
{
	#region 欄位：公開

	[Header("攻擊力基底")]
	public float attack = 10;
    public float critical = 30;
    [Range(0.5f, 1.0f)]
    public float floatDemage = 0.5f;
	[Header("攻擊目標")]
	public GameObject goTarget;
	[Header("攻擊力介面")]
	public Text _atkText;
	[Header("延遲攻擊"), Range(0, 10)]
    public float delayAttack = 1.5f;
    [Header("延遲傳送傷害"), Range(0, 5)]
    public float delaySendDamage = 0.5f;
    [Header("動畫參數")]
    public string parameterAttack = "攻擊觸發";

    #endregion

	#region 欄位：保護 Protected

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

    [Header("攻擊開始事件")]
    public UnityEvent onAttackStart;
    [Header("攻擊完成事件")]
    public UnityEvent onAttackFinish;

    private bool isStop;

    #region 方法：公開

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

    #region 私人方法

    private IEnumerator DelayAttack()
    {
        // 延遲 3.5 秒
        yield return new WaitForSeconds(delayAttack);
        // 攻擊動畫
        ani.SetTrigger(parameterAttack);
        // 延遲 0.5 秒
        yield return new WaitForSeconds(delaySendDamage);
        onAttackStart.Invoke();
        // 傳送傷害
        targetHealthSystem.Hurt(attack);
        onAttackFinish.Invoke();
    }

    #endregion

}
