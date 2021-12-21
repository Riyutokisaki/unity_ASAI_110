using UnityEngine;

/// <summary>
/// 如果玩家碰到箱子 Death變數變為Ture
/// </summary>
public class Box : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewController newController = collision.GetComponent<NewController>();
        newController.Death();
    }
}
