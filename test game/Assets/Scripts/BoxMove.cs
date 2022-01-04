using UnityEngine;

/// <summary>
/// 控制障礙物移動
/// </summary>
public class BoxMove : MonoBehaviour
{
    #region 欄位
    [Header("箱子移動速度")]
    public float speed =0.05f;
    [Header("偵測碰撞")]
    public GameObject player;
    private GameManager gameManager;
    #endregion
    private void Start()
    {
        player = GameObject.Find("Player");
        
    }
    void FixedUpdate()
    {
        //設定欄位h收按鍵輸入
        float h = Input.GetAxis("Horizontal");
        if (h > 0)//當按鍵輸入大於0(角色往右)
        {
            transform.position += Vector3.left * speed;//則障礙物的位置+=位置往左*速度
        }
        else if (h < 0)//當按鍵輸入小於0(角色往左)
        {
            transform.position += Vector3.right * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //與Trigger不同不使用字串判斷，而是指定GameObject
        if (collision.gameObject == player)//若碰撞到的GameObject是box(此c#中障礙物的名稱)則
        {
            gameManager.GameOver();//呼叫gameManager中的Game方法
        }
    }
    #region 方法

    #endregion
}
