using UnityEngine;


public class ReRunway : MonoBehaviour
{
    #region Äæ¦ì

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("¸I¨ì¤F" + collision.gameObject);
        Destroy(collision.gameObject);

    }

 
}
