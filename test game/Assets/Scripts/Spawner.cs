using UnityEngine;

/// <summary>
/// 自動產生物件
/// </summary>
public class Spawner : MonoBehaviour
{
    #region 欄位
    public float maxtime = 1f;

    private float timer = 0f;

    [Header("生成物件")]
    public GameObject box;

    public float hight;
    #endregion

    private void Start()
    {
        GameObject newbox = Instantiate(box);
        newbox.transform.position = transform.position + new Vector3(0, Random.Range(-hight, hight), 0);
    }

    private void Update()
    {
        if (timer > maxtime)
        {
            GameObject newbox = Instantiate(box);
            newbox.transform.position = transform.position + new Vector3(0, Random.Range(-hight, hight), 0);
            Destroy(newbox, 15);
            
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
