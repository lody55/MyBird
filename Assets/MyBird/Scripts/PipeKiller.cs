using UnityEngine;
namespace MyBird
{
    //파이프킬러와 충돌하는 모든 충돌체는 Destroy된다
    //킬을 구현해도 
    //1. 충돌나지 않는다  2. 충돌나도 kill되지 않는다
    public class PipeKiller : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);

        }
    }
}