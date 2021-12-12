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
    #region ���}���

    [Header("�ťհ϶�")]
    public Transform[] _blocks;
    [Header("�Ʀr�϶�")]
    public GameObject _numberBlocks;
    [Header("�e��")]
    public Transform _canvas2048;
    public UnityEvent onSameNumberCombine;
    [Header("�_�l���")]
    public int _initialBlocksNumber = 2;
    [Header("���v�ʤ���"), Range(1, 100)]
    public int _basicPresentage = 25;

    #endregion

    #region �D���}���

    [SerializeField]
    private Direction direction;
    [SerializeField]
    private StateTurn StateTurn;
    private BlockData[,] _blockData = new BlockData[4,4];
    private Vector3 _posDown;
    private Vector3 _posUp;
    private bool _isClick = false;

    #endregion

    #region �ƥ�

    private void Start() 
    { 
        Initialize();
    }

    private void Update()
    {
        if (StateTurn == StateTurn.My) { CheckDirection(); }
    }

    #endregion

    #region ��l��

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

    #region ������

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

    #region �üƦ�m����

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

        RandomBlock.goBlock.transform.Find("�Ʀr").GetComponent<Text>().text = RandomBlock.number.ToString();
    }

    #endregion

    #region ��V�T�{

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

    #region �T�{���ʤ�V

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
                    sameNumberCount = 0;              //�ۦP�Ʀr�X�֦����k�s

                    for (int j = _blockData.GetLength(1) - 2; j >= 0; j--)
                    {
                        blockOrigin = _blockData[i, j];

                        //�p�G�Ӱ϶��Ʀr���´N�~��(���L���j�� ����U�Ӱj��)
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
                            canMove = false;                         //�O�_�i�H���ʰ϶�
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

                        //�p�G�Ӱ϶��Ʀr���´N�~��(���L���j�� ����U�Ӱj��)
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
                            canMove = false;                         //�O�_�i�H���ʰ϶�
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

                        //�p�G�Ӱ϶��Ʀr���s�N�~��(���L���j�� ����U�Ӱj��)
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
                            canMove = false;                         //�O�_�i�H���ʰ϶�
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

                        //�p�G�Ӱ϶��Ʀr���s�N�~��(���L���j�� ����U�Ӱj��)
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
                            canMove = false;                         //�O�_�i�H���ʰ϶�
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

    #region ���ʤ��

    private void MoveBlock(BlockData blockOriginal, BlockData blockCheck, bool sameNumber)
    {
        #region ���ʰ϶�
        blockOriginal.goBlock.transform.position = blockCheck.Position;
        if (sameNumber)
        {
            int number = blockCheck.number * 2;
            blockCheck.number = number;
            Destroy(blockOriginal.goBlock);
            blockCheck.goBlock.transform.Find("�Ʀr").GetComponent<Text>().text = blockCheck.number.ToString();

            //�ۦP�Ʀr�X�֨ƥ� Ĳ�o
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
