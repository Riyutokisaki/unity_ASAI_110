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
    private void Awake()
    {
        //出現後取得場景上的manager.裡面的C#
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        player = GameObject.Find("主角");

        Destroy(gameObject, 20f);
    }
    void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        //bool getBool = collision.gameObject.GetComponent<Partners>().get;

        //print("碰到了" + player);
        //與Trigger不同不使用字串判斷，而是指定GameObject
        if ((collision.gameObject == player) )//|| getBool
        {  
            print("碰到了" + collision.gameObject);
            gameManager.GameOver();
        }//呼叫gameManager中的Game方法//若碰撞到的GameObject是box(此c#中障礙物的名稱)則
       
    }
    #region 方法
    void Move()
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
    #endregion
}
