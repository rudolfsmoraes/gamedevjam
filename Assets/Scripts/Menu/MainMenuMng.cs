﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Classe Responsável por gerenciar os painéis do menu
/// </summary>
public class MainMenuMng : MonoBehaviour
{
    public static MainMenuMng Instance;
    public static CharacterPannelCtlr CharacterPannel;
    public static SettingsPannelCtlr SettingsPannel;
    void Start()
    {
        if(Instance == null){
            DBMng.FirstGame();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            AudioManager.Instance.SetVolumes();
            Time.timeScale = 1;
            CharacterPannel = characterPnl.GetComponent<CharacterPannelCtlr>();
            SettingsPannel = settingsPannel.GetComponent<SettingsPannelCtlr>();
            SettingsPannel.SetSlidersVolume();
            SettingsPannel.SetSensibilityMouse();
            ShowPannel(pannels[DBMng.LastPannel()]);
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    
    [Header("Painéis do menu")]
    [SerializeField] List<PannelCtlr> pannels = new List<PannelCtlr>(); 
    [SerializeField] GameObject characterPnl;
    [SerializeField] GameObject settingsPannel;

    /// <summary>
    /// Habilita o painel desejado
    /// </summary>
    /// <param name="pannel">Painel a ser aberto</param>
    public void ShowPannel(PannelCtlr pannel){
        var pannelShow = pannels.FirstOrDefault(p => p.Compare(pannel));
        if(pannelShow!=null){
            foreach(PannelCtlr pnl in pannels){
                pnl.gameObject.SetActive(false);
            }
            pannelShow.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Fecha o jogo
    /// </summary>
    public void QuitAplication(){
        Application.Quit();
    }
}
