using UnityEngine;
using Game.Database;
using Game.Scene;
using Game.Main;
using Unity;
using Game.Database.UnityScriptableObject;
using Game.UI;

public class GameStart : MonoBehaviour
{
    void Start()
    {
        IScriptableObjectLoader scriptableObjectLoader = new ScriptableObjectLoader();
        ISceneTable sceneTable = scriptableObjectLoader.LoadScriptableObject(eScriptableObject.SceneTable) as ISceneTable;
        ISceneSystem sceneSystem = new SceneSystem(sceneTable);
        IGameSetting gameSetting = new GameSetting();
        IUIPrefabTable uiPrefabTable = scriptableObjectLoader.LoadScriptableObject(eScriptableObject.UISystemTable) as IUIPrefabTable;
        IUILoader uiLoader = new UILoader(uiPrefabTable);
        IUISystem uiSystem = new UISystem(uiLoader);
        IGameProcessSystem gameProcessSystem = new GameProcessSystem(gameSetting, sceneSystem, uiSystem);
        IGameMainLoop gameMainLoop = new GameMainLoop(gameProcessSystem);
        gameMainLoop.Start();

        DontDestroyOnLoad(this);
    }
}
