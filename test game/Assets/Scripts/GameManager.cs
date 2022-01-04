using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 按鈕與呼叫面板
/// </summary>
public class GameManager : MonoBehaviour
{
    #region 欄位
    [Header("GameOverUI放置處")]
    public GameObject gameOverCanvas;
    #endregion
    private void Start()
    {
        Time.timeScale = 1;//遊戲開始時矯正時間
    }
    #region 方法
    public void GameOver()//當Player碰觸障礙物時會被呼叫
    {
        gameOverCanvas.SetActive(true);//顯示GameOverUI
        Time.timeScale = 0;//時間速度為零
    }

    /// <summary>
    /// 按鈕控制
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
