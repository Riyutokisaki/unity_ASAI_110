using UnityEngine;

public class UISetting : MonoBehaviour
{
    public void clickstory()
    {
        Application.LoadLevel(1);
        print("按下了故事模式");
    }
    public void clickMenu()
    {
        Application.LoadLevel(0);
        print("回到了首頁");
    }
    public void clickGeneral()
    {
        Application.LoadLevel(2);
        print("按下了一般模式");
    }
}
