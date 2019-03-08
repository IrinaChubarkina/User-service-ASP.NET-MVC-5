using System.Data;

namespace MyBase.BLL.DataGen.Interfaces
{
    public interface ITableGenerator
    {
        DataTable CreateTable(int recordsCount);        
    }
}
