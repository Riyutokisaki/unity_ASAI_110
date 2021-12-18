using UnityEngine;

/// <summary>
/// NPC
///偵測碰撞 顯示對話
/// </summary>

public class NPC : MonoBehaviour
{
    [Header("對話資料")]
    public DataDalogue dataDialogue;
    public DataDalogue dataDialogue2;
    [Header("對話系統")]
    public DialongueSystem dialongueSystem;
    [Header("觸發對象")]
    public string Player = "主角";
    [Header("已讀開關")]
    public bool Read;

    /// <summary>
    /// 進入觸發
    /// 1.兩個物件都要有 Collider 2D
    /// 2.兩個物件至少要有一個有 Rigidbody 2D
    /// 3.兩個物件有一個勾選 is Trugger
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.name == Player && !Read)
        {
            //print(collision.name);
            //將文字訊息給打字效果的Void
            dialongueSystem.StartDialogue(dataDialogue.NPC);
            
        }

        if (collision.name == Player && Read)
        {
            //print(collision.name);
            dialongueSystem.StartDialogue(dataDialogue2.NPC);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == Player)
        {
            dialongueSystem.StopDialogue();

            if(dataDialogue2 != null)
            {
                Read = true;
            }
        }
    }


 
}
