using UnityEngine;

public class Learn2DArray : MonoBehaviour
{
    public int[] _numbers = { 1, 3, 5, 7, 9 };

    public int[,] _array2D = { { 2, 4 }, { 6, 8 } };

    public int[,] _scores = { { 1, 2 }, { 3, 4 }, { 5, 6 } };

    private void Start()
    {
        _numbers[4] = 99;
        Debug.Log("�@���}�C�Ĥ�����ơG " + _numbers[4]);

        Debug.Log("�G���}�C�ĤG�C�Ĥ@��(1, 0)�G" + _array2D[1, 0]);
        _array2D[1, 0] = 99;
        Debug.Log("�G���}�C�ĤG�C�Ĥ@��(1, 0)�G" + _array2D[1, 0]);

        Debug.Log("�G�����P�Ĥ@�����סG" + _scores.GetLength(0));
        Debug.Log("�G�����P�Ĥ@�����סG" + _scores.GetLength(1));

        print(Result());
    }

    private string Result() 
    {
        string result = "";

        for(int i = 0; i < _scores.GetLength(0); i++) 
        {
            for(int j = 0; j < _scores.GetLength(1); j++) { result += (_scores[i, j] + " | "); }

            result += "\n";
        }

        return result;
    }
}
