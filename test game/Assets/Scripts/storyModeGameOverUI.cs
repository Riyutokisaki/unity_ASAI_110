using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class storyModeGameOverUI : MonoBehaviour
{
    #region ���
    [Header("GameOver�t��UI")]
    public GameObject goDialogue;
    [Header("�^�������s")]
    public Button Home;
    [Header("���s�}�l���s")]
    public Button Restart;
    #endregion
  
    public void Over()
    {
        ///<summary>
        ///���UI 
        ///�����s�i��
        /// </summary>
        goDialogue.SetActive(true);
        //�Ȯɥ����s���d
        Application.LoadLevel("�G�ƼҦ�");

    }
}
