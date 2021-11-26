using UnityEngine;

/// <summary>
/// 角色控制器
/// </summary>

public class NewController : MonoBehaviour
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

    #endregion

    //剛體元件
    private Rigidbody2D rig;

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
        rig = GetComponent<Rigidbody2D>();

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
        float h = Input.GetAxis("Horizontal");
        //打印測試
        print("玩家左右按鍵值" + h);

        rig.velocity = new Vector2(h * Speed, rig.velocity.y);//剛體元件.加速度 為 新的vector2(X軸為左右按鍵數值*速度,原先剛體加速度的垂直y數值)
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
    


    #endregion
}
