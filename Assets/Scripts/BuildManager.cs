using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BuildManager: 싱글톤
public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    //선택된 타일(터렛이 설치된)
    private Tile selectedTile;

    //타일 UI 오브젝트 인스턴스 선언
    public GameObject tileUIObject;
    public TileUI tileUI;


    private void Awake()
    {
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        //DontDestroyOnLoad(gameObject);

    }

    //타일에 설치를 위한 터렛 오브젝트 프리팹 정보와 가격 정보
    //터렛 오브젝트의 업그레이드 프리팹 정보와 가격 정보
    public TurretBlueprint turretToBuildBluePrint;
    //빌드 이펙트 프리팹
    //public GameObject buildEffect;

    //프로퍼티: 소지금이 설치할 터렛의 비용보다 더 적으면 false, 충분하면 true return
    public bool HasBuildMoney
    {
        get
        {
            return PlayerStats.money >= turretToBuildBluePrint.price;
        }
    }

    //터렛이 설치된 타일을 선택
    public void SelectTile(Tile tile)
    {
        if (selectedTile == tile)
        {
            //저장된 타일을 다시 선택
            DeSelectTile();
            return;
        }

        //선택된 타일을 저장
        DeSelectTile();
        selectedTile = tile;
        //타일에 설치를 위한 터렛 오브젝트 프리팹 정보와 가격 정보를 삭제
        turretToBuildBluePrint = null;

        //선택된 타일의 UI를 보여줌
        tileUIObject.GetComponent<TileUI>().ShowTileUI(selectedTile);
        //tileUI.ShowTileUI();
    }

    public void DeSelectTile()
    {
        tileUI.HideTileUI();
        selectedTile = null;
    }


    //기본터렛 프리팹
    //public GameObject basicTurretPrefab;
    //다른터렛 프리팹
    //public GameObject missileLauncherPrefab;

    private void Start()
    {
        turretToBuildBluePrint = null;
    }
    
    /*public void OnBuildTurret(Tile tile)
    {

        //GameObject _turret = (GameObject)Instantiate(turretToBuildBluePrint.prefab, tile.transform.position + tile.offsetPos, Quaternion.identity);
        //tile.turret = _turret;

        if (!PlayerStats.HaveMoney(turretToBuildBluePrint.price))
        {
            //돈 부족
            Debug.Log("소지금이 부족합니다.");
            return;
        }


        //돈 계산 + 터렛 건설
        if (PlayerStats.UseMoney(turretToBuildBluePrint.price))
        {   
            Vector3 buildPos = tile.GetBuildPosition() + turretToBuildBluePrint.offsetPos;
            GameObject _turret = (GameObject)Instantiate(turretToBuildBluePrint.prefab, buildPos, Quaternion.identity);
            tile.turret = _turret;
            

            //빌드 이펙트
            GameObject effect = (GameObject)Instantiate(buildEffect, buildPos, Quaternion.identity);
            Destroy(effect.gameObject, 2f);

            Debug.Log($"터렛 건설 후 소지금: {PlayerStats.money}");
            
        }

        //PlayerStats.UseMoney(turretToBuildBluePrint.price);
        //PlayerStats.money -= turretToBuildBluePrint.price;
        
        
    }
    */
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuildBluePrint;
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuildBluePrint = turret;
        Debug.Log(turretToBuildBluePrint);
        //선택된 타일이 있으면 해제시킴
        DeSelectTile();
    }

    public bool CheckMoney()
    {
        return PlayerStats.money >= turretToBuildBluePrint.price;
    }

}
