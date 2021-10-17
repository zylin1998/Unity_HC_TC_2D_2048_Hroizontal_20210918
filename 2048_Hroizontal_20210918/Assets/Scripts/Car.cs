// 單行註解：說明文字，不執行@#
// 功能 2021.10.17
// 開發者 KID 2021.10.17
using UnityEngine;  // 引用 Unity Engine API

// class 類別(藍圖) 名稱要跟檔名相同，大小寫也要相同
public class Car : MonoBehaviour
{
    // 認識欄位 Field，儲存資料
    // 語法：
    // 資料類型 欄位名稱 指定 預設值 結束符號
    // 常用基本四大資料類型
    // 1. 整數　 沒有小數點的正負整數 int    預設值 0
    // 2. 浮點數 有小數點的正負整數　 float  預設值 0
    // 3. 字串　 文字資訊            string 預設值 空
    // 4. 布林值 是與否 true、false  bool   預設值 false
    int cc = 2000;
    float weight = 3.5f;
    string brand = "賓士";
    bool hasSkyWindow = true;
}
