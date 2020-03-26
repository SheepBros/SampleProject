using UnityEngine;
using SimpleDI;

namespace SB.UI.Sample
{
    public class View<TController> : MonoBehaviour where TController : IViewController
    {
        protected TController _controller;

        [Inject]
        public void InitContext(TController controller)
        {
            _controller = controller;
        }
    }
}