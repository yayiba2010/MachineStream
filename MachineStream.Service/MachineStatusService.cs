
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Threading;
using MachineStream.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MachineStream.Repository;
using MachineStream.IService;
using MachineStream.IRepository;
using Microsoft.Extensions.Configuration;

namespace MachineStream.Service
{
    public class MachineStatusService : IMachineStatusService
    {

        private IMachineStatusRepository _repository;
        private IConfiguration _configuration;
        public MachineStatusService(IMachineStatusRepository repository, IConfiguration config)
        {
            _configuration = config;
            _repository = repository;
        }

      

        public List<MachineStatus> GetMachineStatusList()
        {
            var list = _repository.GetAllList();
            return list;
        }


        public void Save(MachineStatus machineStatus)
        {
            var exist = _repository.IsExist(machineStatus.MachineId);
            if (exist)
            {
                _repository.Update(machineStatus.MachineId, machineStatus.Status);
            }
            else
            {
                _repository.Add(machineStatus);
            }
        }

    }
}
