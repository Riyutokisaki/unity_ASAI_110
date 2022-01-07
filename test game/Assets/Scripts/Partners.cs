using UnityEngine;
using UnityEngine.Events;

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
    public float speed = 0.2f;


    private Animator AN;//小夥伴動畫控制器
    public string walk = "走路";
    public string jump = "跳躍";
    public string die = "死亡";

    private Rigidbody2D RB;

    #endregion

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AN = GetComponent<Animator>();
        player = GameObject.Find("Player");
        plTransform = player.transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            AN.SetTrigger(jump);
            get = true;
            GetPartners();
        }
    }

    void GetPartners()
    {
        if (plTransform.position.x > transform.position.x)//玩家位置大於夥伴位置(在左邊)
        {
            RB.velocity = new Vector2(plTransform.position.x, transform.position.y);
        }
    }
}
