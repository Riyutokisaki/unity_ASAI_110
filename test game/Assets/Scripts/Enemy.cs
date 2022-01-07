using UnityEngine;

/// <summary>
/// �ĤH�欰
/// �˴��ؼЪ���O�_�b�l�ܰϰ�
/// �l�ܻP�����ؼ�
/// </summary>
public class Enemy : MonoBehaviour
{
    #region ���
    [Header("�ˬd�l�ܰϰ�j�p�P�첾")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrsckOffset;
    [Header("���ʳt��")]
    public float speed = 3.5f;
    [Header("�ؼйϼh")]
    public LayerMask layerTarget;
    [Header("�ʵe����")]
    public string walk = "����";
    public string jump = "���D";
    public string die = "���`";
    [Header("���V�ؼЪ���")]
    public Transform target;
    [Header("�����Z��"), Range(0, 5)]
    public float attackDistanca = 1.3f;
    [Header("�����N�o"),Range(0,10)]
    public float attackcold = 2.8f;

    private float angle = 0;
    private Rigidbody2D rig;
    private Animator ani;

    #endregion
    #region �ƥ�
    private void OnDrawGizmos()
    {
        //���w�C��
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        //ø�s�ߤ���(����,�ئT)
        Gizmos.DrawCube(transform.position +transform.TransformDirection(v3TrsckOffset),v3TrackSize);
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        CheckTargetInArea();
    }
    #endregion

    #region ��k
    /// <summary>
    /// �ˬd�ؼЬO�_�b�ϰ줺
    /// </summary>
    void CheckTargetInArea()
    {
        //2D ���z.�л\����(����,�ؤo,����)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrsckOffset), v3TrackSize, 0,layerTarget);

        if (hit) Move(); 
    }

    private void Move()
    {   
        //�p�G �ؼЪ�X < �ĤH��X�N�N���� ���� 0
        //�p�G �ؼЪ�X > �ĤH��X�N�N���� ���� 180
        if (target.position.x > transform.position.x)
        {
            angle = 180;//�k��
        }
        else if (target.position.x < transform.position.x)
        {
            angle = 0;//���� 
        }
        //�T���B��l�y�k : ���L�� ? ���L�� �� true : ���L�� ��false ;
        angle = target.position.x > transform.position.x ? 180 : 0;//½��

        transform.eulerAngles = Vector3.up * angle;//��s���⨤��

        rig.velocity = transform.TransformDirection(new Vector2(-speed, rig.velocity.y));
        ani.SetBool(walk, true);

        //�Z��=�T���V�q.�Z��(A�I,B�I) �ɥXfloat �i�Ω�2�B3�B4
        float distance = Vector3.Distance(target.position, transform.position);
        print("�P�ؼжZ��" + distance);


        if (distance <= attackDistanca)//�p�G�Z���p�󵥩�����Z��
        {
            rig.velocity = Vector3.zero;//����
        }
    }
    #endregion
}
