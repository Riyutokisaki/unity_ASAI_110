using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialongueSystem : MonoBehaviour
{
    #region ���
    [Header("��ܶ���"), Range(0, 1)]
    public float interval = 0.2f;
    [Header("�W�ٿ�J")]
    public Text textTito;
    [Header("�e����ܨt��UI")]
    public GameObject goDialogue;
    [Header("��ܨt�Τ��e")]
    public Text textContent;
    [Header("�q�������ϥ�")]
    public GameObject goTip;
    [Header("��ܫ���")]
    public KeyCode key = KeyCode.Mouse0;

    #endregion

    void Start()
    {
      //StartCoroutine(TypeEffect());
    }

    /// <summary>
    /// ���r�ĪG
    /// </summary>
    /// <returns></returns>
  private IEnumerator TypeEffect(string[] contents)
    {
        //��ܤ�r
        //string test1 = "test tipe";
        //string test2 = "test tipe22222";
        //string[] contents = { test1, test2 };

        goDialogue.SetActive(true);//��ܹ�ܪ��� �ѦҶ���UnityEngine.UI

        //���Ҧ����
        for (int j = 0; j < contents.Length; j++)
        {
            textContent.text = "";//�M���W����ܤ��e
            goTip.SetActive(false);
            //for�j��(�ѷ� ; �ѷ�<���դ�r�`�r��;�ѷ�++)
            for (int i = 0; i < contents[j].Length; i++)
            {
                //print(test[i]); ���X���դ�r����[i]�Ӧr
                textContent.text += contents[j][i];//��אּ�|�[��ܤ�r���� ���W��.text(�̭����ݩ�)
                yield return new WaitForSeconds(interval); //����(interval)��
            }

            goTip.SetActive(true);//��ܹϥ�

            while (!Input.GetKeyDown(key))//���a�S������ܫ���ɫ������
            {
                yield return null;//���� unll�@�Ӽv��ɶ�
            }
        }
        goDialogue.SetActive(false); //���ù�ܪ���
    }

    /// <summary>
    /// �}�l���
    /// </summary>
    /// <param name="contents">��ܥ��r�ĪG����ܤ��e</param>
    public void StartDialogue(string[] contents)
    {
        StartCoroutine(TypeEffect(contents));
    }

    /// <summary>
    /// ������
    /// </summary>
    public void StopDialogue()
    {
        StopAllCoroutines();
        goDialogue.SetActive(false);
    }
}
