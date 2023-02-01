using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{

    public class Player : MonoBehaviour
    {
        public List<Bomb> n_Bomb { get; set; }
        public float speed { get; set; }
        public bool godMode { get; set; }
        public bool strongBoi { get; set; } = false;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

