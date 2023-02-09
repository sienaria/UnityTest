using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileStreamSample : MonoBehaviour
{
    // ���� �߰��� �κ�



    private void Awake()
    {
        Stream writeStream = new FileStream("TextFileStream.dat", FileMode.Create);
        StreamWriter streamWriter= new StreamWriter(writeStream);

        // StreamWriter�� Write(), WriteLine() �޼ҵ�� ��� C# ������ ���Ŀ� ���� �����ε�
        streamWriter.Write(36);             // ���Ͱ� ���� �Է�
        streamWriter.WriteLine(12.34f);     // ���� ���� ���Ͱ� �ڵ� ����
        streamWriter.WriteLine("������ �ȳ��ϼ���.");

        // ��� �Ϸ� �� Close()�� ��Ʈ�� �ݱ�
        streamWriter.Close();

        Stream readStream = new FileStream("TextFileStream.dat", FileMode.Open);
        StreamReader streamReader = new StreamReader(readStream);

        // �� �پ� �о ó���� ���� while �ݺ����� EndOfStream ������Ƽ �̿�
        // ��Ʈ���� ���� �����ߴ��� �˻�

        while(streamReader.EndOfStream == false)
        {
            Debug.Log(streamReader.ReadLine());
        }

        // �Ѳ����� �о ó���ؾ� �� ���� ReadToEnd() �޼ҵ� �̿�
        // ���� Ŀ���� �ִ� ��ġ���� ������ ������ �����͸� �о�´�
        // Debug.Log(streamReader.REadToEnd());

        // ��� �Ϸ� �� close()�� ��Ʈ�� �ݱ�
        streamReader.Close();


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
