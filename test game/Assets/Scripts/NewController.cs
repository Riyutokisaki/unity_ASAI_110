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
    [Header("�ˬd�a�O�ؤo�P�첾"), Range(0, 1)]
    public float CheckGroundRadius = 0.1f;
    public Vector3 CheckGroundOffset;
    [Header("���D����P�i���D�ϼh")]
    public KeyCode keyJemp = KeyCode.Space;
    public LayerMask Layer;

    #endregion

    //���餸��
    private Rigidbody2D rig;

    /// <summary>
    /// ø�s�ϥ�
    /// �bunityø�s���U�ιϧ�
    /// �u���B�g�u�B��ΡB��ΡB�Ϥ�
    /// �ϥ� Gizmos ���O
    /// </summary>
    private void OnDrawGizmos()
    {
        //1.�M�w�C��
        //2.�M�wø�s�ϧ�
        //transform.position�����󪺥@�ɮy��
        Gizmos.color = new Color(1, 0, 0.2f,0.3f);
        Gizmos.DrawSphere(transform.position + 
           transform.TransformDirection(CheckGroundOffset), CheckGroundRadius);// transform.TransformDirection()�ھ��ܧΤ��󪺰ϰ�y���ഫ���@�ɮy��

    }

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

    private void Update()
    {
        Flip();
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

        rig.velocity = new Vector2(h * Speed, rig.velocity.y);//���餸��.�[�t�� �� �s��vector2(X�b�����k����ƭ�*�t��,�������[�t�ת�����y�ƭ�)
    }


    //½�� h<����Y�b����180 h>���ky����0
    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");

        if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(h > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }  
    


    #endregion
}
