using UnityEngine;

/// <summary>
/// �۰ʲ��ͪ���
/// </summary>
public class Spawner : MonoBehaviour
{
    #region ���
    public float maxtime = 4f;
    private float timer = 0f;

    [Header("�ͦ�����")]
    public GameObject[] box;

    public float hight =2f;
    #endregion

    private void Awake()
    {
        GameObject newbox = Instantiate(box[0]);
        newbox.transform.position = transform.position + new Vector3(0, Random.Range(-hight, hight), 0);
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        if (timer > maxtime && h != 0)
        {
            GameObject newbox = Instantiate(box[0]);
            GameObject newCloud = Instantiate(box[1]);
            newCloud.transform.position = transform.position + new Vector3(0, Random.Range(hight*5, hight*10), 0);
            newbox.transform.position = transform.position + new Vector3(0, Random.Range(-hight, hight), 0);
            

            timer = 0;
        }
        timer += Time.deltaTime;
        
    }
}
