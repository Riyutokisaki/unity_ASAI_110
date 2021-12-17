using UnityEngine;

/// <summary>
/// NPC
///�����I�� ��ܹ��
/// </summary>

public class NPC : MonoBehaviour
{
    [Header("��ܸ��")]
    public DataDalogue dataDialogue;
    [Header("��ܨt��")]
    public DialongueSystem dialongueSystem;
    [Header("Ĳ�o��H")]
    public string Player = "�D��";

    /// <summary>
    /// �i�JĲ�o
    /// 1.��Ӫ��󳣭n�� Collider 2D
    /// 2.��Ӫ���ܤ֭n���@�Ӧ� Rigidbody 2D
    /// 3.��Ӫ��󦳤@�ӤĿ� is Trugger
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
