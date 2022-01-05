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
    public NewController player;
    private GameManager gameManager;
    #endregion
    private void Awake()
    {
        //�X�{����o�����W��manager.�̭���C#
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }
    void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //print("�I��F" + collision.gameObject);
        player = collision.gameObject.GetComponent<NewController>();
        //print("�I��F" + player);
        //�PTrigger���P���ϥΦr��P�_�A�ӬO���wGameObject
        //if (collision.gameObject == player)//�Y�I���쪺GameObject�Obox(��c#����ê�����W��)�h
        //{
            gameManager.GameOver();//�I�sgameManager����Game��k
        //}
    }
    #region ��k
    void Move()
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
    #endregion
}
