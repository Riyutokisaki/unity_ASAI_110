using UnityEngine;

/// <summary>
/// NPC
///偵測碰撞 顯示對話
/// </summary>

public class NPC : MonoBehaviour
{
    [Header("對話資料")]
    public DataDalogue dataDialogue;
    [Header("對話系統")]
    public DialongueSystem dialongueSystem;
    [Header("觸發對象")]
    public string Player = "主角";

    /// <summary>
    /// 進入觸發
    /// 1.兩個物件都要有 Collider 2D
    /// 2.兩個物件至少要有一個有 Rigidbody 2D
    /// 3.兩個物件有一個勾選 is Trugger
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Player)
        {
            
            //print(collision.name);
            dialongueSystem.StartDialogue(dataDialogue.NPC);
        
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == Player)
        {
            dialongueSystem.StopDialogue();
        }
    }

}
