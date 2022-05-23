using System;

namespace App.DataContract.Contract
{
    public interface IHaveId
    {
        Guid Id { get; set; }
    }
}