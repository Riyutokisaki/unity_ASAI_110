using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialongueSystem : MonoBehaviour
{
    #region 欄位
    [Header("對話間格"), Range(0, 1)]
    public float interval = 0.2f;
    [Header("名稱輸入")]
    public Text textTito;
    [Header("畫布對話系統UI")]
    public GameObject goDialogue;
    [Header("對話系統內容")]
    public Text textContent;
    [Header("段落完成圖示")]
    public GameObject goTip;
    [Header("對話按鍵")]
    public KeyCode key = KeyCode.Mouse0;

    #endregion

    void Start()
    {
      //StartCoroutine(TypeEffect());
    }

    /// <summary>
    /// 打字效果
    /// </summary>
    /// <returns></returns>
  private IEnumerator TypeEffect(string[] contents)
    {
        //顯示文字
        //string test1 = "test tipe";
        //string test2 = "test tipe22222";
        //string[] contents = { test1, test2 };

        goDialogue.SetActive(true);//顯示對話物件 參考項目UnityEngine.UI

        //找到所有對話
        for (int j = 0; j < contents.Length; j++)
        {
            textContent.text = "";//清除上次對話內容
            goTip.SetActive(false);
            //for迴圈(參照 ; 參照<測試文字總字數;參照++)
            for (int i = 0; i < contents[j].Length; i++)
            {
                //print(test[i]); 打出測試文字的第[i]個字
                textContent.text += contents[j][i];//更改為疊加對話文字介面 欄位名稱.text(裡面的屬性)
                yield return new WaitForSeconds(interval); //等待(interval)秒
            }

            goTip.SetActive(true);//顯示圖示

            while (!Input.GetKeyDown(key))//當玩家沒有按對話按鍵時持續執行
            {
                yield return null;//等待 unll一個影格時間
            }
        }
        goDialogue.SetActive(false); //隱藏對話物件
    }

    /// <summary>
    /// 開始對話
    /// </summary>
    /// <param name="contents">顯示打字效果的對話內容</param>
    public void StartDialogue(string[] contents)
    {
        StartCoroutine(TypeEffect(contents));
    }

    /// <summary>
    /// 停止對話
    /// </summary>
    public void StopDialogue()
    {
        StopAllCoroutines();
        goDialogue.SetActive(false);
    }
}
