// 單行註解：說明文字，不執行@#
// 功能 2021.10.17
// 開發者 KID 2021.10.17
using UnityEngine;  // 引用 Unity Engine API

// class 類別(藍圖) 名稱要跟檔名相同，大小寫也要相同
public class Car : MonoBehaviour
{
    #region 欄位語法與四大基本類型
    // 認識欄位 Field，儲存資料
    // 語法：
    // 修飾詞 資料類型 欄位名稱 指定 預設值 結束符號
    // 常用基本四大資料類型
    // 1. 整數　 沒有小數點的正負整數 int    預設值 0
    // 2. 浮點數 有小數點的正負整數　 float  預設值 0
    // 3. 字串　 文字資訊            string 預設值 空
    // 4. 布林值 是與否 true、false  bool   預設值 false
    // 修飾詞
    // 私人 僅限此類別存取 Unity 不顯示 private (預設)
    // 公開 所有類別可存取 Unity 會顯示 public

    // 欄位屬性 Attritube
    // 語法：
    // [屬性名稱(值)] - 必須放在欄位前面或上一行
    // 1. 標題 Header (字串)
    // 2. 提示 Tooltip (字串)
    // 3. 範圍 Range (浮點數，浮點數)
    [Header("汽車的 CC 數")][Range(1000, 5000)]
    public int cc = 10;
    [Tooltip("這是汽車的重量，範圍是 3 ~ 20"), Range(3, 20)]
    public float weight = 3.5f;
    public string brand = "賓士";
    public bool hasSkyWindow = true;
    #endregion

    #region 遊戲內常用資料類型
    // 顏色 Color
    public Color color1;
    public Color colorRed = Color.red;
    public Color colorCustom = new Color(0, 0, 1);
    public Color colorCustomAlpga = new Color(0, 1, 0, 0.3f);
    // 向量 (座標) Vector
    // Vector 2 - 4
    public Vector2 v2;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v2Custom = new Vector2(7, 9);
    public Vector3 v3Custom = new Vector3(1, 2, 3);
    public Vector4 v4Custom = new Vector4(1, 2, 3, 4);
    // 按鍵 KeyCode
    public KeyCode kc;
    public KeyCode kcW = KeyCode.W;
    public KeyCode kcML = KeyCode.Mouse0;

    // 遊戲物件 GameObject 不須指定預設值
    public GameObject carBox;
    public GameObject carOil;
    // 元件 Component 不須指定預設值
    public Transform traBox;
    public SpriteRenderer sprBox;
    public Camera cam;
    #endregion

    #region 存取欄位資料 Set Get

    // 程式入口：事件
    // 開始事件：播放遊戲時執行一次，初始設定
    private void Start()
    {
        print("哈囉，沃德 :D");

        // 取得 Get 欄位資料 ※ 預設值以屬性面板為主 (Inspector)
        // 語法：
        // 欄位名稱
        print("CC 數：" + cc);
        print(weight);

        // 存放 Set 欄位資料
        // 語法：
        // 欄位名稱 指定 值；
        brand = "BMW";
        cc = 3500;
    }
    #endregion
}
