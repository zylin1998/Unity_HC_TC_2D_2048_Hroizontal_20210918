using UnityEngine;
using System.Linq;

public enum Direction{

    None, Right, Left, Up, Down

}

public class BlockData
{
    public GameObject goBlock;
    public Vector2 Position;
    public Vector2Int Index;
    public int number;
}

public class System2048 : MonoBehaviour
{
    [Header("空白區塊")]
    public Transform[] _blocks;
    [Header("數字區塊")]
    public GameObject _numberBlocks;
    [Header("畫布")]
    public Transform _canvas2048;
    [Header("起始格數")]
    public int _initialBlocksNumber = 2;

    public BlockData[,] _blockData = new BlockData[4,4];

    private void Start() 
    { 
        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < _blockData.GetLength(0); i++) 
        {
            for (int j = 0; j < _blockData.GetLength(1); j++) 
            { 
                _blockData[i,j] = new BlockData();
                _blockData[i,j].Index = new Vector2Int(i, j);
                _blockData[i,j].Position = _blocks[i * _blockData.GetLength(1) + j].position;
            }
        }

        for(int i = 0; i < _initialBlocksNumber; i++) { CreateRandomNumberBlock(); }

        DisplayBlockData();
    }

    private void DisplayBlockData() 
    {
        string result = "";

        for (int i = 0; i < _blockData.GetLength(0); i++)
        {
            for (int j = 0; j < _blockData.GetLength(1); j++)
            {
                result += "ID<color=grey>" + _blockData[i, j].Index + "</color> Num[<color=grey>" + _blockData[i, j].number + "</color>] Posi<color=grey>" + _blockData[i,j].Position + "</color> | ";
            }

            result += "\n";
        }

        Debug.Log(result);
    }

    private void CreateRandomNumberBlock() 
    {
        var IsEmpty =
            from BlockData n in _blockData
            where n.number == 0
            select n;
        
        int _random = Random.Range(0, IsEmpty.Count());
        
        Vector2Int RandomIndex = IsEmpty.ToArray()[_random].Index;

        BlockData RandomBlock = _blockData[RandomIndex.x, RandomIndex.y];
        RandomBlock.number = 2;

        RandomBlock.goBlock = Instantiate(_numberBlocks,RandomBlock.Position, Quaternion.identity, _canvas2048);
    }
}
