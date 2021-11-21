using UnityEngine;

public struct BlockData
{
    public GameObject goBlock;
    public Vector2 Position;
    public Vector2Int Index;
    public int number;
}

public class System2048 : MonoBehaviour
{
    public Transform[] _blocks;

    public BlockData[,] _blockData = new BlockData[4,4];

    private void Start() 
    { 
        Initialize();
        DisplayBlockData();
    }

    private void Initialize()
    {
        for (int i = 0; i < _blockData.GetLength(0); i++) 
        {
            for (int j = 0; j < _blockData.GetLength(1); j++) 
            { 
                _blockData[i,j] = new BlockData();
                _blockData[i,j].Index = new Vector2Int(i, j);
                _blockData[i, j].goBlock = _blocks[i * _blockData.GetLength(1) + j].gameObject;
                _blockData[i,j].Position = _blockData[i,j].goBlock.transform.position;
            }
        }
    }

    private void DisplayBlockData() 
    {
        string result = "";

        for (int i = 0; i < _blockData.GetLength(0); i++)
        {
            for (int j = 0; j < _blockData.GetLength(1); j++)
            {
                result += "ID<color=grey>" + _blockData[i, j].Position + "</color> Num[<color=grey>" + _blockData[i, j].number + "</color>] | ";
            }

            result += "\n";
        }

        Debug.Log(result);
    }
}
