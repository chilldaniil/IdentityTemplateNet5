using System;

namespace App.DataContract.Contract
{
    public interface IHaveVersion
    {
        int Version { get; set; }
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
    }
}