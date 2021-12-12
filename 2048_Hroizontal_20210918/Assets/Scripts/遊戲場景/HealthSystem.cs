using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [Header("��q"), Range(0, 500)]
    public float _hp = 100f;
    [Header("�n�����q")]
    public Text _textHp;
    public Image _imgHp;
    [Header("�y���ˮ`���������")]
    public string _tagDamageObject;
    [Header("�ʵe�Ѽ�")]
    public string _parameterDemage = "����Ĳ�o";
    public string _parameterDead = "���`Ĳ�o";
    
    private float _hpMax;
    private Animator _anim;

    private void Awake()
    {
        _hpMax = _hp;
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _textHp.text = "HP " + _hp;
        _imgHp.fillAmount = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _tagDamageObject) { Hurt(collision.GetComponent<Bullet>().attack); }
    }

    public void Hurt(float damage) 
    {
        if (_hp <= 0) { return; }

        _hp -= damage;

        _hp = Mathf.Clamp(_hp, 0, _hpMax);

        _textHp.text = "HP " + _hp;
        _imgHp.fillAmount = _hp / _hpMax;

        if (_hp <= 0) { Dead();}

        _anim.SetTrigger(_parameterDemage);
    }

    public void Dead() { _anim.SetTrigger(_parameterDead); }
}