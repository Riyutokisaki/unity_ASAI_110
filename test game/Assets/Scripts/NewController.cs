using UnityEngine;

/// <summary>
/// ���ⱱ�
/// </summary>

public class NewController : MonoBehaviour
{
    #region ���}���
    [Header("���ʳt��"), Range(0,500)]
    public float Speed = 3.5f;
    [Header("���D����"), Range(0, 1500)]
    public float Jump = 300f;
    #endregion

    //���餸��
    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }
   
    //Update ��60FPS
    //�T�w��s�ƥ�:50FPS
    //�B�z���z�欰
    private void FixedUpdate()
    {
        Move();
    }

    # region ��k
    /// <summary>
    /// ���a�O�_����
    /// API Cassic Input GetAxis
    /// Vertical"����" Horizontal"����" 
    /// ��float
    /// </summary>
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        //���L����
        print("���a���k�����" + h);
    }
    #endregion
}
