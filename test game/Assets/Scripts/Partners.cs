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
    public GameObject player;//碰觸對象
    public Transform plTransform;
    public float speed = 0.05f;
    [Header("碰到之後等幾秒"), Range(0, 50)]
    public float waitTime = 0.5f;
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
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Scene scene= SceneManager.GetActiveScene();
        if (scene.name == "故事模式") story = true;
        AN = GetComponent<Animator>();
        player = GameObject.Find("主角");
        plTransform = player.transform;
        
        //tigger = GetComponent<Collider2D>().isTrigger;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("碰到了" + collision.gameObject.name);
        if (collision.gameObject.name == "主角")
        {
            AN.SetTrigger(jump);
            get = true;
            GetPartners();
        }
        if (collision.gameObject == box && get)//若碰撞到的GameObject是box(此c#中障礙物的名稱)則
        {
            AN.SetTrigger(die);
            gameManager.GameOver();

        }
        if (collision.gameObject.tag == "Finish" && get)//若碰撞到的GameObject是box(此c#中障礙物的名稱)則
        {
            AN.SetTrigger(die);
            
            gameManager.GameOver();

        }
    }
    private void FixedUpdate()
    {
        if (get)
        {
            GetPartners();
        }
        else if(!story)
        {
            Move();
        }
    }

    void GetPartners()
    {
        //tigger=true;
        transform.position = new Vector3(plTransform.position.x - distance, plTransform.position.y, Time.deltaTime);
        //RB.MovePosition(plTransform.position);
        float h = Input.GetAxis("Horizontal");
        if (h != 0) AN.SetTrigger(walk);
        if (transform.position.y > 0)
        {
            AN.SetTrigger(jump);
           
        }
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

}
