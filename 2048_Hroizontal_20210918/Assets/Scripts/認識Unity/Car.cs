// �����ѡG������r�A������@#
// �\�� 2021.10.17
// �}�o�� KID 2021.10.17
using UnityEngine;  // �ޥ� Unity Engine API

// class ���O(�Ź�) �W�٭n���ɦW�ۦP�A�j�p�g�]�n�ۦP
public class Car : MonoBehaviour
{
    #region ���y�k�P�|�j������
    // �{����� Field�A�x�s���
    // �y�k�G
    // �׹��� ������� ���W�� ���w �w�]�� �����Ÿ�
    // �`�ΰ򥻥|�j�������
    // 1. ��ơ@ �S���p���I�����t��� int    �w�]�� 0
    // 2. �B�I�� ���p���I�����t��ơ@ float  �w�]�� 0
    // 3. �r��@ ��r��T            string �w�]�� ��
    // 4. ���L�� �O�P�_ true�Bfalse  bool   �w�]�� false
    // �׹���
    // �p�H �ȭ������O�s�� Unity ����� private (�w�])
    // ���} �Ҧ����O�i�s�� Unity �|��� public

    // ����ݩ� Attritube
    // �y�k�G
    // [�ݩʦW��(��)] - ������b���e���ΤW�@��
    // 1. ���D Header (�r��)
    // 2. ���� Tooltip (�r��)
    // 3. �d�� Range (�B�I�ơA�B�I��)
    [Header("�T���� CC ��")][Range(1000, 5000)]
    public int cc = 10;
    [Tooltip("�o�O�T�������q�A�d��O 3 ~ 20"), Range(3, 20)]
    public float weight = 3.5f;
    public string brand = "���h";
    public bool hasSkyWindow = true;
    #endregion

    #region �C�����`�θ������
    // �C�� Color
    public Color color1;
    public Color colorRed = Color.red;
    public Color colorCustom = new Color(0, 0, 1);
    public Color colorCustomAlpga = new Color(0, 1, 0, 0.3f);
    // �V�q (�y��) Vector
    // Vector 2 - 4
    public Vector2 v2;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v2Custom = new Vector2(7, 9);
    public Vector3 v3Custom = new Vector3(1, 2, 3);
    public Vector4 v4Custom = new Vector4(1, 2, 3, 4);
    // ���� KeyCode
    public KeyCode kc;
    public KeyCode kcW = KeyCode.W;
    public KeyCode kcML = KeyCode.Mouse0;

    // �C������ GameObject �������w�w�]��
    public GameObject carBox;
    public GameObject carOil;
    // ���� Component �������w�w�]��
    public Transform traBox;
    public SpriteRenderer sprBox;
    public Camera cam;
    #endregion

    #region �s������� Set Get

    // �{���J�f�G�ƥ�
    // �}�l�ƥ�G����C���ɰ���@���A��l�]�w
    private void Start()
    {
        print("���o�A�U�w :D");

        // ���o Get ����� �� �w�]�ȥH�ݩʭ��O���D (Inspector)
        // �y�k�G
        // ���W��
        print("CC �ơG" + cc);
        print(weight);

        // �s�� Set �����
        // �y�k�G
        // ���W�� ���w �ȡF
        brand = "BMW";
        cc = 3500;
    }
    #endregion
}
