using UnityEngine;

/// <summary>
/// �����ê������
/// </summary>
public class BoxMove : MonoBehaviour
{
    #region ���
    [Header("�c�l���ʳt��")]
    public float speed =0.05f;
    [Header("�����I��")]
    public GameObject player;
    private GameManager gameManager;
    #endregion
    private void Start()
    {
        player = GameObject.Find("Player");
        
    }
    void FixedUpdate()
    {
        //�]�w���h�������J
        float h = Input.GetAxis("Horizontal");
        if (h > 0)//������J�j��0(���⩹�k)
        {
            transform.position += Vector3.left * speed;//�h��ê������m+=��m����*�t��
        }
        else if (h < 0)//������J�p��0(���⩹��)
        {
            transform.position += Vector3.right * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�PTrigger���P���ϥΦr��P�_�A�ӬO���wGameObject
        if (collision.gameObject == player)//�Y�I���쪺GameObject�Obox(��c#����ê�����W��)�h
        {
            gameManager.GameOver();//�I�sgameManager����Game��k
        }
    }
    #region ��k

    #endregion
}
