using UnityEngine;
using UnityEngine.UI;

public class AttackSystem : MonoBehaviour
{
	#region ���G���}

	[Header("�����O��")]
	public float attack = 10;
	[Header("�����ؼ�")]
	public GameObject goTarget;
	[Header("�����O����")]
	public Text _atkText;

    #endregion

    #region

    private void Awake()
    {
		_atkText.text = "ATK " + attack;
    }

    #endregion

    #region ��k�G���}

    public virtual void Attack()
	{
		print("<color=red>�o�ʧ����A�����O���G" + attack + "</color>");
	}
	
	#endregion
}
