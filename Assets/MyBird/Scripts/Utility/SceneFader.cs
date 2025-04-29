using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
namespace MyBird
{
    
    public class SceneFader : MonoBehaviour
    {
        #region Field
        
        //페이더 이미지
        public Image img;
        public AnimationCurve animationCurve;
        #endregion
        //코루틴으로 구현
        private void Start()
        {
            //FadeIn효과 = 1초동안 : 페이드인(이미지 알파값 a:1 >>> a:0) 검정에서 투명
            StartCoroutine(FadeIn());


            //FadeTo("UnityTest");


        }

        IEnumerator FadeIn()
        {
            float t = 1f;
            while(t > 0)
            {
                t -= Time.deltaTime;
                float a = animationCurve.Evaluate(t);
                img.color = new Color(0f, 0f, 0f, a);
                yield return 0f;
            }
        }


        //FadeOut = 1초동안 : 페이드아웃 (이미지 알파값 a:0 >>> a:1) 투명에서 검정
        //IEnumerator FadeOut()
        //{
            
        //}

        //FadeOut 효과 후 매개변수로 받은 씬으로 이동
        IEnumerator FadeOut(string sceneName)
        {
            float t = 0f;
            while (t <= 1)
            {
                t += Time.deltaTime;
                float a = animationCurve.Evaluate(t);
                img.color = new(0f, 0f, 0f, a);

                yield return 0f;
            }
            //씬 이동
            SceneManager.LoadScene(sceneName);
        }
        

        //다른 씬으로 이동시 FadeOut 효과 후 LoadScene으로 이동
        public void FadeTo(string snceneName )
        {
            StartCoroutine(FadeOut(snceneName));
        }


        public void FadeOutOnly(System.Action onComplete)
        {
            StartCoroutine(FadeOutRoutine(onComplete));
        }
    
        IEnumerator FadeOutRoutine(System.Action onComplete)
        {
            float t = 0f;
            while (t <= 1)
            {
                t += Time.unscaledDeltaTime; // 게임 일시정지 중에도 작동
                float a = animationCurve.Evaluate(t);
                img.color = new Color(0f, 0f, 0f, a);
                yield return null;
            }

            onComplete?.Invoke();

            // 페이드 인 다시 해주면 자연스럽게 복귀
            StartCoroutine(FadeIn());
        }

    }
}