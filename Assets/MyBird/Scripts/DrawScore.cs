using TMPro;
using UnityEngine;
namespace MyBird
{

    public class DrawScore : MonoBehaviour
    {
        //���ھ� �ؽ�Ʈ�� �׸���
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