using UnityEngine;
using System.Linq;

public class Learn2DArray : MonoBehaviour
{
    public int[] _numbers = { 1, 3, 5, 10, 9 };

    public int[,] _array2D = { { 2, 4 }, { 6, 8 } };

    public int[,] _scores = { { 10, 20 }, { 73, 54 }, { 85, 66 } };

    private void Start()
    {
        _numbers[4] = 99;
        Debug.Log("一維陣列第五筆資料： " + _numbers[4]);

        Debug.Log("二維陣列第二列第一欄(1, 0)：" + _array2D[1, 0]);
        _array2D[1, 0] = 99;
        Debug.Log("二維陣列第二列第一欄(1, 0)：" + _array2D[1, 0]);

        Debug.Log("二維振烈第一維長度：" + _scores.GetLength(0));
        Debug.Log("二維振烈第一維長度：" + _scores.GetLength(1));

        print(Result());

        var NumberGratgerTen =
            from int n in _numbers
            where n >= 10
            select n;

        Debug.Log("一維陣列中>=10個數：" + NumberGratgerTen.Count());

        for(int i = 0; i < NumberGratgerTen.Count(); i++)
        {
            Debug.Log(">=10的數字：" + NumberGratgerTen.ToArray()[i]);
        }

        var IsPass =
            from int n in _scores
            where n >= 60
            select n;

        for (int i = 0; i < IsPass.Count(); i++)
        {
            Debug.Log("及格的分數：" + IsPass.ToArray()[i]);
        }
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
