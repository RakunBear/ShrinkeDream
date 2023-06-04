using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Transition;
using Game;

namespace Game.MainRoom
{
    public class RoomContorller : MonoBehaviour
    {
        [Header("Audio")]
        public AudioClip[] clips;
        [Header("Reference")]
        public MemoContorller MemoContorller;
        [Header("Render")]
        public GameObject DreamChangePrefab;
        private float dreamTime = 1.0f;
        [Header("DayProgress")]
        public GameObject[] dayProgress;

        private void Start()
        {
            GameManager.Instance.BGM_Audio.clip = clips[0];
            GameManager.Instance.BGM_Audio.Play();
            if (dayProgress.Length > 0 && dayProgress.Length > GameManager.Instance.CurruntDay)
            {
                DayProgress progress = dayProgress[GameManager.Instance.CurruntDay].GetComponent<DayProgress>();
                progress.gameObject.SetActive(true);
                progress.Run();
            }
        }

        public void DreamChange()
        {
            if (DreamChangePrefab == null) return;

            Instantiate(DreamChangePrefab);
            dreamTime = DreamChangePrefab.GetComponent<DreamChangeRander>().FadeTime;
            StartCoroutine(IEDreamChange());
        }
        public void DreamChange(string sceneName)
        {
            if (DreamChangePrefab == null) return;

            Instantiate(DreamChangePrefab);
            dreamTime = DreamChangePrefab.GetComponent<DreamChangeRander>().FadeTime;
            StartCoroutine(IEDreamChange(sceneName));
        }

        IEnumerator IEDreamChange()
        {
            yield return new WaitForSeconds(dreamTime);
            //Itemcount�� currentday�� �޾Ƽ� Dream �߰� / ���� ������ �Ѿ�� ������� ��������
            if (GameManager.Instance.ItemCount < 2) { 
                GameManager.Instance.SceneController.LoadScene("Dream");
            }
            else if (GameManager.Instance.ItemCount >= 2)
            {
                GameManager.Instance.SceneController.LoadScene("Dream2");
            }
        }

        IEnumerator IEDreamChange(string sceneName)
        {
            yield return new WaitForSeconds(dreamTime);
            //Itemcount�� currentday�� �޾Ƽ� Dream �߰� / ���� ������ �Ѿ�� ������� ��������
            GameManager.Instance.SceneController.LoadScene(sceneName);
        }
    }
}