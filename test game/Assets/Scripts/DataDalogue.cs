using UnityEngine;

//建立專案內的選單(menuName = "選單名稱") 資料夾/子資料夾
[CreateAssetMenu(menuName = "Say/對話資料")]

///<summary>
///對話資料
///保存NPC要跟玩家說的對話內容
/// </summary>
/// Scriptable Object 腳本化物件:將程式資料儲存至Project內的物件
public class DataDalogue : ScriptableObject
{
    //Text Area(最小行數,最大行數 -僅限string
    [Header("對話內容"), TextArea(3, 5)]
    public string[] NPC;
}
