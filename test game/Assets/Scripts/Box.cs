using UnityEngine;

/// <summary>
/// �p�G���a�I��c�l Death�ܼ��ܬ�Ture
/// </summary>
public class Box : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewController newController = collision.GetComponent<NewController>();
        newController.Death();
    }
}
