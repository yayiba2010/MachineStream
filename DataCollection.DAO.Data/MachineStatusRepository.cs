using MachineStream.Entity;
using MachineStream.IRepository;
using Microsoft.Extensions.Configuration;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace MachineStream.Repository
{
    public class MachineStatusRepository : IMachineStatusRepository
    {
        private SqlClient _client;
        public MachineStatusRepository(SqlClient client)
        {
            _client = client;
        }

        public List<MachineStatus> GetAllList()
        {
            var clientInstance = _client.Init();
            var list = clientInstance.Queryable<MachineStatus>();
            return list.ToList();
        }

        public MachineStatus GetByMachineId(string machineId)
        {
            var clientInstance = _client.Init();
            var item = clientInstance.Queryable<MachineStatus>().First(e => e.MachineId == machineId);
            return item;
        }
        public bool IsExist(string machineId)
        {
            var clientInstance = _client.Init();
            var result = clientInstance.Queryable<MachineStatus>().Any(e => e.MachineId == machineId);
            return result;
        }

        public int Update(string machineId, string status)
        {
            var item = GetByMachineId(machineId);
            item.Status = status;
            item.LastUpdateDate = DateTime.Now;
            var clientInstance = _client.Init();
            int count = clientInstance.Updateable(item).ExecuteCommand();
            return count;
        }

        public int Add(MachineStatus status)
        {
            var clientInstance = _client.Init();
            status.CreateDate = DateTime.Now;
            var count = clientInstance.Insertable(status).ExecuteCommand();
            return count;
        }
    }
}
