using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialongueSystem : MonoBehaviour
{
    #region ���
    [Header("��ܶ���"), Range(0, 1)]
    public float interval = 0.3f;
    [Header("�e����ܨt��")]
    public GameObject goDialogue;
    [Header("��ܤ��e")]
    public Text textContent;
    #endregion

    void Start()
    {
        StartCoroutine(TypeEffect());
    }

  private IEnumerator TypeEffect()
    {
        //��ܤ�r
        string test = "test tipe";

        textContent.text = "";//�M���W����ܤ��e
        goDialogue.SetActive(true);//��ܹ�ܪ��� �ѦҶ���UnityEngine.UI

        //for�j��(�ѷ� ; �ѷ�<���դ�r�`�r��;�ѷ�++)
        for (int i = 0; i < test.Length; i++)
        {
            //print(test[i]); ���X���դ�r����[i]�Ӧr
            textContent.text += test[i];//��אּ�|�[��ܤ�r���� ���W��.text(�̭����ݩ�)
            yield return new WaitForSeconds(interval); //����(interval)��
        }
    }
}
