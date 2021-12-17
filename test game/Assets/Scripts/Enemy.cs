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
    public LayerMask layertarget;
    #endregion
}
