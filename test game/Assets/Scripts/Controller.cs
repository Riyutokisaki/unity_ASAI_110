using UnityEngine;

/// <summary>
/// 角色控制器
/// </summary>

public class Controller : MonoBehaviour
{
    #region 公開欄位
    [Header("移動速度"), Range(0,500)]
    public float Speed = 3.5f;
    [Header("跳躍高度"), Range(0, 1500)]
    public float Jump = 300f;
    [Header("檢查地板尺寸與位移"), Range(0, 1)]
    public float CheckGroundRadius = 0.1f;
    public Vector3 CheckGroundOffset;
    [Header("跳躍按鍵與可跳躍圖層")]
    public KeyCode keyJemp = KeyCode.Space;
    public LayerMask Layer;
    [Header("動畫參數")]//動畫控制器內的開關
    public string Walk = "isWalk";
    public string Up = "doTouch";
    public string Die = "死亡";
    [Header("遊戲管理")]
    public GameManager gameManager;
    [Header("障礙物")]
    public GameObject box;
    [Header("回首頁")]
    public GameObject backHome;
    [Header("碰到之後等幾秒"), Range(0, 50)]
    public float waitTime = 0.5f;
    [Header("音效")]
    public AudioSource audio;
    public AudioClip shootAudio;

    #endregion

    #region 私人欄位
    private Rigidbody2D rig;  //剛體元件
    private Animator an;  //動畫元件
    //[SerializeField]將私人欄位顯示在屬性面板(不能更改)
    private bool isGrounded;//是否在地上(否)
    //[SerializeField]
    private int doubleJump =0;//跳躍次數
    //[SerializeField]
    private bool speedRun;//跳了第1次了嗎?
    //等待動畫播畢
    private float ANTime;
    private bool isDie;
    //位置校正
    private Vector3 set;
    #endregion
    /// <summary>
    /// 繪製圖示
    /// 在unity繪製輔助用圖形
    /// 線條、射線、圓形、方形、圖片
    /// 圖示 Gizmos 類別
    /// </summary>
    private void OnDrawGizmos()
    {
        //1.決定顏色
        //2.決定繪製圖形
        //transform.position此物件的世界座標
        Gizmos.color = new Color(1, 0, 0.2f,0.3f);
        Gizmos.DrawSphere(transform.position + 
           transform.TransformDirection(CheckGroundOffset), CheckGroundRadius);// transform.TransformDirection()根據變形元件的區域座標轉換為世界座標

    }

    private void Start()
    {
        //在遊戲開始時讀取物件的剛體與動畫控制器
        rig = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        set = transform.position;
    }
   
    //Update 約60FPS
    //固定更新事件:50FPS
    //處理物理行為
    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Flip();
        CheckGround();
        KeyJump();
        if (isDie)
        {
            Wait();
        }
        
    }


    /// <summary>
    /// OnCollision(碰撞)與OnTrigger(觸發)不同在編寫時要注意
    /// 1.兩個物件都要有Collider且其中之一要有剛體(Rigidbody)元件
    /// 2.都 "不" 勾選IsTrigger
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
       //與Trigger不同不使用字串判斷，而是指定GameObject
        if (collision.gameObject == box)//若碰撞到的GameObject是box(此c#中障礙物的名稱)則
        {
            an.SetTrigger(Die);
            isDie = true;

        }

        if (collision.gameObject == backHome)//若碰撞到的GameObject是box(此c#中障礙物的名稱)則
        {
            gameManager.ButtonHome();//呼叫gameManager中的Game方法
        }
    }

    # region 方法
    /// <summary>
    /// 玩家是否移動
    /// API Cassic Input GetAxis
    /// Vertical"垂直" Horizontal"水平" 
    /// 為float
    /// </summary>
    private void Move()
    {
        float h = Input.GetAxis("Horizontal"); //按鍵輸入數值
        //rig.velocity = new Vector2(h * Speed, rig.velocity.y);//剛體元件.加速度 為 新的vector2(X軸為左右按鍵數值*速度,原先剛體加速度的垂直y數值)

        //當 水平值 不等於0(!=0) 勾選走路
        an.SetBool(Walk, h != 0);

        if (speedRun && h != 0 && Input.GetKeyDown("space"))
        {
            Speed++;
        }
        else if (h != 0 && Input.GetKeyDown("space"))
        {
            Speed = 5.5f;

            speedRun = true;
        }
        if (rig.velocity.x == 0)
        {
            Speed = 3.5f;

            speedRun = false;
        }
    }

    //翻面 h<往左Y軸角度180 h>往右y角度0
    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");

        if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(h > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }  
    
    private void CheckGround()
    {
        //偵測OnDrawGizmos畫出來的圓有沒有碰到地板
        //Physics2D-2D偵測 Circle圓形(2D)
        //碰撞資訊 = 2D 物理.覆蓋圓型(中心點,半徑,圖層)
        Collider2D hit = Physics2D.OverlapCircle(transform.position +
           transform.TransformDirection(CheckGroundOffset), CheckGroundRadius, Layer);
        //print("碰到的圖層" + hit.name);
        //將測定到的布林值觸發(是)
        isGrounded = hit;
        //如果角色在地板上 把二段跳觸發歸0
        if (isGrounded == true)
        {
            doubleJump = 0;
            if (transform.position.x>8.5f) transform.position = set;
        }
        //當物件不在地上勾選跳躍
        an.SetBool(Up, !isGrounded);
       
    }
    /// <summary>
    /// 跳躍方法
    /// </summary>
    private void KeyJump()
    {
        //如果 (二段跳觸發<2(跳躍次數))或是在地板上) 且 按下按鍵(空白鍵)
        if ((doubleJump <= 1 || isGrounded)&& Input.GetKeyDown("w"))
        {
            //剛體名稱(在欄位有寫).添加推力(新的二維向量(X.Y))(向上 填寫Y)
            rig.AddForce(new Vector2(0, Jump));
            Play(shootAudio);
            doubleJump++ ;
        }
        
    }

    void Wait()
    {
        if (ANTime < waitTime)
        {
            ANTime += Time.deltaTime;
        }
        else
        {
            gameManager.GameOver();//呼叫gameManager中的Game方法
        }

    }
    public void Play(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }
    #endregion
}
