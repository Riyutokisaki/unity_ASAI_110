using UnityEngine;


public class ReRunway : MonoBehaviour
{
    #region ���

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("�I��F" + collision.gameObject);
        Destroy(collision.gameObject);

    }

 
}
