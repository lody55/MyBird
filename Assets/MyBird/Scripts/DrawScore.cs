using TMPro;
using UnityEngine;
namespace MyBird
{

    public class DrawScore : MonoBehaviour
    {
        //스코어 텍스트를 그린다
        #region Variables
        [SerializeField] TextMeshProUGUI scoreText;
        #endregion


        // Update is called once per frame
        void Update()
        {
            scoreText.text = GameManager.Score.ToString();
        }
    }
}