using UnityEngine;

/// <summary>
/// �{�ѹB��l
/// 1. ���w
/// 2. �ƾ�
/// 3. ���
/// 4. �޿�
/// </summary>
public class LearnOperator : MonoBehaviour
{
    public float a = 10;
    public float b = 3;
    public int c = 30;
    public int hp = 100;

    private void Start()
    {
        #region ���w�B��l
        // ���w =
        // ��������w�B��l�k��A���w������
        #endregion

        #region �ƾǹB��l
        // �[����l
        // + - * / %
        print("�[�k�G" + (a + b));     // ���G 13
        print("��k�G" + (a - b));     // ���G 7
        print("���k�G" + (a * b));     // ���G 30
        print("���k�G" + (a / b));     // ���G 3.3333
        print("�l�k�G" + (a % b));     // ���G 1

        c = c + 1;                      // ��l�g�k
        print("C ���G�G" + c);
        c++;                            // ���W ++�A���� -- 
        print("C ���G�G" + c);

        hp = hp + 10;
        print("HP ���G�G" + hp);
        hp += 10;                       // �A�μƾǹB��l += -= *= /= %=
        print("HP ���G�G" + hp);
        #endregion
    }
}
