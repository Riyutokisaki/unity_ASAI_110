using UnityEngine;

/// <summary>
/// 敵人行為
/// 檢測目標物件是否在追蹤區域
/// 追蹤與攻擊目標
/// </summary>
public class Enemy : MonoBehaviour
{
    #region 欄位
    [Header("檢查追蹤區域大小與位移")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrsckOffset;
    [Header("移動速度")]
    public float speed = 3.5f;
    [Header("目標圖層")]
    public LayerMask layerTarget;
    [Header("動畫控制")]
    public string walk = "走路";
    public string jump = "跳躍";
    public string die = "死亡";
    [Header("面向目標物件")]
    public Transform target;
    [Header("攻擊距離"), Range(0, 5)]
    public float attackDistanca = 1.3f;
    [Header("攻擊冷卻"),Range(0,10)]
    public float attackcold = 2.8f;

    private float angle = 0;
    private Rigidbody2D rig;
    private Animator ani;

    #endregion
    #region 事件
    private void OnDrawGizmos()
    {
        //指定顏色
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        //繪製立方體(中心,尺吋)
        Gizmos.DrawCube(transform.position +transform.TransformDirection(v3TrsckOffset),v3TrackSize);
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        CheckTargetInArea();
    }
    #endregion

    #region 方法
    /// <summary>
    /// 檢查目標是否在區域內
    /// </summary>
    void CheckTargetInArea()
    {
        //2D 物理.覆蓋盒型(中心,尺寸,角度)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrsckOffset), v3TrackSize, 0,layerTarget);

        if (hit) Move(); 
    }

    private void Move()
    {   
        //如果 目標的X < 敵人的X就代表左邊 角度 0
        //如果 目標的X > 敵人的X就代表左邊 角度 180
        if (target.position.x > transform.position.x)
        {
            angle = 180;//右邊
        }
        else if (target.position.x < transform.position.x)
        {
            angle = 0;//左邊 
        }
        //三元運算子語法 : 布林值 ? 當布林值 為 true : 當布林值 為false ;
        angle = target.position.x > transform.position.x ? 180 : 0;//翻面

        transform.eulerAngles = Vector3.up * angle;//更新角色角度

        rig.velocity = transform.TransformDirection(new Vector2(-speed, rig.velocity.y));
        ani.SetBool(walk, true);

        //距離=三維向量.距離(A點,B點) 導出float 可用於2、3、4
        float distance = Vector3.Distance(target.position, transform.position);
        print("與目標距離" + distance);


        if (distance <= attackDistanca)//如果距離小於等於攻擊距離
        {
            rig.velocity = Vector3.zero;//停止
        }
    }
    #endregion
}
