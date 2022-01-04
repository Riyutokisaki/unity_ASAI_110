using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ���s�P�I�s���O
/// </summary>
public class GameManager : MonoBehaviour
{
    #region ���
    [Header("GameOverUI��m�B")]
    public GameObject gameOverCanvas;
    #endregion
    private void Start()
    {
        Time.timeScale = 1;//�C���}�l���B���ɶ�
    }
    #region ��k
    public void GameOver()//��Player�IĲ��ê���ɷ|�Q�I�s
    {
        gameOverCanvas.SetActive(true);//���GameOverUI
        Time.timeScale = 0;//�ɶ��t�׬��s
    }

    /// <summary>
    /// ���s����
    /// </summary>
    public void ButtonHome()
    {
        SceneManager.LoadScene(0);
    }
    public void ButtonStory()
    {
        SceneManager.LoadScene(1);
    }
    public void ButtonGeneral()
    {
        SceneManager.LoadScene(2);
    }
    #endregion
}
