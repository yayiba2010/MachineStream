using MachineStream.Entity;
using System;
using System.Collections.Generic;

namespace MachineStream.IRepository
{
    public interface IMachineStatusRepository
    {
        List<MachineStatus> GetAllList();

        MachineStatus GetByMachineId(string machineId);

        int Update(string machineId, string status);

        int Add(MachineStatus status);

        bool IsExist(string machineId);
    }
}
