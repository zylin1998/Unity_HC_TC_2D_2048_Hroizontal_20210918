using UnityEngine;

public class LearnProperty : MonoBehaviour
{
    // 欄位
    public int passwordField = 123456789;

    // 屬性 Property
    // 語法：
    // 修飾詞 資料類型 屬性名稱 { 存取子 }
    // 自動實作
    public int passwordProperty { get; set; }

    // get 取得
    // set 設定
    // 唯讀屬性 只能取得
    // => 黏巴達 Lambda C# 6.0
    public int myPasswordProperty { get => 999; }

    // 唯讀完整寫法
    // get 需使用關鍵字 return 傳回
    public string nameCharacter
    {
        get
        {
            print("我在屬性 name Character 裡面~");
            return "KID";
        }
    }
    // 唯寫完整寫法
    // set 使用關鍵字 value 輸入值
    public float attack
    {
        set
        {
            print("攻擊力：" + value);
        }
    }

    // 開始事件：播放時執行一次
    private void Start()
    {
        // 存放 Set 屬性資料
        // 語法：
        // 屬性名稱 指定 值；
        passwordProperty = 777;
        // 取得 Get 屬性資料
        // 語法：
        // 屬性名稱
        print("屬性密碼：" + passwordProperty);

        // myPasswordProperty = 999;    // 不能設定 唯讀屬性
        print("我的屬性密碼：" + myPasswordProperty);

        print(nameCharacter);

        // print(attack);               // 不能取得 唯寫屬性
        attack = 99.9f;
    }
}
