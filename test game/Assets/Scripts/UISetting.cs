using UnityEngine;

public class UISetting : MonoBehaviour
{
    public void clickstory()
    {
        Application.LoadLevel(1);
        print("���U�F�G�ƼҦ�");
    }
    public void clickMenu()
    {
        Application.LoadLevel(0);
        print("�^��F����");
    }
    public void clickGeneral()
    {
        Application.LoadLevel(2);
        print("���U�F�@��Ҧ�");
    }
}
