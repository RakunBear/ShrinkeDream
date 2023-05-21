using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public float mainTime = 2f;
    public GameObject MainPrefab;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //����, ������ �ΰ� �԰� Ż��
            if (SceneManager.GetActiveScene().name == "Dream")
            {
                if (GameManager.Instance.ItemCount >= 2)
                {
                    GameManager.Instance.CurruntDay++;
                    GameManager.Instance.ItemCount = 0;
                    MainChange();
                }
            }
            //�߰�, ������ �ϳ��� �԰� Ż��
            if (SceneManager.GetActiveScene().name == "Dream2")
            {
                if (GameManager.Instance.ItemCount > 0)
                {
                    player.SetActive(false); // �÷��̾�� ���� �浹 ����
                    Debug.Log("��ȯ");
                    GameManager.Instance.CurruntDay++;
                    GameManager.Instance.ItemCount = 0;
                    MainChange();
                }
            }

        }
    }

    public void MainChange()
    {
        if (MainPrefab == null) return;

        Instantiate(MainPrefab);
        mainTime = 2f;
        StartCoroutine(IEMainChange());
    }

    IEnumerator IEMainChange()
    {
        yield return new WaitForSeconds(mainTime);
        GameManager.Instance.SceneController.LoadScene("MainRoom");

        //itemcount�� ���� ���� �̻��̸� MainRoom�� �ؽ�Ʈ �߰�
    }
}
