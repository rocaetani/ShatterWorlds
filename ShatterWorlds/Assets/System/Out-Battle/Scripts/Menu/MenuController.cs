using System;
using System.Collections.Generic;
using UnityEngine;


public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    
    public enum MenuItemCategory {
        LogIn = 0,
        SignIn = 1,
        Loading = 2,
        Main = 3,
        CreateFirstCharacter = 4,
        CreateCharacter = 5
    }
    
    [Serializable]
    public struct MenuItem
    {
        public MenuItemCategory category;
        public GameObject panel;
   
        //Constructor (not necessary, but helpful)
        public MenuItem(MenuItemCategory category, GameObject panel)
        {
            this.category = category;
            this.panel = panel;
        }
    }

    [SerializeField]
    public List<MenuItem> MenuItems;
    
    private Dictionary<MenuItemCategory, GameObject> _menuItems;

    private MenuItemCategory _activeMenu;

    private void Awake()
    {
        if (instance != null)
        {
            ErrorLogger.instance.LogError("MenuController singleton already instantiated.", this);
            Destroy(this);
        }

        instance = this;
        InitializeMenuItems();
        _activeMenu = MenuItemCategory.LogIn;
        ActivateMenu(_activeMenu);
    }

    private void InitializeMenuItems()
    {
        _menuItems = new Dictionary<MenuItemCategory, GameObject>();
        foreach (var item in MenuItems)
        {
            _menuItems.Add(item.category, item.panel);
            DeactivateMenu(item.category);
        }
    }

    public void ChangeMenu(MenuItemCategory category)
    {
        DeactivateMenu(_activeMenu);
        ActivateMenu(category);
        _activeMenu = category;
    }

    private void ActivateMenu(MenuItemCategory category)
    {
        _menuItems[category].SetActive(true);
    }

    private void DeactivateMenu(MenuItemCategory category)
    {
        _menuItems[category].SetActive(false);
    }

    public void ChangeMenu(int category)
    {
        ChangeMenu((MenuItemCategory) category);
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
