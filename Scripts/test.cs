using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;

public class test : MonoBehaviour
{
    // mysql连接字符串
    static String ConnetStr = "Server=3.92.135.74;Database=mysql_test;UserID=root;Password=Haisec2022??;Port=3306;";
    MySqlConnection conn = null;

    // Start is called before the first frame update
    void Start()
    {
        // 创建连接
        conn = new MySqlConnection(ConnetStr);
        try
        {
            conn.Open();    // 打开通道,建立连接
            Debug.Log("连接成功...");
            // 增、删、改、查的操作
        }
        catch (MySqlException ex)
        {
            // 打印异常信息
            Debug.Log(ex.Message);
        }
        finally
        {
            // 关闭连接
            if (conn != null)
                conn.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
