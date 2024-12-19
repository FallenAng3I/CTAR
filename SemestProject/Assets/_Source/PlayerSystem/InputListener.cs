using MenuManager;
using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    public class InputListener : MonoBehaviour
    {
        public Player player;
        public Rifle weapon;
        public PauseMenu pause;
        [SerializeField] public Texture2D cursorSprite;
        
        public LayerMask interactableLayer;
        
        private void Update()
        {
            ReadShoot();
            ReadReload();
            ReadUse();
            Scope();
            ReadEsc();
        }

        private void ReadShoot()
        {
            if (weapon.enabled)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    weapon.Shoot();
                }            
            }
        }
        
        private void Scope()
        {
            if (weapon.enabled)
            {
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    weapon.canShoot = true;
                    
                    Vector2 hotSpot = new Vector2(5f, 5f);
                    //Cursor.SetCursor(cursorSprite, hotSpot, CursorMode.Auto);
                }
                else
                {
                    weapon.canShoot = false;
                    
                    Vector2 hotSpot = new Vector2(5f, 5f);
                    //Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
                }
            }
        }        

        private void ReadReload()
        {
            if (weapon.enabled)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    weapon.Reload();
                }            
            }
        }

        private void ReadUse()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.Use();
            }
        }

        private void ReadEsc()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (player.isDead == false)
                {
                    if (pause.pauseGame)
                    {
                        pause.Resume();
                    }
                    else
                    {
                        pause.Pause();
                    }
                }
            }
        }
    }
}
