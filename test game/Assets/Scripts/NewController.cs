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
    #endregion

    //剛體元件
    private Rigidbody2D rig;

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
    }
    #endregion
}
