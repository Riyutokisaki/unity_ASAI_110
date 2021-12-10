using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialongueSystem : MonoBehaviour
{
    #region 欄位
    [Header("對話間格"), Range(0, 1)]
    public float interval = 0.3f;
    [Header("畫布對話系統")]
    public GameObject goDialogue;
    [Header("對話內容")]
    public Text textContent;
    #endregion

    void Start()
    {
        StartCoroutine(TypeEffect());
    }

  private IEnumerator TypeEffect()
    {
        //顯示文字
        string test = "test tipe";

        textContent.text = "";//清除上次對話內容
        goDialogue.SetActive(true);//顯示對話物件 參考項目UnityEngine.UI

        //for迴圈(參照 ; 參照<測試文字總字數;參照++)
        for (int i = 0; i < test.Length; i++)
        {
            //print(test[i]); 打出測試文字的第[i]個字
            textContent.text += test[i];//更改為疊加對話文字介面 欄位名稱.text(裡面的屬性)
            yield return new WaitForSeconds(interval); //等待(interval)秒
        }
    }
}
