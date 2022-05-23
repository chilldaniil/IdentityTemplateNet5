namespace App.DataContract.Contract
{
    public interface IEntity : IHaveId
    {
        bool IsDeleted { get; set; }
    }
}
