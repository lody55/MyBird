using UnityEngine;
using UnityEngine.InputSystem;
namespace MyBird
{
    //������ ��ü �÷ο츦 �����ϴ� Ŭ����
    //��� >> �̵� >> ����(���ó��)
    //static ó�� : �̱��� Ŭ���� , ������ staticó��
    public class GameManager : MonoBehaviour
    {
        #region Property
        public static bool IsStart { get; set; }

        #endregion

        private void Start()
        {
            
            //�ʱ�ȭ
            IsStart = false;

        }
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                IsStart = true;
            }
        }
    }
}