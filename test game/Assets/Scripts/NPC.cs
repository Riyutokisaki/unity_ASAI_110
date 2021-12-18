using UnityEngine;

/// <summary>
/// NPC
///�����I�� ��ܹ��
/// </summary>

public class NPC : MonoBehaviour
{
    [Header("��ܸ��")]
    public DataDalogue dataDialogue;
    public DataDalogue dataDialogue2;
    [Header("��ܨt��")]
    public DialongueSystem dialongueSystem;
    [Header("Ĳ�o��H")]
    public string Player = "�D��";
    [Header("�wŪ�}��")]
    public bool Read;

    /// <summary>
    /// �i�JĲ�o
    /// 1.��Ӫ��󳣭n�� Collider 2D
    /// 2.��Ӫ���ܤ֭n���@�Ӧ� Rigidbody 2D
    /// 3.��Ӫ��󦳤@�ӤĿ� is Trugger
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.name == Player && !Read)
        {
            //print(collision.name);
            //�N��r�T�������r�ĪG��Void
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
