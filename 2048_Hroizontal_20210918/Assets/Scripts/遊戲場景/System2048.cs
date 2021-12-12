using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum Direction
{
    None, Right, Left, Up, Down
}

public enum StateTurn
{
    My, Enemy
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
    #region 公開欄位

    [Header("空白區塊")]
    public Transform[] _blocks;
    [Header("數字區塊")]
    public GameObject _numberBlocks;
    [Header("畫布")]
    public Transform _canvas2048;
    public UnityEvent onSameNumberCombine;
    [Header("起始格數")]
    public int _initialBlocksNumber = 2;
    [Header("機率百分比"), Range(1, 100)]
    public int _basicPresentage = 25;

    #endregion

    #region 非公開欄位

    [SerializeField]
    private Direction direction;
    [SerializeField]
    private StateTurn StateTurn;
    private BlockData[,] _blockData = new BlockData[4,4];
    private Vector3 _posDown;
    private Vector3 _posUp;
    private bool _isClick = false;

    #endregion

    #region 事件

    private void Start() 
    { 
        Initialize();
    }

    private void Update()
    {
        if (StateTurn == StateTurn.My) { CheckDirection(); }
    }

    #endregion

    #region 初始化

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

        //DisplayBlockData();
    }

    #endregion

    #region 資料顯示

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

    #endregion

    #region 亂數位置產生

    private void CreateRandomNumberBlock() 
    {
        var IsEmpty =
            from BlockData n in _blockData
            where n.number == 0
            select n;
        
        int _random = Random.Range(0, IsEmpty.Count());
        
        Vector2Int RandomIndex = IsEmpty.ToArray()[_random].Index;

        BlockData RandomBlock = _blockData[RandomIndex.x, RandomIndex.y];

        int _randomPresentage = Random.Range(1, 100);

        if(_randomPresentage <= 25) { RandomBlock.number = 4; }

        else { RandomBlock.number = 2; }

        RandomBlock.goBlock = Instantiate(_numberBlocks,RandomBlock.Position, Quaternion.identity, _canvas2048);

        RandomBlock.goBlock.transform.Find("數字").GetComponent<Text>().text = RandomBlock.number.ToString();
    }

    #endregion

    #region 方向確認

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

    #endregion

    #region 確認移動方向

    public void CheckMoveDirection() 
    {
        Debug.Log("Now Direction: " + direction);

        //int[,] locate;
        BlockData blockOrigin = new BlockData();
        BlockData blockCheck = new BlockData();
        bool canMove = false;
        bool sameNumber = false;
        int sameNumberCount = 0;
        
        switch (direction)
        {
            case Direction.Right:
                for (int i = 0; i < _blockData.GetLength(0); i++)
                {
                    sameNumberCount = 0;              //相同數字合併次數歸零

                    for (int j = _blockData.GetLength(1) - 2; j >= 0; j--)
                    {
                        blockOrigin = _blockData[i, j];

                        //如果該區塊數字薇玲就繼續(跳過此迴圈 執行下個迴圈)
                        if (blockOrigin.number == 0) continue;

                        for (int k = j + 1; k < _blockData.GetLength(1) - sameNumberCount; k++)
                        {
                            if (_blockData[i, k].number == 0)
                            {
                                blockCheck = _blockData[i, k];
                                canMove = true;
                            }
                            else if (_blockData[i, k].number == blockOrigin.number)
                            {
                                blockCheck = _blockData[i, k];
                                canMove = true;
                                sameNumber = true;
                                sameNumberCount++;
                            }
                            else if (_blockData[i, k].number != blockOrigin.number)
                            {
                                break;
                            }
                        }
                        if (canMove)
                        {
                            canMove = false;                         //是否可以移動區塊
                            MoveBlock(blockOrigin, blockCheck, sameNumber);
                            sameNumber = false;
                        }
                    }
                }
                break;
            case Direction.Left:
                for (int i = 0; i < _blockData.GetLength(0); i++)
                {
                    for (int j = 1; j < _blockData.GetLength(1); j++)
                    {
                        blockOrigin = _blockData[i, j];

                        //如果該區塊數字薇玲就繼續(跳過此迴圈 執行下個迴圈)
                        if (blockOrigin.number == 0) continue;

                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (_blockData[i, k].number == 0)
                            {
                                blockCheck = _blockData[i, k];
                                canMove = true;
                            }
                            else if (_blockData[i, k].number == blockOrigin.number)
                            {
                                blockCheck = _blockData[i, k];
                                canMove = true;
                                sameNumber = true;
                            }
                            else if (_blockData[i, k].number != blockOrigin.number)
                            {
                                break;
                            }
                        }
                        if (canMove)
                        {
                            canMove = false;                         //是否可以移動區塊
                            MoveBlock(blockOrigin, blockCheck, sameNumber);
                            sameNumber = false;
                        }
                    }
                }
                break;
            case Direction.Up:
                for (int i = 0; i < _blockData.GetLength(1); i++)
                {
                    for (int j = 1; j < _blockData.GetLength(0); j++)
                    {
                        blockOrigin = _blockData[j, i];

                        //如果該區塊數字為零就繼續(跳過此迴圈 執行下個迴圈)
                        if (blockOrigin.number == 0) continue;



                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (_blockData[k, i].number == 0)
                            {
                                blockCheck = _blockData[k, i];
                                canMove = true;
                            }
                            else if (_blockData[k, i].number == blockOrigin.number)
                            {
                                blockCheck = _blockData[k, i];
                                canMove = true;
                                sameNumber = true;
                            }
                            else if (_blockData[k, i].number != blockOrigin.number)
                            {
                                break;
                            }
                        }
                        if (canMove)
                        {
                            canMove = false;                         //是否可以移動區塊
                            MoveBlock(blockOrigin, blockCheck, sameNumber);
                            sameNumber = false;
                        }
                    }
                }
                break;
            case Direction.Down:
                for (int i = 0; i < _blockData.GetLength(1); i++)
                {
                    for (int j = _blockData.GetLength(0) - 2; j >= 0; j--)
                    {
                        blockOrigin = _blockData[j, i];

                        //如果該區塊數字為零就繼續(跳過此迴圈 執行下個迴圈)
                        if (blockOrigin.number == 0) continue;



                        for (int k = j + 1; k < _blockData.GetLength(0); k++)
                        {
                            if (_blockData[k, i].number == 0)
                            {
                                blockCheck = _blockData[k, i];
                                canMove = true;
                            }
                            else if (_blockData[k, i].number == blockOrigin.number)
                            {
                                blockCheck = _blockData[k, i];
                                canMove = true;
                                sameNumber = true;
                            }
                            else if (_blockData[k, i].number != blockOrigin.number)
                            {
                                break;
                            }
                        }
                        if (canMove)
                        {
                            canMove = false;                         //是否可以移動區塊
                            MoveBlock(blockOrigin, blockCheck, sameNumber);
                            sameNumber = false;
                        }
                    }
                }
                break;
        }
        CreateRandomNumberBlock();
    }

    #endregion

    #region 移動方塊

    private void MoveBlock(BlockData blockOriginal, BlockData blockCheck, bool sameNumber)
    {
        #region 移動區塊
        blockOriginal.goBlock.transform.position = blockCheck.Position;
        if (sameNumber)
        {
            int number = blockCheck.number * 2;
            blockCheck.number = number;
            Destroy(blockOriginal.goBlock);
            blockCheck.goBlock.transform.Find("數字").GetComponent<Text>().text = blockCheck.number.ToString();

            //相同數字合併事件 觸發
            onSameNumberCombine.Invoke();

        }
        else
        {
            blockCheck.number = blockOriginal.number;
            blockCheck.goBlock = blockOriginal.goBlock;
        }

        blockOriginal.number = 0;
        blockOriginal.goBlock = null;
        #endregion

        DisplayBlockData();
    }

    #endregion
}
