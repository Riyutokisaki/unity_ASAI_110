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
    public LayerMask layertarget;
    #endregion
}
