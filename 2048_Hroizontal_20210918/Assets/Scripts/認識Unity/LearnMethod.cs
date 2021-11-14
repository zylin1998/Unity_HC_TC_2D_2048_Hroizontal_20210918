using UnityEngine;

/// <summary>
/// summary �K�n
/// ��ƻ����A��ܦb VS �sĶ�����ܤW
/// </summary>
public class LearnMethod : MonoBehaviour
{
    // ��k Method�BFunction (�禡)
    // �@�ΡG������������{�����e
    // �y�k�G
    // �׹��� �Ǧ^������� ��k�W�� (�Ѽ�) { �{�����e }
    // �L�Ǧ^ void
    // �R�W�ߺD�GUnity ��k�H�j�g�}�Y
    // �ۭq��k�G���|����
    public void Test()
    {
        print("�ڬO���դ�k~");
    }

    private void Start()
    {
        // �I�s��k
        // ��k�W��()�F
        Test();
        Test();
        Drive90();
        Drive150();
        // �I�s��k�G�޼�
        // ���w�]�Ȫ��Ѽƥi�H����g�A�ϥιw�]��
        Drive(70);
        Drive(200, "�F�F�F");
        Drive(300);
        // �ɳt 50�A�w�]���ġA���Y
        // ���w�w�]�ȰѼƻy�k �ѼƦW�� �_�� ��
        Drive(50, effect: "���Y");

        int t = Ten();
        print("�Ǧ^��k�ȡG" + t);

        print("���ϥ��ܼ��x�s�Ǧ^�ȡG" + Ten());

        int damage = Damage(90, 30);
        print("90 �����O�P 30 ���m�O���ˮ`�G" + damage);
    }

    // �����ݨD
    // ���񭵮�
    // �T���i�H�[�t�A�ɳt�� 90
    // �T���i�H�[�t�A�ɳt�� 150
    public void Drive90()
    {
        print("�}���A�ɳt�G" + 90);
        print("����");
    }

    public void Drive150()
    {
        print("�}���A�ɳt�G" + 150);
        print("����");
    }

    // �w�q��k
    // �ѼơG������� �ѼƦW�� (���w �w�]��) �g�b () �̥k��
    // �Ѽ�1�A�Ѽ�2�A.....�A�Ѽ�N
    public void Drive(int speed, string sound = "������", string effect = "�ǹ�")
    {
        print("�}���A�ɳt�G" + speed);
        print("���ġG" + sound);
        print("�S�ġG" + effect);
    }

    // ���Ǧ^������k�����ϥ� return
    public int Ten()
    {
        return 10;
    }

    // �K�n�G�D���n���ܭ��n�I
    // 90 - 30 = 60
    /// <summary>
    /// �p��ˮ`�ȡA�����O - ���m�O = �ˮ`��
    /// </summary>
    /// <param name="attack">�����O</param>
    /// <param name="defence">���m�O</param>
    /// <returns>�ˮ`��</returns>
    public int Damage(int attack, int defence)
    {
        return attack - defence;
    }
}
