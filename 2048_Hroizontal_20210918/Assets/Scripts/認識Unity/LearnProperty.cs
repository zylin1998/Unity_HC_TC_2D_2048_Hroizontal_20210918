using UnityEngine;

public class LearnProperty : MonoBehaviour
{
    // ���
    public int passwordField = 123456789;

    // �ݩ� Property
    // �y�k�G
    // �׹��� ������� �ݩʦW�� { �s���l }
    // �۰ʹ�@
    public int passwordProperty { get; set; }

    // get ���o
    // set �]�w
    // ��Ū�ݩ� �u����o
    // => �H�ڹF Lambda C# 6.0
    public int myPasswordProperty { get => 999; }

    // ��Ū����g�k
    // get �ݨϥ�����r return �Ǧ^
    public string nameCharacter
    {
        get
        {
            print("�ڦb�ݩ� name Character �̭�~");
            return "KID";
        }
    }
    // �߼g����g�k
    // set �ϥ�����r value ��J��
    public float attack
    {
        set
        {
            print("�����O�G" + value);
        }
    }

    // �}�l�ƥ�G����ɰ���@��
    private void Start()
    {
        // �s�� Set �ݩʸ��
        // �y�k�G
        // �ݩʦW�� ���w �ȡF
        passwordProperty = 777;
        // ���o Get �ݩʸ��
        // �y�k�G
        // �ݩʦW��
        print("�ݩʱK�X�G" + passwordProperty);

        // myPasswordProperty = 999;    // ����]�w ��Ū�ݩ�
        print("�ڪ��ݩʱK�X�G" + myPasswordProperty);

        print(nameCharacter);

        // print(attack);               // ������o �߼g�ݩ�
        attack = 99.9f;
    }
}
