using UnityEngine;

//�إ߱M�פ������(menuName = "���W��") ��Ƨ�/�l��Ƨ�
[CreateAssetMenu(menuName = "Say/��ܸ��")]

///<summary>
///��ܸ��
///�O�sNPC�n�򪱮a������ܤ��e
/// </summary>
/// Scriptable Object �}���ƪ���:�N�{������x�s��Project��������
public class DataDalogue : ScriptableObject
{
    //Text Area(�̤p���,�̤j��� -�ȭ�string
    [Header("��ܤ��e"), TextArea(3, 5)]
    public string[] NPC;
}
