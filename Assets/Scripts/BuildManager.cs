using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BuildManager: �̱���
public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    //���õ� Ÿ��(�ͷ��� ��ġ��)
    private Tile selectedTile;

    //Ÿ�� UI ������Ʈ �ν��Ͻ� ����
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

    //Ÿ�Ͽ� ��ġ�� ���� �ͷ� ������Ʈ ������ ������ ���� ����
    //�ͷ� ������Ʈ�� ���׷��̵� ������ ������ ���� ����
    public TurretBlueprint turretToBuildBluePrint;
    //���� ����Ʈ ������
    //public GameObject buildEffect;

    //������Ƽ: �������� ��ġ�� �ͷ��� ��뺸�� �� ������ false, ����ϸ� true return
    public bool HasBuildMoney
    {
        get
        {
            return PlayerStats.money >= turretToBuildBluePrint.price;
        }
    }

    //�ͷ��� ��ġ�� Ÿ���� ����
    public void SelectTile(Tile tile)
    {
        if (selectedTile == tile)
        {
            //����� Ÿ���� �ٽ� ����
            DeSelectTile();
            return;
        }

        //���õ� Ÿ���� ����
        DeSelectTile();
        selectedTile = tile;
        //Ÿ�Ͽ� ��ġ�� ���� �ͷ� ������Ʈ ������ ������ ���� ������ ����
        turretToBuildBluePrint = null;

        //���õ� Ÿ���� UI�� ������
        tileUIObject.GetComponent<TileUI>().ShowTileUI(selectedTile);
        //tileUI.ShowTileUI();
    }

    public void DeSelectTile()
    {
        tileUI.HideTileUI();
        selectedTile = null;
    }


    //�⺻�ͷ� ������
    //public GameObject basicTurretPrefab;
    //�ٸ��ͷ� ������
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
            //�� ����
            Debug.Log("�������� �����մϴ�.");
            return;
        }


        //�� ��� + �ͷ� �Ǽ�
        if (PlayerStats.UseMoney(turretToBuildBluePrint.price))
        {   
            Vector3 buildPos = tile.GetBuildPosition() + turretToBuildBluePrint.offsetPos;
            GameObject _turret = (GameObject)Instantiate(turretToBuildBluePrint.prefab, buildPos, Quaternion.identity);
            tile.turret = _turret;
            

            //���� ����Ʈ
            GameObject effect = (GameObject)Instantiate(buildEffect, buildPos, Quaternion.identity);
            Destroy(effect.gameObject, 2f);

            Debug.Log($"�ͷ� �Ǽ� �� ������: {PlayerStats.money}");
            
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
        //���õ� Ÿ���� ������ ������Ŵ
        DeSelectTile();
    }

    public bool CheckMoney()
    {
        return PlayerStats.money >= turretToBuildBluePrint.price;
    }

}
