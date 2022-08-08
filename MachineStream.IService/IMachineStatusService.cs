using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MachineStream.Entity;

namespace MachineStream.IService
{
    public interface IMachineStatusService
    {
        List<MachineStatus> GetMachineStatusList();

        void Save(MachineStatus entity);
    }
}
