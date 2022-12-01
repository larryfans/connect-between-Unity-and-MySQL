using System.Data;
using UnityEngine;

public class Add_table : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SqlAccess sql = new SqlAccess();
        string[] items = { "id", "name" };//更改元素，与自己表对应
        
        string[] val = {"36", "'smart'"};   //需要添加的信息
        sql.Add_data("test_table1", items, val); ////读取表，此处把表名改为自己需要查询的表
        DataSet ds = sql.SelectWhere("test_table1", items);//读取表，此处把表名改为自己需要查询的表

        if (ds != null)
        {
            DataTable table = ds.Tables[0];
            foreach (DataRow row in table.Rows)
            {
                string str = "";
                foreach (DataColumn column in table.Columns)
                    str += row[column] + " ";
                Debug.Log(str);
            }
        }
        sql.Close();

    }

}
