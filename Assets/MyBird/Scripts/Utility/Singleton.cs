using UnityEngine;
namespace MyBird
{
    //제네릭 싱글톤 클래스
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                return instance;
            }
        }
        //싱글톤 객체 존재여부 체크
        public static bool InstanceExist
        {
            get
            {
                return instance != null;
            }
        }

        protected virtual void Awake()
        {
            //싱글톤을 가진 오브젝트가 이미 존재하면
            if(instance != null)
            {
                //이 오브젝트를 킬
                Destroy(gameObject);
            }
            instance = (T)this;
        }

        //오브젝트 킬 할때 instance 초기화
        protected void OnDestroy()
        {
            if(instance == this)
            {
                instance = null;
            }
        }
    }


}