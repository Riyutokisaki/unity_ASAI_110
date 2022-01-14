using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
///當get為false(還沒遇到player時)在原地不動(需與場景一同動作)
///碰到player會彈一下
///當player碰觸到朋友時，開get的布林值
///讓朋友跟隨於player後方
///延遲幾秒重複player動作
///動畫開關
/// </summary>
public class Partners : MonoBehaviour
{
    #region 欄位
    [Header("抓到!")]
    public bool get = false;//Player碰到沒
    [Header("碰觸對象")]
    public GameObject player;
    [Header("玩家位置")]
    public Transform plTransform;
    [Header("移動速度")]
    public float speed = 0.05f;
    [Header("遊戲管理")]
    public GameManager gameManager;
    [Header("動畫")]
    private Animator AN;//小夥伴動畫控制器
    public string walk = "走路";
    public string jump = "跳躍";
    public string die = "死亡";
    [Header("障礙物")]
    public GameObject box;
    [Header("模式開關")]
    private bool story;
    [Header("位置調整"), Range(0, 10)]
    public float distance = 1.15f;

    #endregion
 
    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();//取得場景中的遊戲管理
        Scene scene= SceneManager.GetActiveScene();//取得場景名稱
        if (scene.name == "故事模式") story = true;//如果場景名稱等於"故事模式"bool開啟
        AN = GetComponent<Animator>();//獲得動畫控制器
        player = GameObject.Find("主角");//取得玩家物件
        plTransform = player.transform;//取得玩家位置
        
        //tigger = GetComponent<Collider2D>().isTrigger;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("碰到了" + collision.gameObject.name);
        if (collision.gameObject.name == "主角")//如果碰到的是玩家
        {
            AN.SetTrigger(jump);//播放跳躍動畫
            get = true;//開啟BOOL(拿到了朋友)
            GetPartners();//呼叫
        }
        if (collision.gameObject == box && get)//若碰撞到的GameObject是box則
        {
            AN.SetTrigger(die);//播放死亡動畫
            gameManager.GameOver();//呼叫遊戲管理開GameOverUI

        }
        if (collision.gameObject.tag == "Finish" && get)//若碰撞到的GameObject在Finish圖層(FOR一般模式
        {
            AN.SetTrigger(die);
            gameManager.GameOver();

        }
    }
    private void FixedUpdate()
    {
        if (get)//如過GET開著 重複執行
        {
            GetPartners();
        }
        else if(!story)//當關卡不等於故事模式(一般)他會像箱子移動
        {
            Move();
        }
    }

    #region 方法
    void GetPartners()
    {
        //tigger=true;
        transform.position = new Vector3(plTransform.position.x - distance, plTransform.position.y, Time.deltaTime);//位置移動到玩家後面
        //RB.MovePosition(plTransform.position);
        float h = Input.GetAxis("Horizontal");
        if (h != 0) AN.SetTrigger(walk);//移動動畫播放
        if (transform.position.y > 0) AN.SetTrigger(jump);//高於一定高度播放跳躍
       
    }

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
