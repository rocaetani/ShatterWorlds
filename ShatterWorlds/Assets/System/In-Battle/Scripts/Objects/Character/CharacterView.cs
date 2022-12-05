using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InBattle
{
    public class CharacterView : MonoBehaviour
    {
        public MeshRenderer Mesh;


        private void Start()
        {
            //Material = gameObject.GetComponent<Material>();
        }

        public void MarkRed()
        {
            Mesh.material.color = Color.red;
        }

        public void MarkGreen()
        {
            Mesh.material.color = Color.green;

        }
    }
}
