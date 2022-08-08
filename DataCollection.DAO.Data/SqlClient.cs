using Microsoft.Extensions.Configuration;
using SqlSugar;

using System.Configuration;
namespace MachineStream.Repository
{
    public class SqlClient
    {
        private IConfiguration _configuration;
        public SqlClient(IConfiguration config)
        {
            _configuration = config;
        }
        public SqlSugarClient Init()
        {
            var SqlSugarClient = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = _configuration["MainDB"],//必填, 数据库连接字符串
                DbType = SqlSugar.DbType.SqlServer,         //必填, 数据库类型
                IsAutoCloseConnection = true,      //默认false, 时候知道关闭数据库连接, 设置为true无需使用using或者Close操作
                InitKeyType = InitKeyType.SystemTable    //默认SystemTable, 字段信息读取, 如：该属性是不是主键，是不是标识列等等信息
            });
            return SqlSugarClient;
        }
    }
  }

