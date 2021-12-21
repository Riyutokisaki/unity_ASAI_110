using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class storyModeGameOverUI : MonoBehaviour
{
    #region 欄位
    [Header("GameOver系統UI")]
    public GameObject goDialogue;
    [Header("回首頁按鈕")]
    public Button Home;
    [Header("重新開始按鈕")]
    public Button Restart;
    #endregion
  
    public void Over()
    {
        ///<summary>
        ///顯示UI 
        ///讓按鈕可按
        /// </summary>
        goDialogue.SetActive(true);
        //暫時先重新關卡
        Application.LoadLevel("故事模式");

    }
}
