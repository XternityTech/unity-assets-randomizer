using UnityEngine;

namespace Xternity
{
    public class RobotModel : MonoBehaviour
    {
        [SerializeField]
        private GameObject _body;
        
        [SerializeField]
        public GameObject _head;
        
        [SerializeField]
        public GameObject _shoulder;
        
        [SerializeField]
        public GameObject _back;
        
        [SerializeField]
        public GameObject _gloves;

        public void SetBody(GameObject body)
        {
            var bodyInstance = Instantiate(body, _body.transform.parent);
            bodyInstance.transform.position = _body.transform.position;
        }
    }
}