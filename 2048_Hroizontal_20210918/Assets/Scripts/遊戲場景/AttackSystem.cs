using UnityEngine;
using UnityEngine.UI;

public class AttackSystem : MonoBehaviour
{
	#region 欄位：公開

	[Header("攻擊力基底")]
	public float attack = 10;
	[Header("攻擊目標")]
	public GameObject goTarget;
	[Header("攻擊力介面")]
	public Text _atkText;

    #endregion

    #region

    private void Awake()
    {
		_atkText.text = "ATK " + attack;
    }

    #endregion

    #region 方法：公開

    public virtual void Attack()
	{
		print("<color=red>發動攻擊，攻擊力為：" + attack + "</color>");
	}
	
	#endregion
}
