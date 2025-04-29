using UnityEngine;
namespace MyBird
{
    public class Title : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "PlayScene";

        [SerializeField] private bool isCheat = false;

        #endregion

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                isCheat = true;
                ResetSaveData();
            }
        }
        public void Play()
        {
            fader.FadeTo(loadToScene);
        }
        public void ResetSaveData()
        {
            if (isCheat == false)
                return;
            PlayerPrefs.DeleteAll();
        }
    }
}