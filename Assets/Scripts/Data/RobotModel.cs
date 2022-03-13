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
            CreatePart(body, _body);
        }
        
        public void SetHead(GameObject head)
        {
            CreatePart(head, _head);
        }
        
        public void SetShoulder(GameObject shoulder)
        {
            CreatePart(shoulder, _shoulder);
        }
        
        public void Setback(GameObject back)
        {
            CreatePart(back, _back);
        }
        
        public void SetGloves(GameObject gloves)
        {
            CreatePart(gloves, _gloves);
        }

        private void CreatePart(GameObject prefab, GameObject placement)
        {
            var bodyInstance = Instantiate(prefab, placement.transform.parent);
            bodyInstance.transform.position = placement.transform.position;
        }
    }
}