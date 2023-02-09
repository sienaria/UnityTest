using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileStreamSample : MonoBehaviour
{
    // 새로 추가된 부분



    private void Awake()
    {
        Stream writeStream = new FileStream("TextFileStream.dat", FileMode.Create);
        StreamWriter streamWriter= new StreamWriter(writeStream);

        // StreamWriter의 Write(), WriteLine() 메소드는 모든 C# 데이터 형식에 대해 오버로딩
        streamWriter.Write(36);             // 엔터가 없는 입력
        streamWriter.WriteLine(12.34f);     // 내용 끝에 엔터가 자동 삽입
        streamWriter.WriteLine("여러분 안녕하세요.");

        // 사용 완료 후 Close()로 스트림 닫기
        streamWriter.Close();

        Stream readStream = new FileStream("TextFileStream.dat", FileMode.Open);
        StreamReader streamReader = new StreamReader(readStream);

        // 한 줄씩 읽어서 처리할 때는 while 반복문과 EndOfStream 프로퍼티 이용
        // 스트림의 끝에 도달했는지 검사

        while(streamReader.EndOfStream == false)
        {
            Debug.Log(streamReader.ReadLine());
        }

        // 한꺼번에 읽어서 처리해야 할 때는 ReadToEnd() 메소드 이용
        // 현재 커서가 있는 위치부터 파일의 끝까지 데이터를 읽어온다
        // Debug.Log(streamReader.REadToEnd());

        // 사용 완료 후 close()로 스트림 닫기
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
