using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace MyBird
{
    public class ResultUI : MonoBehaviour
    {
        //게임 결과 보여주기 : 베스트스코어 , 스코어 보여주고 , 다시하기 , 메뉴가기 버튼 기능 구현

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

            //BestScore와 GameScore비교
            if(GameManager.Score > GameManager.BestScore)
            {
                //최고 점수 갱신
                GameManager.BestScore = GameManager.Score;
                //파일저장
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