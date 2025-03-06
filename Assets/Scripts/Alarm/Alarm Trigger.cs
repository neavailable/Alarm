using System;
using UnityEngine;


namespace Alarm
{
    [RequireComponent(typeof(BoxCollider))]
    
    public class AlarmTrigger : MonoBehaviour
    {
        public Action<bool> ShouldStartAlarm;


        private void PlayAction(Collider collider, bool shouldStart)
        {
            if (collider.TryGetComponent<Player.Player>
                    (out Player.Player player))
            {
                ShouldStartAlarm?.Invoke(shouldStart);
            }
        }
        
        private void OnTriggerEnter(Collider collider) => PlayAction(collider, true);
        
        private void OnTriggerExit(Collider collider) => PlayAction(collider, false);
    }	
}