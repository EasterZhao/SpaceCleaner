using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Counter
{

    public class BaseCounter : MonoBehaviour, ICubeObjectParent
    {
        [SerializeField] private Transform counterTopPoint;
        private CubeObject cubeObject;
        public virtual void Interact(Player player)
        {

        }

        public virtual void InteractAlternate(Player player)
        {

        }

        public Transform GetCubeObjectFollowTransform()
        {
            return counterTopPoint;
        }

        public void SetCubeObject(CubeObject cubeObject)
        {
            this.cubeObject = cubeObject;
        }

        public CubeObject GetCubeObject()
        {
            return cubeObject;
        }

        public void ClearCubeObject()
        {
            cubeObject = null;
        }

        public bool HasCubeObject()
        {
            return cubeObject != null;
        }
    }
}