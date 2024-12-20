﻿using System;
using System.Data;
using MySql.Data.MySqlClient;
using UnityEngine;
using System.Text;

public class SqlAccess
{
	public static MySqlConnection dbConnection;
	
	static string host = "3.92.135.74";
	static string port = "3306";
	static string username = "root";
	static string pwd = "Haisec2022??";
	static string database = "mysql_test";

	public SqlAccess()
	{
		OpenSql();
	}

	/// <summary>
	/// 连接数据库
	/// </summary>
	public static void OpenSql()
	{
		try
		{
			string connectionString = string.Format("server = {0};port={1};database = {2};user = {3};password = {4};", host, port, database, username, pwd);
			Debug.Log(connectionString);
			dbConnection = new MySqlConnection(connectionString);
			dbConnection.Open();
			Debug.Log("建立连接");
		}
		catch (Exception e)
		{
			throw new Exception("服务器连接失败，请重新检查是否打开MySql服务。" + e.Message.ToString());
		}
	}

	/// <summary>
	/// 关闭数据库连接
	/// </summary>
	public void Close()
	{
		if (dbConnection != null)
		{
			dbConnection.Close();
			dbConnection.Dispose();
			dbConnection = null;
			Debug.Log("关闭连接");
		}
	}

	/// <summary>
	/// 查询
	/// </summary>
	/// <param name="tableName">表名</param>
	/// <param name="items">查询元素</param>
	/// <param name="col">字段名</param>
	/// <param name="operation">运算符</param>
	/// <param name="values">字段值</param>
	/// <returns>DataSet</returns>
	public DataSet SelectWhere(string tableName, string[] items)
	{

		//if (col.Length != operation.Length || operation.Length != values.Length)
		//	throw new Exception("col.Length != operation.Length != values.Length");

		StringBuilder query = new StringBuilder();
		query.Append("SELECT ");
		query.Append(items[0]);

		for (int i = 1; i < items.Length; ++i)
		{
			query.Append(", ");
			query.Append(items[i]);
		}

		query.Append(" FROM ");
		query.Append(tableName);
		query.Append(" WHERE 1=1");

		///for (int i = 0; i < col.Length; ++i)
		///{
		///	query.Append(" AND ");
		///	query.Append(col[i]);
		///	query.Append(operation[i]);
		///	query.Append("'");
		///	query.Append(values[0]);
		///	query.Append("' ");
		///}
		Debug.Log(query.ToString());
		return ExecuteQuery(query.ToString());
	}

	/// <summary>
	/// 增加
	/// </summary>
	/// <param name="tableName">表名</param>
	/// <param name="items">添加元素</param>
	/// <param name="values">字段值</param>
	/// <returns>DataSet</returns>
	public DataSet Add_data(string tableName, string[] items, string[] values)
	{

		if (items.Length != values.Length)
			throw new Exception("items.Length != values.Length");

		StringBuilder query = new StringBuilder();
		query.Append("INSERT INTO ");
		query.Append(tableName);
		query.Append("(");

		query.Append(items[0]);
		for (int i = 1; i < items.Length; ++i)
		{
			query.Append(", ");
			query.Append(items[i]);
		}
		query.Append(")");

		query.Append(" VALUES ");

		query.Append("(");

		
		query.Append(values[0]);
		for (int i = 1; i < values.Length; ++i)
		{
			query.Append(", ");
			query.Append(values[i]);
		}

		query.Append(")");

		
		Debug.Log(query.ToString());
		return ExecuteQuery(query.ToString());
	}

	/// <summary>
	/// 执行sql语句
	/// </summary>
	/// <param name="sqlString">sql语句</param>
	/// <returns></returns>
	public static DataSet ExecuteQuery(string sqlString)
	{
		if (dbConnection.State == ConnectionState.Open)
		{
			DataSet ds = new DataSet();
			try
			{
				MySqlDataAdapter da = new MySqlDataAdapter(sqlString, dbConnection);
				da.Fill(ds);
			}
			catch (Exception ee)
			{
				throw new Exception("SQL:" + sqlString + "/n" + ee.Message.ToString());
			}
			finally
			{
			}
			return ds;
		}
		return null;
	}
}
