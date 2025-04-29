using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace MyBird
{
    public class ResultUI : MonoBehaviour
    {
        //���� ��� �����ֱ� : ����Ʈ���ھ� , ���ھ� �����ְ� , �ٽ��ϱ� , �޴����� ��ư ��� ����

        [SerializeField] Button retryButton;
        [SerializeField] Button menuButton;
        [SerializeField] TextMeshProUGUI score;
        [SerializeField] TextMeshProUGUI bestScore;
        [SerializeField] TextMeshProUGUI newText;

        public SceneFader fader;
        [SerializeField] private string loadToScene = "Title";


        private void OnEnable()
        {
            score.text = GameManager.Score.ToString();

            //BestScore�� GameScore��
            if(GameManager.Score > GameManager.BestScore)
            {
                //�ְ� ���� ����
                GameManager.BestScore = GameManager.Score;
                //��������
                PlayerPrefs.SetInt("BestScore", GameManager.Score);
                newText.text = "NEW";
            }
            else
            {
                newText.text = " ";
            }
            bestScore.text = GameManager.BestScore.ToString();
            score.text = GameManager.Score.ToString();
        }
        private void Update()
        {
            
        }
        public void Retry()
        {
            fader.FadeTo(SceneManager.GetActiveScene().name);
        }
        public void Menu()
        {
            fader.FadeTo("Title");
        }

    }
}