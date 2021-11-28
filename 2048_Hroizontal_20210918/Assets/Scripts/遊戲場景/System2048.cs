using UnityEngine;
using UnityEngine.UI;
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

    public BlockData() { }
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

    [SerializeField]
    private Direction direction;
    private BlockData[,] _blockData = new BlockData[1,4];
    private Vector3 _posDown;
    private Vector3 _posUp;
    private bool _isClick = false;

    private void Start() 
    { 
        Initialize();
    }

    private void Update()
    {
        CheckDirection();
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
                
                result += (_blockData[i, j].number > 0 ? _blockData[i, j].number : 0) +  " | ";
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

    private void CheckDirection() 
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            direction = Direction.Up;
            CheckMoveDirection();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Direction.Down;
            CheckMoveDirection();
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Direction.Left;
            CheckMoveDirection();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Direction.Right;
            CheckMoveDirection();
        }

        if(!_isClick && Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            _isClick = true;
            _posDown = Input.mousePosition;
        }
        else if (_isClick && Input.GetKeyUp(KeyCode.Mouse0))
        {
            _isClick = false;
            _posUp = Input.mousePosition;

            Vector3 directionValue = (_posUp - _posDown).normalized;

            float _xabs = Mathf.Abs(directionValue.x);
            float _yabs = Mathf.Abs(directionValue.y);
    
            if(_xabs > _yabs) 
            {
                if (directionValue.x > 0) { direction = Direction.Right; }
                else if (directionValue.x < 0) { direction = Direction.Left; }

                CheckMoveDirection();
            }

            else if(_yabs > _xabs) 
            {
                if (directionValue.y > 0) { direction = Direction.Up; }
                else if (directionValue.y < 0) { direction = Direction.Down; }

                CheckMoveDirection();
            }
        }
    }

    public void CheckMoveDirection() 
    {
        Debug.Log("Now Direction: " + direction);

        //int[,] locate;

        switch (direction)
        {
            case Direction.Right:
                break;
            case Direction.Left:
                for(int i = 0; i < _blockData.GetLength(0); i++) 
                {
                    for(int j = 0; j < _blockData.GetLength(1); j++) 
                    {
                        BlockData blockOrigin = new BlockData();
                        BlockData blockCheck = new BlockData();
                        bool canMove = false;
                        bool sameNumber = false;
                        blockOrigin = _blockData[i, j];

                        if(blockOrigin.number == 0) { continue; }

                        for(int k = j - 1; k >= 0; k--) 
                        {
                            if (_blockData[i, k].number == 0)
                            {
                                canMove = true;
                                blockCheck = _blockData[i, k];
                            }
                            else if (_blockData[i, k].number == blockOrigin.number) 
                            {
                                blockCheck = _blockData[i, k];
                                canMove = true;
                                sameNumber = true;
                            }
                        }
                        if (canMove) 
                        { 
                            blockOrigin.goBlock.transform.position = blockCheck.Position;
                            if (sameNumber)
                            {
                                int number = blockCheck.number * 2;
                                blockCheck.number = number;

                                Debug.Log(blockCheck.number);

                                Destroy(blockOrigin.goBlock);
                                blockCheck.goBlock.transform.Find("數字").GetComponent<Text>().text = blockCheck.number.ToString();
                            }
                            else 
                            { 
                                blockCheck.number = blockOrigin.number;
                                blockCheck.goBlock = blockOrigin.goBlock;
                            }
                            blockOrigin.number = 0;
                            blockOrigin.goBlock = null;
                        }                        
                    }
                }

                DisplayBlockData();

                break;
            case Direction.Up:
                break;
            case Direction.Down:
                break;
        }
    }
}
